using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        internal InputHandler InputHandler { get; private set; }

        public MandelbrotForm()
        {
            InitializeComponent();
            
            this.InputHandler = new InputHandler();

            CreateControls();

            this.MouseClick += HandleMouseClick;
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            InputHandler.HandleMouseClick(this, e);
        }

        private void HandleGoButtonClick(object sender, EventArgs e)
        {
            InputHandler.HandleGoButtonClick(this);
        }

        private void HandleValueChange(object sender, EventArgs e)
        {
            InputHandler.HandleTextBoxValueChange(sender);
        }

        /// <summary>
        /// Create the controls for the form.
        /// </summary>
        private void CreateControls()
        {
            CreateControl(20, 20, 0.0, 0, "Middelste x:");
            CreateControl(20, 50, 0.0, 1, "Middelste y:");
            CreateControl(300, 20, 0.001, 2, "Schaal:");
            CreateControl(300, 50, 100, 3, "Max:");

            CreateGoButton();
        }

        /// <summary>
        /// Create the go button for the form.
        /// </summary>
        private void CreateGoButton()
        {
            var goButton = new Button() { Text = "Go!" };
            goButton.Click += HandleGoButtonClick;

            this.Controls.Add(goButton);
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
            ValueBox.TextChanged += HandleValueChange;
        }
    }
}
