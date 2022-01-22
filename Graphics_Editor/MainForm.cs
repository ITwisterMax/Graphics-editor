using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Graphics_Editor
{
    // Форма
    public partial class MainForm : Form
    {
        // Стартовая вкладка
        private DrawPlace newBitmap;
        // Уникальный индекс новой вкладки
        private int count = 0;
        // Список файлов
        private StringDictionary filesName;
        // Фильтр файлов
        private String filter = @" File jpg (*.jpg)|*.jpg| File png (*.png)|*.png| File bmp (*.bmp)|*.bmp";
        // Толщина кисти
        private NumericUpDown penWidth;
        // Количество углов
        private NumericUpDown angleCount;
        // Выбор цвета (верхний)
        private PictureBox pictureBoxUp;
        // Выбор цвета (нижний)
        private PictureBox pictureBoxDown;
        // Инструмент рисования
        private GeneralTool tool;
        // Список фигур
        public static Dictionary<int, Shapes> shapesList = new Dictionary<int, Shapes>();
        // Список плагинов
        public static Dictionary<int, Type> pluginsList = new Dictionary<int, Type>();
        // Начальное смещение плагинов в списке, их количество и номер текущего плагина
        private int plugins_start;
        private int plugins_count;
        private string curr_plugin;

        // Конструктор формы
        public MainForm()
        {
            InitializeComponent();
        }

        // Задание начальных параметров
        private void StartWork(object sender, EventArgs e)
        {  
            // Создание новой вкладки для рисования
            newBitmap = new DrawPlace();
            newBitmap.MdiParent = this;
            newBitmap.Show();
            newBitmap.Name = Convert.ToString(count);
            newBitmap.Text = "New file";
            newBitmap.Location = new Point(0, 0);
            shapesList[Convert.ToInt32(newBitmap.Name)] = new Shapes();

            // Начальный инструмент для рисования
            tool = new Sector(newBitmap.Controls[0] as PictureBox, Color.Black, 1);
            newBitmap.tool = tool;

            // Добавление новой вкладки в список вкладок
            Window.DropDownItems.Add("New file").Name = Convert.ToString(count);
            (Window.DropDownItems[0] as ToolStripMenuItem).Checked = true;

            // Добавление новой вкладки в список файлов
            filesName = new StringDictionary();
            filesName.Add(newBitmap.Name, "NewFile");
            count++;

            // Добавление метода для переключения вкладок
            Window.DropDownItemClicked += Window_Click;
            
            // Создание надписи на боковой панеле ToolBar
            var pen_width_header = new Label();
            var tmp_tool1 = new ToolStripControlHost(pen_width_header);
            ToolBar.Items.Add(tmp_tool1);
            ToolBar.Items[8].Name = "PenWidthHeader";
            ToolBar.Items[8].Text = "- Pen width:";

            // Создание элемента для выбора толщины кисти
            penWidth = new NumericUpDown();
            penWidth.ValueChanged += OnValueChanged;
            penWidth.Value = 1;
            penWidth.Minimum = 1;
            penWidth.Maximum = 100;
            var tmp_tool2 = new ToolStripControlHost(penWidth);
            ToolBar.Items.Add(tmp_tool2);
            ToolBar.Items[9].Name = "PenWidth";
            ToolBar.Items[9].Margin = new Padding(4, 0, 0, 0);
            ToolBar.Items[9].AutoSize = false;
            ToolBar.Items[9].Size = new Size(90, 30);

            // Создание надписи на боковой панеле ToolBar
            var angle_count_header = new Label();
            var tmp_tool3 = new ToolStripControlHost(angle_count_header);
            ToolBar.Items.Add(tmp_tool3);
            ToolBar.Items[10].Name = "AngleCountHeader";
            ToolBar.Items[10].Text = "- Angle count:";

            // Создание элемента для выбора количества углов
            angleCount = new NumericUpDown();
            angleCount.ValueChanged += OnCountChanged;
            angleCount.Value = 3;
            angleCount.Minimum = 3;
            angleCount.Maximum = 100;
            var tmp_tool4 = new ToolStripControlHost(angleCount);
            ToolBar.Items.Add(tmp_tool4);
            ToolBar.Items[11].Name = "AngleCount";
            ToolBar.Items[11].Margin = new Padding(4, 0, 0, 0);
            ToolBar.Items[11].AutoSize = false;
            ToolBar.Items[11].Size = new Size(90, 30);

            // Создание надписи на боковой панеле ToolBar
            var pen_color_header = new Label();
            var tmp_tool5 = new ToolStripControlHost(pen_color_header);
            ToolBar.Items.Add(tmp_tool5);
            ToolBar.Items[12].Name = "PenColorHeader";
            ToolBar.Items[12].Text = "- Pen color:";
            ToolBar.Items[12].Margin = new Padding(0, 6, 0, 0);

            // Создание элемента для выбора цвета (верхний)
            pictureBoxUp = new PictureBox();
            pictureBoxUp.Size = new System.Drawing.Size(90, 25);
            pictureBoxUp.Click += OnClickPictureBoxUp;
            var imageup = new Bitmap(pictureBoxUp.Width, pictureBoxUp.Height);
            pictureBoxUp.Image = imageup;
            pictureBoxUp.BackColor = Color.Black;
            using (var graphics = Graphics.FromImage(imageup))
                graphics.Clear(Color.Black);
            var pictureup = new ToolStripControlHost(pictureBoxUp);
            ToolBar.Items.Add(pictureup);
            ToolBar.Items[13].Margin = new Padding(4, 4, 0, 0);
            ToolBar.Items[13].Name = "Pictureup";

            // Создание надписи на боковой панеле ToolBar
            var brush_color_header = new Label();
            var tmp_tool6 = new ToolStripControlHost(brush_color_header);
            ToolBar.Items.Add(tmp_tool6);
            ToolBar.Items[14].Name = "BrushColorHeader";
            ToolBar.Items[14].Text = "- Brush color:";
            ToolBar.Items[14].Margin = new Padding(0, 8, 0, 0);

            // Создание элемента для выбора цвета (нижний)
            pictureBoxDown = new PictureBox();
            pictureBoxDown.Click += OnClickPictureBoxDown;
            pictureBoxDown.Size = new System.Drawing.Size(90, 25);
            var imagedown = new Bitmap(pictureBoxDown.Width, pictureBoxDown.Height);
            pictureBoxDown.Image = imagedown;
            pictureBoxDown.BackColor = Color.Black;
            using (var graphics = Graphics.FromImage(imagedown))
                graphics.Clear(Color.Black);
            var picturedown = new ToolStripControlHost(pictureBoxDown);
            ToolBar.Items.Add(picturedown);
            ToolBar.Items[15].Name = "Picturedown";
            ToolBar.Items[15].Margin = new Padding(4, 4, 0, 0);

            // Создание отступа
            var header = new Label();
            var tmp_tool7 = new ToolStripControlHost(header);
            ToolBar.Items.Add(tmp_tool7);
            ToolBar.Items[16].Name = "Header";
            ToolBar.Items[16].Text = "                        ";

            // Создание надписи на боковой панеле ToolBar
            var plugins_header = new Label();
            var tmp_tool8 = new ToolStripControlHost(plugins_header);
            ToolBar.Items.Add(tmp_tool8);
            ToolBar.Items[17].Name = "PluginsHeader";
            ToolBar.Items[17].Text = "Plugins:";
            ToolBar.Items[17].Font = new Font("Segoe UI", 9, FontStyle.Bold);
            
            // Начальное смещение плагинов в списке и их количество
            plugins_start = 18;
            plugins_count = 0;

            // Каскадное отображение вкладок для рисования
            LayoutMdi(MdiLayout.Cascade);
        }

        // Создать новый файл
        private void NewFile_Click(object sender, EventArgs e)
        {
            // Создание новой вкладки для рисования
            var new_bitmap = new DrawPlace();
            new_bitmap.MdiParent = this;
            new_bitmap.Show();
            new_bitmap.Name = Convert.ToString(count);
            new_bitmap.Text = "New file";
            shapesList[Convert.ToInt32(new_bitmap.Name)] = new Shapes();

            // Начальный инструмент для рисования
            tool = new Sector(new_bitmap.Controls[0] as PictureBox, Color.Black, 1);
            new_bitmap.tool = tool;

            // Добавление новой вкладки в список вкладок
            Window.DropDownItems.Add("New file").Name = Convert.ToString(count);
            for (int i = 0; i < Window.DropDownItems.Count; i++)
                (Window.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            (Window.DropDownItems[Window.DropDownItems.Count - 1] as ToolStripMenuItem).Checked = true;

            // Добавление новой вкладки в список файлов
            filesName.Add(new_bitmap.Name, "NewFile");
            count++;
        }

        // Открыть файл
        private void OpenFile_Click(object sender, EventArgs e)
        {
            // Установка начальных значений для диалогового окна
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Filter = filter;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получение пути к файлу
                var filename = openFileDialog.FileName;
                var OpenBitmap = new Bitmap(filename);

                // Создание новой вкладки
                var new_bitmap = new DrawPlace();
                new_bitmap.MdiParent = this;
                new_bitmap.Show();
                new_bitmap.Name = Convert.ToString(count);
                new_bitmap.Text = filename;
                new_bitmap.Height = OpenBitmap.Height;
                new_bitmap.Width = OpenBitmap.Width;
                shapesList[Convert.ToInt32(new_bitmap.Name)] = new Shapes();

                // Начальный инструмент для рисования
                tool = new Sector(new_bitmap.Controls[0] as PictureBox, Color.Black, 1);
                new_bitmap.tool = tool;

                // Добавление новой вкладки в список вкладок
                Window.DropDownItems.Add(filename).Name = Convert.ToString(count);
                for (int i = 0; i < Window.DropDownItems.Count; i++)
                    (Window.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                (Window.DropDownItems[Window.DropDownItems.Count - 1] as ToolStripMenuItem).Checked = true;

                // Добавление новой вкладки в список файлов
                filesName.Add(new_bitmap.Name, filename);
                count++;
                (ActiveMdiChild as DrawPlace).currImage = OpenBitmap;
            }
        }

        // Сохранить файл как
        private void FileSave_Click(object sender, EventArgs e)
        {
            // Установка начальных значений для диалогового окна
            var saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = filter;
            saveFileAs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            
            if (saveFileAs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получение пути к файлу
                string filename = saveFileAs.FileName;

                // Сохранение картинки
                if ((ActiveMdiChild as DrawPlace).currImage != null)
                    (ActiveMdiChild as DrawPlace).currImage.Save(filename);

                // Изменение текста вкладки
                ActiveMdiChild.Text = filename;
                // Изменение текста вкладки в списке файлов
                filesName[ActiveMdiChild.Name] = filename;
            }
        }

        // JSON-cериализация
        private void Serialize_Click(object sender, EventArgs e)
        {
            // Установка начальных значений для диалогового окна
            var saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = @"File json (*.json)|*.json";
            saveFileAs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileAs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получение пути к файлу
                string filename = saveFileAs.FileName;

                try
                {
                    // Сама сериализация
                    var currShape = shapesList[Convert.ToInt32((ActiveMdiChild as DrawPlace).Name)].shapesList;

                    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
                    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

                    using (StreamWriter sw = new StreamWriter(filename))
                    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, currShape);
                    }
                    (ActiveMdiChild as DrawPlace).Text = filename;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }
        }

        // JSON-деcериализация
        private void Deserialize_Click(object sender, EventArgs e)
        {
            // Установка начальных значений для диалогового окна
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = @"File json (*.json)|*.json";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получение пути к файлу
                var filename = openFileDialog.FileName;

                // Создание новой вкладки для рисования
                var new_bitmap = new DrawPlace();
                new_bitmap.MdiParent = this;
                new_bitmap.Show();
                new_bitmap.Name = Convert.ToString(count);
                new_bitmap.Text = filename;
                shapesList[Convert.ToInt32(new_bitmap.Name)] = new Shapes();

                // Начальный инструмент для рисования
                tool = new Sector(new_bitmap.Controls[0] as PictureBox, Color.Black, 1);
                new_bitmap.tool = tool;

                // Добавление новой вкладки в список вкладок
                Window.DropDownItems.Add("New file").Name = Convert.ToString(count);
                for (int i = 0; i < Window.DropDownItems.Count; i++)
                    (Window.DropDownItems[i] as ToolStripMenuItem).Checked = false;
                (Window.DropDownItems[Window.DropDownItems.Count - 1] as ToolStripMenuItem).Checked = true;

                // Добавление новой вкладки в список файлов
                filesName.Add(new_bitmap.Name, "NewFile");
                count++;

                try
                {
                    // Сама десериализация
                    var currShape = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, GeneralTool>>(File.ReadAllText(filename), new Newtonsoft.Json.JsonSerializerSettings
                    {
                        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    });
                    foreach (KeyValuePair<int, GeneralTool> pair in currShape)
                    {
                        shapesList[Convert.ToInt32(new_bitmap.Name)].Add(pair.Value);
                        pair.Value.reDraw(Graphics.FromImage((ActiveMdiChild as DrawPlace).currImage));
                    }
                    (ActiveMdiChild as DrawPlace).Refresh();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        // Закрыть файл
        private void CloseFile_Click(object sender, EventArgs e)
        {
            // Удаление вкладки из списка вкладок
            for (int i = 0; i < Window.DropDownItems.Count; i++)
                if (Window.DropDownItems[i].Name == ActiveMdiChild.Name)
                {
                    Window.DropDownItems[i].Dispose();
                    break;
                }

            // Удаление вкладки из списка файлов
            if (filesName.ContainsKey(ActiveMdiChild.Name))
                filesName.Remove(ActiveMdiChild.Name);

            // Закрытие вкладки
            ActiveMdiChild.Close();

            if (MdiChildren.Length > 0)
            {
                // Установка фокуса на вкладку
                (Window.DropDownItems[Window.DropDownItems.Count - 1] as ToolStripMenuItem).Checked = true;
                MdiChildren[MdiChildren.Length - 1].Activate();
            }
        }

        // Выйти из программы
        private void ExitFromProgram_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Переключение между вкладками
        private void Window_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            // Снятие галочек с вкладок
            for (int i = 0; i < Window.DropDownItems.Count; i++)
            {
                (Window.DropDownItems[i] as ToolStripMenuItem).Checked = false;
            }

            // Установка галочки на вкладку
            var item = (e.ClickedItem as ToolStripMenuItem).Checked;
            if (item != true)
                (e.ClickedItem as ToolStripMenuItem).Checked = true;

            // Установка фокуса на вкладку
            for (int j = 0; j < MdiChildren.Length; j++)
            {
                if (MdiChildren[j].Name == e.ClickedItem.Name)
                    MdiChildren[j].Activate();
            }
        }

        // Изменение толщины кисти
        protected void OnValueChanged(object sender, EventArgs e)
        {
            tool.penWidth = (int)penWidth.Value;
        }

        // Изменение количества углов
        protected void OnCountChanged(object sender, EventArgs e)
        {
            tool.angleCount = (int)angleCount.Value;
        }

        // Изменение цвета кисти
        private void OnClickPictureBoxUp(object sender, EventArgs e)
        {
            if (ChooseColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                using (var graphics = Graphics.FromImage(pictureBoxUp.Image))
                {
                    graphics.Clear(ChooseColor.Color);
                    pictureBoxUp.Invalidate();
                    pictureBoxUp.BackColor = ChooseColor.Color;
                    tool.penColor = ChooseColor.Color;
                }
        }

        // Изменение цвета заливки
        private void OnClickPictureBoxDown(object sender, EventArgs e)
        {
            if (ChooseColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                using (var graphics = Graphics.FromImage(pictureBoxDown.Image))
                {
                    graphics.Clear(ChooseColor.Color);
                    pictureBoxDown.Invalidate();
                    pictureBoxDown.BackColor = ChooseColor.Color;
                    tool.brushColor = ChooseColor.Color;
                }
        }

        // Рисование линии
        private void Line1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Sector((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor, (int)penWidth.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование линии
        private void Line2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Sector((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor, (int)penWidth.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование прямоугольника
        private void Rectangle1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Rectangle((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование прямоугольника
        private void Rectangle2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Rectangle((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование эллипса
        private void Ellipse1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Ellipse((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование эллипса
        private void Ellipse2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Ellipse((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование правильного многоугольника
        private void Polygon1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Polygon((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor, (int)angleCount.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование многоугольника
        private void Polygon2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new Polygon((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor, (int)angleCount.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование ломаной
        private void BrokenLine1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new BrokenLine((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, (int)angleCount.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Рисование ломаной
        private void BrokenLine2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = new BrokenLine((ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, (int)angleCount.Value);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }
        }

        // Отмена
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currShape = shapesList[Convert.ToInt32((ActiveMdiChild as DrawPlace).Name)];
            currShape.Undo();
            currShape.Draw(Graphics.FromImage((ActiveMdiChild as DrawPlace).currImage));
            (ActiveMdiChild as DrawPlace).Refresh();
        }

        // Возврат
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currShape = shapesList[Convert.ToInt32((ActiveMdiChild as DrawPlace).Name)];
            currShape.Redo();
            currShape.Draw(Graphics.FromImage((ActiveMdiChild as DrawPlace).currImage));
            (ActiveMdiChild as DrawPlace).Refresh();
        }

        // Загрузка плагина
        private void LoadPlugins_Click(object sender, EventArgs e)
        {
            // Установка начальных значений для диалогового окна
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = @"File dll (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Получение пути к файлу
                var filename = openFileDialog.FileName;

                try
                {
                    // Получение экземпляра плагина
                    Assembly asm = Assembly.LoadFrom(filename);
                    Type plugin_type = asm.GetTypes()[0];
                    pluginsList[plugins_count] = plugin_type;

                    // Создание надписи на боковой панеле ToolBar
                    var curr_plugin = new ToolStripButton();
                    ToolBar.Items.Add(curr_plugin);
                    ToolBar.Items[plugins_start + plugins_count].Name = Convert.ToString(plugins_count);
                    ToolBar.Items[plugins_start + plugins_count].Text = plugin_type.Name;
                    ToolBar.Items[plugins_start + plugins_count].Image = Pictures.Image;
                    ToolBar.Items[plugins_start + plugins_count].Click += OnPluginClick;

                    // Увеличение количества плагинов
                    plugins_count++;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        // Нажатие на плагин
        protected void OnPluginClick(object sender, EventArgs e)
        {
            try
            {
                if (MdiChildren.Length > 0)
                {
                    tool = (GeneralTool)Activator.CreateInstance(pluginsList[Convert.ToInt32(curr_plugin)], (ActiveMdiChild as DrawPlace).Controls[0] as PictureBox, pictureBoxUp.BackColor,
                    (int)penWidth.Value, pictureBoxDown.BackColor);
                    (ActiveMdiChild as DrawPlace).tool = tool;
                }
            }
            catch
            {

            }     
        }

        // Определение номера нажатого плагина
        private void ToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            curr_plugin = e.ClickedItem.Name;
        }
    } 
}
