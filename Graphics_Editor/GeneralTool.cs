using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graphics_Editor
{
    // Установка координат
    public struct TwoPoints
    {
        public Point point1;
        public Point point2;

        public TwoPoints(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
    }

    public abstract class GeneralTool
    {
        // Фон
        protected PictureBox backGround;
        // Можно ли рисовать
        public static bool canWrite = false;

        // Толщина кисти
        public int penWidth { get; set; }

        // Количество углов
        public int angleCount { get; set; }

        // Массив точек
        public List<TwoPoints> tmpList;

        // Цвета кисти и заливки
        public Color penColor { get; set; }
        public Color brushColor { get; set; }

        // Запомненная кисть и заливка
        public int tmpPenWidth { get; set; }
        public Color tmpPenColor { get; set; }
        public Color tmpBrushColor { get; set; }

        // Точки для фигуры
        public Point point1 { get; set; }
        public Point point2 { get; set; }

        // Проверка на конец рисования фигуры
        public static bool isEnd;

        // Конструктор
        public GeneralTool(PictureBox backGround)
        {
            this.backGround = backGround;
        }

        // Метод для рисования
        public abstract void Draw(Point point1, Point point2, Graphics g = null);

        // Метод для перерисовки
        public abstract void reDraw(Graphics g = null);

        // Метод для создания копии объекта фигуры
        public abstract GeneralTool Clone();
    }
}
