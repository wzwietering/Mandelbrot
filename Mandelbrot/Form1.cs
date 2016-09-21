using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public ImageDrawer ImageDrawer { get; private set; }

        public Form1()
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
            ValueBox.DecimalPlaces = 3;
            ValueBox.Name = id.ToString();
            this.Controls.Add(ValueBox);
            ValueBox.TextChanged += ValueChange;
        }

        private void ValueChange(object sender, EventArgs e)
        {
            int id = Int32.Parse(((NumericUpDown)sender).Name);
            switch (id)
            {
                case 0:
                    ImageDrawer.MiddleX = (double)((NumericUpDown)sender).Value;
                    break;
                case 1:
                    ImageDrawer.MiddleY = (double)((NumericUpDown)sender).Value;
                    break;
                case 2:
                    ImageDrawer.Scale = (double)((NumericUpDown)sender).Value;
                    break;
                case 3:
                    ImageDrawer.Max = (int)((NumericUpDown)sender).Value;
                    break;
            }
        }
    } 
}
