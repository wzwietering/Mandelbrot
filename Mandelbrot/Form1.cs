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
            TextBox MiddleX = new TextBox();
            MiddleX.Location = new Point(20, 50);
            MiddleX.Size = new Size(100, 20);
            this.Controls.Add(MiddleX);
        }
    }
}
