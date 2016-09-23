using System;
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
            this.ImageDrawer = new ImageDrawer(middleX: 0.1);

            CreateControls();

            this.MouseClick += HandleMouseClick;
        }

        private void CreateControls()
        {
            CreateControl(20, 20, ImageDrawer.MiddleX, 0, "Middelste x:");
            CreateControl(20, 50, ImageDrawer.MiddleY, 1, "Middelste y:");
            CreateControl(300, 20, ImageDrawer.Scale, 2, "Schaal:");
            CreateControl(300, 50, ImageDrawer.Max, 3, "Max:");

            CreateGoButton();
        }

        private void CreateGoButton()
        {
            var goButton = new Button() { Text = "Go!" };
            goButton.Click += CreateMandelbrotImage;

            this.Controls.Add(goButton);
        }

        /// <summary>
        /// The user has clicked the image somewhere. Zoom in to the point where the user clicked:
        /// Take the coordinates of the click event and set these as the new center coordinates of the image. 
        /// Also enlarge 2x (so devide scale by 2).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            // Set new middle x and middle y coordinates.
            this.ImageDrawer.MiddleX = e.X * ImageDrawer.Scale + ImageDrawer.MiddleX;
            this.ImageDrawer.MiddleY = e.Y * ImageDrawer.Scale + ImageDrawer.MiddleY;
            // Set new scale
            this.ImageDrawer.Scale = this.ImageDrawer.Scale / 2;

            // And draw a new image.
            CreateMandelbrotImage(sender, e);
        }

        /// <summary>
        /// Creates the mandelbrot image as new background for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMandelbrotImage(object sender, EventArgs e)
        {
            this.BackgroundImage = ImageDrawer.DrawImage(this.Height, this.Width);
        }

        private void CreateControl(int x, int y, double value, int id, string label)
        {
            Label Description = new Label()
            {
                Text = label,
                Location = new Point(x, y)
            };

            this.Controls.Add(Description);

            //Nummerbox
            NumericUpDown ValueBox = new NumericUpDown()
            {
                Location = new Point(Description.Width + 20 + x, y),
                Size = new Size(100, 20),
                Text = value.ToString(),
                Name = id.ToString(),
                DecimalPlaces = 8,
                Increment = 0.001m,
                Minimum = -100,
            };

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
