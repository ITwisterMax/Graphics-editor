using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Graphics_Editor
{
    // Прямоугольник
    public class Rectangle : GeneralTool
    {
        // Конструктор
        public Rectangle(PictureBox backGround, Color penColor, int penWidth, Color brushColor) : base(backGround)
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
                        if ((point2.X >= point1.X) && (point2.Y >= point1.Y))
                        {
                            graphics.FillRectangle(currBrush, point1.X, point1.Y,
                            point2.X - point1.X, point2.Y - point1.Y);
                            graphics.DrawRectangle(currPen, point1.X, point1.Y,
                            point2.X - point1.X, point2.Y - point1.Y);
                        }
                        else if ((point2.X > point1.X) && (point2.Y < point1.Y))
                        {
                            graphics.FillRectangle(currBrush, point1.X, point2.Y,
                            point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
                            graphics.DrawRectangle(currPen, point1.X, point2.Y,
                            point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
                        }
                        else if ((point2.X < point1.X) && (point2.Y > point1.Y))
                        {
                            graphics.FillRectangle(currBrush, point2.X, point1.Y,
                            Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
                            graphics.DrawRectangle(currPen, point2.X, point1.Y,
                            Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
                        }
                        else if ((point2.X < point1.X) && (point2.Y < point1.Y))
                        {
                            graphics.FillRectangle(currBrush, point2.X, point2.Y,
                            Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
                            graphics.DrawRectangle(currPen, point2.X, point2.Y,
                            Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
                        }
                        isEnd = true;
                        tmpPenWidth = penWidth;
                        tmpPenColor = penColor;
                        tmpBrushColor = brushColor;
                        this.point1 = point1;
                        this.point2 = point2;
                    }
                else
                {
                    if ((point2.X >= point1.X) && (point2.Y >= point1.Y))
                    {
                        g.FillRectangle(currBrush, point1.X, point1.Y,
                        point2.X - point1.X, point2.Y - point1.Y);
                        g.DrawRectangle(currPen, point1.X, point1.Y,
                        point2.X - point1.X, point2.Y - point1.Y);
                    }
                    else if ((point2.X > point1.X) && (point2.Y < point1.Y))
                    {
                        g.FillRectangle(currBrush, point1.X, point2.Y,
                        point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
                        g.DrawRectangle(currPen, point1.X, point2.Y,
                        point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
                    }
                    else if ((point2.X < point1.X) && (point2.Y > point1.Y))
                    {
                        g.FillRectangle(currBrush, point2.X, point1.Y,
                        Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
                        g.DrawRectangle(currPen, point2.X, point1.Y,
                        Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
                    }
                    else if ((point2.X < point1.X) && (point2.Y < point1.Y))
                    {
                        g.FillRectangle(currBrush, point2.X, point2.Y,
                        Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
                        g.DrawRectangle(currPen, point2.X, point2.Y,
                        Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
                    }
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

            if ((point2.X >= point1.X) && (point2.Y >= point1.Y))
            {
                g.FillRectangle(tmpBrush, point1.X, point1.Y,
                point2.X - point1.X, point2.Y - point1.Y);
                g.DrawRectangle(tmpPen, point1.X, point1.Y,
                point2.X - point1.X, point2.Y - point1.Y);
            }
            else if ((point2.X > point1.X) && (point2.Y < point1.Y))
            {
                g.FillRectangle(tmpBrush, point1.X, point2.Y,
                point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
                g.DrawRectangle(tmpPen, point1.X, point2.Y,
                point2.X - point1.X, Math.Abs(point2.Y - point1.Y));
            }
            else if ((point2.X < point1.X) && (point2.Y > point1.Y))
            {
                g.FillRectangle(tmpBrush, point2.X, point1.Y,
                Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
                g.DrawRectangle(tmpPen, point2.X, point1.Y,
                Math.Abs(point2.X - point1.X), point2.Y - point1.Y);
            }
            else if ((point2.X < point1.X) && (point2.Y < point1.Y))
            {
                g.FillRectangle(tmpBrush, point2.X, point2.Y,
                Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
                g.DrawRectangle(tmpPen, point2.X, point2.Y,
                Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y));
            }
        }

        // Метод для создания копии объекта фигуры
        public override GeneralTool Clone()
        {
            return (Rectangle)this.MemberwiseClone();
        }
    }
}
