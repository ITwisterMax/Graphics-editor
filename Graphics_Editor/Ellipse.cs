using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Graphics_Editor
{
    // Эллипс
    public class Ellipse : GeneralTool
    {
        // Конструктор
        public Ellipse(PictureBox backGround, Color penColor, int penWidth, Color brushColor) : base(backGround)
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

                // Проверка на то, можно ли рисовать
                if (!canWrite)
                    using (var graphics = Graphics.FromImage(backGround.Image))
                    {
                        // Отрисовка эллипса
                        graphics.FillEllipse(currBrush, point1.X, point1.Y,
                        point2.X - point1.X, point2.Y - point1.Y);
                        graphics.DrawEllipse(currPen, point1.X, point1.Y,
                        point2.X - point1.X, point2.Y - point1.Y);
                        isEnd = true;
                        tmpPenWidth = penWidth;
                        tmpPenColor = penColor;
                        tmpBrushColor = brushColor;
                        this.point1 = point1;
                        this.point2 = point2;
                    }
                else
                {
                    // Отрисовка эллипса
                    g.FillEllipse(currBrush, point1.X, point1.Y,
                    point2.X - point1.X, point2.Y - point1.Y);
                    g.DrawEllipse(currPen, point1.X, point1.Y,
                    point2.X - point1.X, point2.Y - point1.Y);
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

            g.FillEllipse(tmpBrush, point1.X, point1.Y,
            point2.X - point1.X, point2.Y - point1.Y);
            g.DrawEllipse(tmpPen, point1.X, point1.Y,
            point2.X - point1.X, point2.Y - point1.Y);
        }

        // Метод для создания копии объекта фигуры
        public override GeneralTool Clone()
        {
            return (Ellipse)this.MemberwiseClone();
        }
    }
}
