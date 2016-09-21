﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        public ImageDrawer ImageDrawer { get; private set; }

        public MandelbrotForm()
        {
            InitializeComponent();
            this.ImageDrawer = new ImageDrawer();

            CreateControl(20, 20, ImageDrawer.MiddleX, 0, "Middelste x:");
            CreateControl(20, 50, ImageDrawer.MiddleY, 1, "Middelste y:");
            CreateControl(300, 20, ImageDrawer.Scale, 2, "Schaal:");
            CreateControl(300, 50, ImageDrawer.Max, 3, "Max:");

            var goButton = new Button() { Text = "Go!" };
            goButton.Click += CreateMandelbrotImage;

            this.Controls.Add(goButton);

            this.MouseClick += HandleMouseClick;
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            this.ImageDrawer.MiddleX = e.X * ImageDrawer.Scale + ImageDrawer.MiddleX;
            this.ImageDrawer.MiddleY = e.Y * ImageDrawer.Scale + ImageDrawer.MiddleY;
            this.ImageDrawer.Scale = this.ImageDrawer.Scale / 2;

            this.BackgroundImage = ImageDrawer.DrawImage(this.Height, this.Width);
        }

        private void CreateMandelbrotImage(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageDrawer.DrawImage(this.Height, this.Width);
        }

        private void CreateControl(int x, int y, double value, int id, string label)
        {
            Label Description = new Label();
            Description.Text = label;
            Description.Location = new Point(x, y);
            this.Controls.Add(Description);

            //Nummerbox
            NumericUpDown ValueBox = new NumericUpDown();
            ValueBox.Location = new Point(Description.Width + 20 + x, y);
            ValueBox.Size = new Size(100, 20);
            ValueBox.Text = value.ToString();
            ValueBox.Name = id.ToString();
            ValueBox.DecimalPlaces = 8;
            ValueBox.Increment = 0.001m;
            ValueBox.Minimum = -100;
            this.Controls.Add(ValueBox);
            ValueBox.TextChanged += ValueChange;
        }

        private void ValueChange(object sender, EventArgs e)
        {
            int id = Int32.Parse(((NumericUpDown)sender).Name);
            try
            {
                switch (id)
                {
                    case 0:
                        ImageDrawer.MiddleX = (double)decimal.Parse(((NumericUpDown)sender).Text);
                        break;
                    case 1:
                        ImageDrawer.MiddleY = (double)decimal.Parse(((NumericUpDown)sender).Text);
                        break;
                    case 2:
                        ImageDrawer.Scale = (double)decimal.Parse(((NumericUpDown)sender).Text);
                        break;
                    case 3:
                        ImageDrawer.Max = (int)decimal.Parse(((NumericUpDown)sender).Text);
                        break;
                }
            }
            catch (FormatException)
            {

            }
        }
    } 
}