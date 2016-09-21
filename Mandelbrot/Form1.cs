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

            CreateControl(20, 20, ImageDrawer.MiddleX, "Middelste x:");
            CreateControl(20, 50, ImageDrawer.MiddleY, "Middelste y:");
            CreateControl(300, 20, ImageDrawer.Scale, "Schaal:");
            CreateControl(300, 50, ImageDrawer.Max, "Max:");

            var goButton = new Button() { Text = "Go!" };
            goButton.Click += CreateMandelbrotImage;
            this.Controls.Add(goButton);

        }

        private void CreateMandelbrotImage(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageDrawer.DrawImage(this.Height, this.Width);
        }

        private void CreateControl(int x, int y, double value, string label)
        {
            Label Description = new Label();
            Description.Text = label;
            Description.Location = new Point(x, y);
            this.Controls.Add(Description);

            //Nummerbox
            TextBox ValueBox = new TextBox();
            ValueBox.Location = new Point(Description.Width + 20 + x, y);
            ValueBox.Size = new Size(100, 20);
            ValueBox.Text = value.ToString();
            this.Controls.Add(ValueBox);
            ValueBox.TextChanged += ValueChange;
        }

        private void ValueChange(object sender, EventArgs e)
        {

        }
    } 
}
