namespace Graphics_Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Files = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Serialize = new System.Windows.Forms.ToolStripMenuItem();
            this.Deserialize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitFromProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.Line2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Rectangle2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Ellipse2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Polygon2 = new System.Windows.Forms.ToolStripMenuItem();
            this.BrokenLine2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Window = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.Header2 = new System.Windows.Forms.ToolStripLabel();
            this.Line1 = new System.Windows.Forms.ToolStripButton();
            this.Rectangle1 = new System.Windows.Forms.ToolStripButton();
            this.Ellipse1 = new System.Windows.Forms.ToolStripButton();
            this.Polygon1 = new System.Windows.Forms.ToolStripButton();
            this.BrokenLine1 = new System.Windows.Forms.ToolStripButton();
            this.Temp = new System.Windows.Forms.ToolStripLabel();
            this.Header3 = new System.Windows.Forms.ToolStripLabel();
            this.ChooseColor = new System.Windows.Forms.ColorDialog();
            this.Pictures = new System.Windows.Forms.PictureBox();
            this.MainMenu.SuspendLayout();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pictures)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Files,
            this.Tools,
            this.Window,
            this.pluginsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(1262, 28);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // Files
            // 
            this.Files.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFile,
            this.OpenFile,
            this.toolStripSeparator2,
            this.FileSave,
            this.Serialize,
            this.Deserialize,
            this.toolStripSeparator1,
            this.CloseFile,
            this.ExitFromProgram});
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(46, 24);
            this.Files.Text = "&File";
            // 
            // NewFile
            // 
            this.NewFile.Image = ((System.Drawing.Image)(resources.GetObject("NewFile.Image")));
            this.NewFile.Name = "NewFile";
            this.NewFile.Size = new System.Drawing.Size(165, 26);
            this.NewFile.Text = "&New";
            this.NewFile.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("OpenFile.Image")));
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(165, 26);
            this.OpenFile.Text = "&Open";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // FileSave
            // 
            this.FileSave.Image = ((System.Drawing.Image)(resources.GetObject("FileSave.Image")));
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(165, 26);
            this.FileSave.Text = "&Save";
            this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // Serialize
            // 
            this.Serialize.Image = ((System.Drawing.Image)(resources.GetObject("Serialize.Image")));
            this.Serialize.Name = "Serialize";
            this.Serialize.Size = new System.Drawing.Size(165, 26);
            this.Serialize.Text = "&Serialize";
            this.Serialize.Click += new System.EventHandler(this.Serialize_Click);
            // 
            // Deserialize
            // 
            this.Deserialize.Image = ((System.Drawing.Image)(resources.GetObject("Deserialize.Image")));
            this.Deserialize.Name = "Deserialize";
            this.Deserialize.Size = new System.Drawing.Size(165, 26);
            this.Deserialize.Text = "&Deserialize";
            this.Deserialize.Click += new System.EventHandler(this.Deserialize_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // CloseFile
            // 
            this.CloseFile.Image = ((System.Drawing.Image)(resources.GetObject("CloseFile.Image")));
            this.CloseFile.Name = "CloseFile";
            this.CloseFile.Size = new System.Drawing.Size(165, 26);
            this.CloseFile.Text = "&Close";
            this.CloseFile.Click += new System.EventHandler(this.CloseFile_Click);
            // 
            // ExitFromProgram
            // 
            this.ExitFromProgram.Image = ((System.Drawing.Image)(resources.GetObject("ExitFromProgram.Image")));
            this.ExitFromProgram.Name = "ExitFromProgram";
            this.ExitFromProgram.Size = new System.Drawing.Size(165, 26);
            this.ExitFromProgram.Text = "&Exit";
            this.ExitFromProgram.Click += new System.EventHandler(this.ExitFromProgram_Click);
            // 
            // Tools
            // 
            this.Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Line2,
            this.Rectangle2,
            this.Ellipse2,
            this.Polygon2,
            this.BrokenLine2,
            this.toolStripSeparator4,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(58, 24);
            this.Tools.Text = "&Tools";
            // 
            // Line2
            // 
            this.Line2.Image = ((System.Drawing.Image)(resources.GetObject("Line2.Image")));
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(166, 26);
            this.Line2.Text = "&Line";
            this.Line2.Click += new System.EventHandler(this.Line2_Click);
            // 
            // Rectangle2
            // 
            this.Rectangle2.Image = ((System.Drawing.Image)(resources.GetObject("Rectangle2.Image")));
            this.Rectangle2.Name = "Rectangle2";
            this.Rectangle2.Size = new System.Drawing.Size(166, 26);
            this.Rectangle2.Text = "&Rectangle";
            this.Rectangle2.Click += new System.EventHandler(this.Rectangle2_Click);
            // 
            // Ellipse2
            // 
            this.Ellipse2.Image = ((System.Drawing.Image)(resources.GetObject("Ellipse2.Image")));
            this.Ellipse2.Name = "Ellipse2";
            this.Ellipse2.Size = new System.Drawing.Size(166, 26);
            this.Ellipse2.Text = "&Ellipse";
            this.Ellipse2.Click += new System.EventHandler(this.Ellipse2_Click);
            // 
            // Polygon2
            // 
            this.Polygon2.Image = ((System.Drawing.Image)(resources.GetObject("Polygon2.Image")));
            this.Polygon2.Name = "Polygon2";
            this.Polygon2.Size = new System.Drawing.Size(166, 26);
            this.Polygon2.Text = "&Polygon";
            this.Polygon2.Click += new System.EventHandler(this.Polygon2_Click);
            // 
            // BrokenLine2
            // 
            this.BrokenLine2.Image = ((System.Drawing.Image)(resources.GetObject("BrokenLine2.Image")));
            this.BrokenLine2.Name = "BrokenLine2";
            this.BrokenLine2.Size = new System.Drawing.Size(166, 26);
            this.BrokenLine2.Text = "&Broken line";
            this.BrokenLine2.Click += new System.EventHandler(this.BrokenLine2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(163, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // Window
            // 
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(78, 24);
            this.Window.Text = "&Window";
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadPlugins});
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.pluginsToolStripMenuItem.Text = "&Plugins";
            // 
            // LoadPlugins
            // 
            this.LoadPlugins.Image = global::Graphics_Editor.Properties.Resources.Load;
            this.LoadPlugins.Name = "LoadPlugins";
            this.LoadPlugins.Size = new System.Drawing.Size(125, 26);
            this.LoadPlugins.Text = "&Load";
            this.LoadPlugins.Click += new System.EventHandler(this.LoadPlugins_Click);
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.White;
            this.ToolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Header2,
            this.Line1,
            this.Rectangle1,
            this.Ellipse1,
            this.Polygon1,
            this.BrokenLine1,
            this.Temp,
            this.Header3});
            this.ToolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolBar.Location = new System.Drawing.Point(0, 28);
            this.ToolBar.MinimumSize = new System.Drawing.Size(80, 695);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToolBar.Size = new System.Drawing.Size(111, 695);
            this.ToolBar.Stretch = true;
            this.ToolBar.TabIndex = 1;
            this.ToolBar.Text = "ToolBar";
            this.ToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolBar_ItemClicked);
            // 
            // Header2
            // 
            this.Header2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Header2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Header2.Image = ((System.Drawing.Image)(resources.GetObject("Header2.Image")));
            this.Header2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Header2.Name = "Header2";
            this.Header2.Size = new System.Drawing.Size(64, 20);
            this.Header2.Text = "Figures:";
            // 
            // Line1
            // 
            this.Line1.Image = ((System.Drawing.Image)(resources.GetObject("Line1.Image")));
            this.Line1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(60, 24);
            this.Line1.Text = "Line";
            this.Line1.Click += new System.EventHandler(this.Line1_Click);
            // 
            // Rectangle1
            // 
            this.Rectangle1.Image = ((System.Drawing.Image)(resources.GetObject("Rectangle1.Image")));
            this.Rectangle1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rectangle1.Name = "Rectangle1";
            this.Rectangle1.Size = new System.Drawing.Size(99, 24);
            this.Rectangle1.Text = "Rectangle";
            this.Rectangle1.Click += new System.EventHandler(this.Rectangle1_Click);
            // 
            // Ellipse1
            // 
            this.Ellipse1.Image = ((System.Drawing.Image)(resources.GetObject("Ellipse1.Image")));
            this.Ellipse1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ellipse1.Name = "Ellipse1";
            this.Ellipse1.Size = new System.Drawing.Size(76, 24);
            this.Ellipse1.Text = "Ellipse";
            this.Ellipse1.Click += new System.EventHandler(this.Ellipse1_Click);
            // 
            // Polygon1
            // 
            this.Polygon1.Image = ((System.Drawing.Image)(resources.GetObject("Polygon1.Image")));
            this.Polygon1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Polygon1.Name = "Polygon1";
            this.Polygon1.Size = new System.Drawing.Size(86, 24);
            this.Polygon1.Text = "Polygon";
            this.Polygon1.Click += new System.EventHandler(this.Polygon1_Click);
            // 
            // BrokenLine1
            // 
            this.BrokenLine1.Image = ((System.Drawing.Image)(resources.GetObject("BrokenLine1.Image")));
            this.BrokenLine1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BrokenLine1.Name = "BrokenLine1";
            this.BrokenLine1.Size = new System.Drawing.Size(107, 24);
            this.BrokenLine1.Text = "Broken line";
            this.BrokenLine1.Click += new System.EventHandler(this.BrokenLine1_Click);
            // 
            // Temp
            // 
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(105, 20);
            this.Temp.Text = "                        ";
            // 
            // Header3
            // 
            this.Header3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Header3.Name = "Header3";
            this.Header3.Size = new System.Drawing.Size(93, 20);
            this.Header3.Text = "Parameters:";
            // 
            // Pictures
            // 
            this.Pictures.Image = ((System.Drawing.Image)(resources.GetObject("Pictures.Image")));
            this.Pictures.Location = new System.Drawing.Point(1230, 40);
            this.Pictures.Name = "Pictures";
            this.Pictures.Size = new System.Drawing.Size(20, 22);
            this.Pictures.TabIndex = 3;
            this.Pictures.TabStop = false;
            this.Pictures.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Pictures);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Graphics Editor";
            this.Load += new System.EventHandler(this.StartWork);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pictures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ColorDialog ChooseColor;
        private System.Windows.Forms.ToolStripButton Line1;
        private System.Windows.Forms.ToolStripButton Rectangle1;
        private System.Windows.Forms.ToolStripButton Ellipse1;
        private System.Windows.Forms.ToolStripButton Polygon1;
        private System.Windows.Forms.ToolStripLabel Header2;
        private System.Windows.Forms.ToolStripMenuItem Files;
        private System.Windows.Forms.ToolStripMenuItem NewFile;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseFile;
        private System.Windows.Forms.ToolStripMenuItem ExitFromProgram;
        private System.Windows.Forms.ToolStripMenuItem Tools;
        private System.Windows.Forms.ToolStripMenuItem Line2;
        private System.Windows.Forms.ToolStripMenuItem Rectangle2;
        private System.Windows.Forms.ToolStripMenuItem Ellipse2;
        private System.Windows.Forms.ToolStripMenuItem Polygon2;
        private System.Windows.Forms.ToolStripMenuItem Window;
        private System.Windows.Forms.ToolStripLabel Header3;
        private System.Windows.Forms.ToolStripLabel Temp;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrokenLine2;
        private System.Windows.Forms.ToolStripButton BrokenLine1;
        private System.Windows.Forms.ToolStripMenuItem Serialize;
        private System.Windows.Forms.ToolStripMenuItem Deserialize;
        private System.Windows.Forms.ToolStripMenuItem FileSave;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadPlugins;
        private System.Windows.Forms.PictureBox Pictures;
    }
}

