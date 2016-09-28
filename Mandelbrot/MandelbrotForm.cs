using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        public Control centerX;
        public Control centerY;
        public Control scale;
        public Control max;

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

        /// <summary>
        /// Create the controls for the form.
        /// </summary>
        private void CreateControls()
        {
            this.centerX = CreateControl(20, 20, 0.0, "centerX", "Middelste x:");
            this.centerY = CreateControl(20, 50, 0.0, "centerY", "Middelste y:");
            this.scale = CreateControl(300, 20, 0.001, "scale", "Schaal:");
            this.max = CreateControl(300, 50, 100, "max", "Max:", false);

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

        private Control CreateControl(int x, int y, double value, string name, string label, bool hasDecimalValues = true)
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
                Name = name,
                DecimalPlaces = hasDecimalValues ? 8 : 0,
                Increment = hasDecimalValues ? 0.01m : 1,
                Minimum = hasDecimalValues  ? - 100 : 0,
                Maximum = 1000,
            };

            this.Controls.Add(ValueBox);
            return ValueBox;
        }
    }
}
