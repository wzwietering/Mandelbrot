using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Textbox voor het middelste x coördinaat
            TextBox MiddleX = new TextBox() ;
            MiddleX.Location = new Point(20, 50);
            MiddleX.Size = new Size(100, 20);
            this.Controls.Add(MiddleX);

            var goButton = new Button() { Text = "Go!" };
            goButton.Click += Colour;
            this.Controls.Add(goButton);

        }

        private void Colour(object sender, EventArgs e)
        { 
            var graphics = CreateGraphics();
            for(int x = 0; x <= this.Width; x++)
            {
                for(int y = 0; y <= this.Height; y++)
                {
                    float coordinateX = x * ((float)2 / this.Width);
                    float coordinateY = y * ((float)2 / this.Height);

                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY);

                    if(mandelNumber % 2 == 0)
                    {
                        graphics.FillRectangle(Brushes.Black, x, y, 1, 1); ;
                    }
                    else
                    {
                        graphics.FillRectangle(Brushes.White, x, y, 1, 1);
                    }
                }
            }
            CreateControl(20, 20, "Middelste x:");
            CreateControl(20, 50, "Middelste y:");
            CreateControl(300, 20, "Schaal:");
            CreateControl(300, 50, "Max:");
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
