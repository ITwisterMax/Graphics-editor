using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graphics_Editor
{
    // Линия
    public class Polygon : GeneralTool
    {
        // Массив точек
        private List<TwoPoints> pointsList;
        // Общее количество углов
        private int currCount;
        // Количество нарисованных углов
        private int drawCount;

        // Конструктор
        public Polygon(PictureBox backGround, Color penColor, int penWidth, Color brushColor, int angleCount) : base(backGround)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.brushColor = brushColor;
            this.angleCount = angleCount;
            currCount = angleCount - 1;
            drawCount = 0;
            pointsList = new List<TwoPoints>();
            tmpList = new List<TwoPoints>();
        }

        // Метод для рисования
        public override void Draw(Point point1, Point point2, Graphics g)
        {
            Pen currPen = null;
            SolidBrush currBrush = null;
            try
            {
                // Устанавливаем текущие параметры кисти
                currPen = new Pen(penColor, penWidth);
                currBrush = new SolidBrush(brushColor);
                isEnd = false;

                // На случай, если было изменено количество углов
                if (currCount != this.angleCount - 1)
                    currCount = this.angleCount - 1;

                // Проверка на то, можно ли рисовать
                if (point1 != point2)
                    if (!canWrite)
                        using (var graphics = Graphics.FromImage(backGround.Image))
                        {
                            if (drawCount < currCount)
                            {
                                // Отрисовка многоугольника
                                if (drawCount > 0)
                                    point1 = pointsList[drawCount - 1].point2;
                                pointsList.Add(new TwoPoints(point1, point2));
                                drawCount++;
                                var pointsArray = new Point[drawCount + 1];
                                pointsArray[0] = pointsList[0].point1;
                                int i = 1;
                                foreach (TwoPoints points in pointsList)
                                {
                                    pointsArray[i] = points.point2;
                                    i++;
                                }
                                graphics.DrawLines(currPen, pointsArray);
                                if (drawCount == currCount)
                                {
                                    isEnd = true;
                                    tmpPenWidth = penWidth;
                                    tmpPenColor = penColor;
                                    tmpBrushColor = brushColor;
                                    tmpList.Clear();
                                    point1 = pointsList[pointsList.Count - 1].point2;
                                    point2 = pointsList[0].point1;
                                    pointsList.Add(new TwoPoints(point1, point2));
                                    drawCount++;
                                    var pointArray = new Point[pointsList.Count + 1];
                                    pointsArray[0] = pointsList[0].point1;
                                    i = 1;
                                    foreach (TwoPoints points in pointsList)
                                    {
                                        tmpList.Add(points);
                                        pointArray[i] = points.point2;
                                        i++;
                                    }
                                    pointArray[0] = pointsList[0].point1;
                                    graphics.FillPolygon(currBrush, pointArray);
                                    graphics.DrawLines(currPen, pointArray);
                                    pointsList.Clear();
                                    currCount = this.angleCount - 1;
                                    drawCount = 0;
                                }
                            }
                        }
                    else
                        if (drawCount < currCount)
                        {
                            // Отрисовка линии
                            if (drawCount > 0)
                                point1 = pointsList[drawCount - 1].point2;
                            g.DrawLine(currPen, point1, point2);
                        }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                currPen.Dispose();
                currBrush.Dispose();
            }
        }

        // Перерисовка фигуры
        public override void reDraw(Graphics g)
        {
            var tmpPen = new Pen(tmpPenColor, tmpPenWidth);
            var tmpBrush = new SolidBrush(tmpBrushColor);

            var pointsArray = new Point[tmpList.Count + 1];
            pointsArray[0] = tmpList[0].point1;
            int i = 1;
            foreach (TwoPoints points in tmpList)
            {
                pointsArray[i] = points.point2;
                i++;
            }
            g.FillPolygon(tmpBrush, pointsArray);
            g.DrawLines(tmpPen, pointsArray);
        }

        // Метод для создания копии объекта фигуры
        public override GeneralTool Clone()
        {
            var cloneLinePoints1 = new List<TwoPoints>(pointsList);
            var cloneLinePoints2 = new List<TwoPoints>(tmpList);
            var newShape = (Polygon)this.MemberwiseClone();
            newShape.pointsList = cloneLinePoints1;
            newShape.tmpList = cloneLinePoints2;
            return newShape;
        }
    }
}
