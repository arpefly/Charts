using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace Charts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly int _scaleX = 1; // Масштаб X
        readonly int _scaleY = 1; // Масштаб Y
        int _X0 = 400;   // Центр координат по X
        int _Y0 = 400;   // Центр координат по Y
        readonly bool _isGridShown = true;   // Показывать сетку координат

        double _X;   // Координата X
        double _Y;   // Координата Y
        double _step;    // Шаг счёта

        private Image _buffer;


        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            _X0 = pictureBox.Width / 2;
            _Y0 = pictureBox.Height / 2;

            Pen pen = new Pen(Color.SkyBlue, 1);

            #region Сетка
            if (_isGridShown)
            {
                for (int i = 4; i < pictureBox.Width; i += 4)
                    e.Graphics.DrawLine(pen, i, 1, i, pictureBox.Height - 2);
                for (int i = 4; i < pictureBox.Height; i += 4)
                    e.Graphics.DrawLine(pen, 1, i, pictureBox.Width - 2, i);
            }
            #endregion
            #region Обводка
            pen.Color = Color.Black;
            e.Graphics.DrawLine(pen, 0, 0, pictureBox.Width, 0);
            e.Graphics.DrawLine(pen, pictureBox.Width - 1, 0, pictureBox.Width - 1, pictureBox.Height);
            e.Graphics.DrawLine(pen, 0, 0, 0, pictureBox.Width);
            e.Graphics.DrawLine(pen, 0, pictureBox.Height - 1, pictureBox.Width - 1, pictureBox.Height - 1);
            #endregion
            #region Оси
            e.Graphics.DrawLine(pen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2);
            e.Graphics.DrawLine(pen, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height);
            #endregion
            #region Деления и подписи осей
            // маленькие деления
            for (int i = 0; i < pictureBox.Width; i += 4)   // по горизонтали
                e.Graphics.DrawLine(pen, i, pictureBox.Height / 2 - 2, i, pictureBox.Height / 2 + 2);
            for (int i = 0; i < pictureBox.Height; i += 4)  // по вертикали
                e.Graphics.DrawLine(pen, pictureBox.Width / 2 - 2, i, pictureBox.Width / 2 + 2, i);

            // большие деления
            int count = 1;
            for (int i = pictureBox.Width / 2; i < pictureBox.Width; i += 40)   // справа от центра
            {
                e.Graphics.DrawLine(pen, i, pictureBox.Height / 2 - 4, i, pictureBox.Height / 2 + 4);
                this.Controls.Add(new Label { Text = count++.ToString(), Location = new Point(i + 45, pictureBox.Height / 2 + 25), AutoSize = true });
            }
            count = -1;
            for (int i = pictureBox.Width / 2; i >= 0; i -= 40) // слева от центр
            {
                e.Graphics.DrawLine(pen, i, pictureBox.Height / 2 - 4, i, pictureBox.Height / 2 + 4);
                this.Controls.Add(new Label { Text = count--.ToString(), Location = new Point(i - 35, pictureBox.Height / 2 + 25), AutoSize = true });
            }
            count = -1;
            for (int i = pictureBox.Height / 2; i < pictureBox.Height; i += 40) // снизу от центра
            {
                e.Graphics.DrawLine(pen, pictureBox.Width / 2 - 4, i, pictureBox.Width / 2 + 4, i);
                this.Controls.Add(new Label { Text = count++.ToString(), Location = new Point(pictureBox.Width / 2 + 25, i + 45), AutoSize = true });
            }
            count = 1;
            for (int i = pictureBox.Height / 2; i >= 0; i -= 40)    // сверху от центра
            {
                e.Graphics.DrawLine(pen, pictureBox.Width / 2 - 4, i, pictureBox.Width / 2 + 4, i);
                this.Controls.Add(new Label { Text = count--.ToString(), Location = new Point(pictureBox.Width / 2 + 25, i - 35), AutoSize = true });
            }

            this.Controls.OfType<Label>().ToList().ForEach(label => label.BringToFront());  // Поднять все label нв верх
            #endregion
            #region Посторение графиков
            if (!(_buffer is null))
            {
                e.Graphics.DrawImageUnscaled(_buffer, 0, 0);
            }
            #endregion
        }

        private void DrawToBuffer(Image image)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                _X = -10;
                _step = 0.001;

                for (int i = 1; i < 100000; i++)
                {
                    _Y = Math.Sin(_X) + Math.Cos(_X) + Math.Abs(Math.Sin(_X) * Math.Cos(_X));
                    g.FillRectangle(new SolidBrush(Color.Red), (int)(_X0 + Math.Round(_X * 40 * _scaleX)), (int)(_Y0 - Math.Round(_Y * 40 * _scaleY)), 1, 1);
                    _X += _step;
                }
            }
        }
        private async void ButtonStartCalc_Click(object sender, EventArgs e)
        {
            if (_buffer is null)
            {
                _buffer = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            timer.Enabled = true;
            await Task.Run(() => DrawToBuffer(_buffer));
            timer.Enabled = false;
            pictureBox.Invalidate();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}