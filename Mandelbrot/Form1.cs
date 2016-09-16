using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        private float middleX = (float)-0.02;
        private float middleY = (float)-0.05;
        private float scale = (float)0.001;
        private int max = 100;

        public Form1()
        {
            InitializeComponent();

            CreateControl(20, 20, "Middelste x:");
            CreateControl(20, 50, "Middelste y:");
            CreateControl(300, 20, "Schaal:");
            CreateControl(300, 50, "Max:");

            var goButton = new Button() { Text = "Go!" };
            goButton.Click += CreateMandelbrotImage;
            this.Controls.Add(goButton);

        }

        private void CreateMandelbrotImage(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(this.Height, this.Width);

            for (int x = 0; x <= this.Width-1; x++)
            {
                for(int y = 0; y <= this.Height-1; y++)
                {
                    float coordinateX = x * scale + middleX;
                    float coordinateY = y * scale + middleY;

                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, max);

                    if(mandelNumber % 2 == 0)
                    {
                        bitmap.SetPixel(y, x, Color.White);
                    }
                    else
                    {
                        bitmap.SetPixel(y, x, Color.Black);
                    }
                }
                this.BackgroundImage = bitmap;
            }
        }

        private void CreateControl(int x, int y, string label)
        {
            Label Description = new Label();
            Description.Text = label;
            Description.Location = new Point(x, y);
            this.Controls.Add(Description);

            //Nummerbox
            NumericUpDown NUP = new NumericUpDown();
            NUP.Location = new Point(Description.Width + 20 + x, y);
            NUP.Size = new Size(100, 20);
            this.Controls.Add(NUP);
            decimal middleXInput = NUP.Value;
        }
    } 
}
