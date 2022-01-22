namespace Graphics_Editor
{
    partial class DrawPlace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // BackGround
            // 
            this.BackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackGround.BackColor = System.Drawing.SystemColors.Control;
            this.BackGround.Cursor = System.Windows.Forms.Cursors.Default;
            this.BackGround.Location = new System.Drawing.Point(0, 0);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(982, 653);
            this.BackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BackGround.TabIndex = 0;
            this.BackGround.TabStop = false;
            this.BackGround.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackGround_MouseDown);
            this.BackGround.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BackGround_MouseMove);
            this.BackGround.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackGround_MouseUp);
            // 
            // DrawPlace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.ControlBox = false;
            this.Controls.Add(this.BackGround);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DrawPlace";
            this.Text = "DrawPlace";
            this.Load += new System.EventHandler(this.DrawPlaceLoad);
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BackGround;
    }
}