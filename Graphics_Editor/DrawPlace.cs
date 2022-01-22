using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Editor
{
    // Вкладка для рисования
    public partial class DrawPlace : Form
    {
        // Начальное изображение
        private Bitmap startImage;
        // Начальная и конечная точки
        private Point startPoint;
        private Point endPoint;

        // Конструктор
        public DrawPlace()
        {
            InitializeComponent();
        }

        // Свойства изображения
        public Image currImage
        {
            get { return BackGround.Image; }
            set { BackGround.Image = value; }
        }

        public GeneralTool tool { get; set; }

        // Установка начальных параметров
        private void DrawPlaceLoad(object sender, EventArgs e)
        {
            startImage = new Bitmap(BackGround.Width, BackGround.Height);
            using (var graphics = Graphics.FromImage(startImage))
            {
                graphics.Clear(Color.White);
            }
            BackGround.Image = startImage;
        }

        // Нажатие мыши
        private void BackGround_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GeneralTool.canWrite = true;
                startPoint = e.Location;
                endPoint = startPoint;
                BackGround.Paint += OnPaint;
            }
        }

        // Движение мыши
        private void BackGround_MouseMove(object sender, MouseEventArgs e)
        {
            if (GeneralTool.canWrite)
            {
                endPoint = e.Location;
                BackGround.Invalidate();
            }
        }

        // Отжим мыши
        private void BackGround_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                BackGround.Paint -= OnPaint;
                GeneralTool.canWrite = false;
                tool.Draw(startPoint, endPoint);
                if ((GeneralTool.isEnd) && (startPoint != endPoint))
                {
                    var currShape = MainForm.shapesList[Convert.ToInt32(Name)];
                    currShape.Add(tool);
                    currShape.ResetRedo();
                }
                BackGround.Invalidate();
            }
            catch
            {

            }
        }

        // Отрисовка фигуры
        private void OnPaint(object sender, PaintEventArgs e)
        {
            try
            {
                tool.Draw(startPoint, endPoint, e.Graphics);
            }
            catch
            {

            }
        }
    }
}
