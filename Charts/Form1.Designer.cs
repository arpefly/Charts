
namespace Charts
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelXScale = new System.Windows.Forms.Label();
            this.labelYScale = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonStartCalc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(761, 505);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(683, 520);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(56, 13);
            this.labelScale.TabIndex = 1;
            this.labelScale.Text = "Масштаб:";
            // 
            // labelXScale
            // 
            this.labelXScale.AutoSize = true;
            this.labelXScale.Location = new System.Drawing.Point(745, 520);
            this.labelXScale.Name = "labelXScale";
            this.labelXScale.Size = new System.Drawing.Size(32, 13);
            this.labelXScale.TabIndex = 2;
            this.labelXScale.Text = "X 1 : ";
            // 
            // labelYScale
            // 
            this.labelYScale.AutoSize = true;
            this.labelYScale.Location = new System.Drawing.Point(745, 533);
            this.labelYScale.Name = "labelYScale";
            this.labelYScale.Size = new System.Drawing.Size(32, 13);
            this.labelYScale.TabIndex = 2;
            this.labelYScale.Text = "Y 1 : ";
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // buttonStartCalc
            // 
            this.buttonStartCalc.Location = new System.Drawing.Point(12, 523);
            this.buttonStartCalc.Name = "buttonStartCalc";
            this.buttonStartCalc.Size = new System.Drawing.Size(75, 23);
            this.buttonStartCalc.TabIndex = 3;
            this.buttonStartCalc.Text = "Start Calc";
            this.buttonStartCalc.UseVisualStyleBackColor = true;
            this.buttonStartCalc.Click += new System.EventHandler(this.ButtonStartCalc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 562);
            this.Controls.Add(this.buttonStartCalc);
            this.Controls.Add(this.labelYScale);
            this.Controls.Add(this.labelXScale);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label labelXScale;
        private System.Windows.Forms.Label labelYScale;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonStartCalc;
    }
}

