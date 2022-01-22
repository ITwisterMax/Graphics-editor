using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graphics_Editor
{
    // Линия
    public class Sector : GeneralTool
    {
        // Конструктор
        public Sector(PictureBox backGround, Color penColor, int penWidth) : base(backGround)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
        }

        // Метод для рисования
        public override void Draw(Point point1, Point point2, Graphics g)
        {
            Pen currPen = null;
            try
            {
                // Устанавливаем текущие параметры кисти
                currPen = new Pen(penColor, penWidth);

                // Проверка на то, можно ли рисовать
                if (!canWrite)
                    using (var graphics = Graphics.FromImage(backGround.Image))
                    {
                        // Отрисовка линии
                        graphics.DrawLine(currPen, point1, point2);
                        isEnd = true;
                        tmpPenWidth = penWidth;
                        tmpPenColor = penColor;
                        this.point1 = point1;
                        this.point2 = point2;
                    }
                else
                {
                    // Отрисовка линии
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
            }
        }

        // Перерисовка фигуры
        public override void reDraw(Graphics g)
        {
            var tmpPen = new Pen(tmpPenColor, tmpPenWidth);

            g.DrawLine(tmpPen, point1, point2);
        }

        // Метод для создания копии объекта фигуры
        public override GeneralTool Clone()
        {
            return (Sector)this.MemberwiseClone();
        }
    }
}
