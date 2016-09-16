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
