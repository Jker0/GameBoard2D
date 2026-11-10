namespace GameBoard2D
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClearBt = new System.Windows.Forms.Button();
            this.TestBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 843);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // ClearBt
            // 
            this.ClearBt.Location = new System.Drawing.Point(1110, 820);
            this.ClearBt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClearBt.Name = "ClearBt";
            this.ClearBt.Size = new System.Drawing.Size(112, 35);
            this.ClearBt.TabIndex = 1;
            this.ClearBt.Text = "Clear";
            this.ClearBt.UseVisualStyleBackColor = true;
            this.ClearBt.Click += new System.EventHandler(this.ClearBt_Click);
            // 
            // TestBt
            // 
            this.TestBt.Location = new System.Drawing.Point(1110, 749);
            this.TestBt.Name = "TestBt";
            this.TestBt.Size = new System.Drawing.Size(112, 39);
            this.TestBt.TabIndex = 2;
            this.TestBt.Text = "TEST";
            this.TestBt.UseVisualStyleBackColor = true;
            this.TestBt.Click += new System.EventHandler(this.TestBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 890);
            this.Controls.Add(this.TestBt);
            this.Controls.Add(this.ClearBt);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ClearBt;
        private System.Windows.Forms.Button TestBt;
    }
}

