using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Graphics_Editor;

namespace Trapeze_Example
{
    // Трапеция
    public class Trapeze : GeneralTool
    {
        // Конструктор
        public Trapeze(PictureBox backGround, Color penColor, int penWidth, Color brushColor) : base(backGround)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.penWidth = penWidth;
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

                // Массив точек
                var tmp_array = new Point[] { point1, new Point(point2.X - (point2.X - point1.X) / 5, point1.Y),
                    point2, new Point(point1.X - (point2.X - point1.X) / 5, point2.Y) };

                // Проверка на то, можно ли рисовать
                if (!canWrite)
                    using (var graphics = Graphics.FromImage(backGround.Image))
                    {
                        // Отрисовка трапеции
                        graphics.FillPolygon(currBrush, tmp_array);
                        graphics.DrawPolygon(currPen, tmp_array);
                        isEnd = true;
                        tmpPenWidth = penWidth;
                        tmpPenColor = penColor;
                        tmpBrushColor = brushColor;
                        this.point1 = point1;
                        this.point2 = point2;
                    }
                else
                {
                    // Отрисовка трапеции
                    g.FillPolygon(currBrush, tmp_array);
                    g.DrawPolygon(currPen, tmp_array);
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

            var tmp_array = new Point[] { point1, new Point(point2.X - (point2.X - point1.X) / 5, point1.Y),
                point2, new Point(point1.X - (point2.X - point1.X) / 5, point2.Y) };

            g.FillPolygon(tmpBrush, tmp_array);
            g.DrawPolygon(tmpPen, tmp_array);
        }

        // Метод для создания копии объекта фигуры
        public override GeneralTool Clone()
        {
            return (Trapeze)this.MemberwiseClone();
        }
    }
}
