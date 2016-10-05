using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class MandelbrotForm : Form
    {
        /// <summary>
        /// The user input fields on this form
        /// </summary>
        public Control centerX;
        public Control centerY;
        public Control scale;
        public Control max;

        /// <summary>
        /// The inputhandler. Handles the form input (no shit, sherlock).
        /// </summary>
        internal InputHandler InputHandler { get; private set; }

        /// <summary>
        /// All user controls will be bound to one input parameters object, to be used by the image handler later.
        /// </summary>
        public UserInputParameters UserInputParameters
        {
            get
            {
                return new UserInputParameters
                {
                    CenterX = double.Parse(centerX.Text),
                    CenterY = double.Parse(centerY.Text),
                    Scale = double.Parse(scale.Text),
                    Max = int.Parse(max.Text)
                };
            }
            set
            {
                centerX.Text = value.CenterX.ToString();
                centerY.Text = value.CenterY.ToString();
                scale.Text = value.Scale.ToString();
                max.Text = value.Max.ToString();
            }
        }

        public MandelbrotForm()
        {
            this.InputHandler = new InputHandler();

            InitializeComponent();

            CreateControls();

            this.MouseClick += HandleMouseClick;
            this.Enter += HandleGoButtonClick;
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
            this.centerX = CreateControl(20, 30, 0.0, "centerX", "Middelste x:");
            this.centerY = CreateControl(20, 50, 0.0, "centerY", "Middelste y:");
            this.scale = CreateControl(300, 30, 0.001, "scale", "Schaal:");
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
            goButton.Location = new Point(20,100);

            this.Controls.Add(goButton);
        }
        
        /// <summary>
        /// This method creates a label and a numericupdown.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="label"></param>
        /// <param name="hasDecimalValues"></param>
        /// <returns></returns>
        private Control CreateControl(int x, int y, double value, string name, string label, bool hasDecimalValues = true)
        {
            Label Description = new Label()
            {
                Text = label,
                Location = new Point(x, y)
            };

            this.Controls.Add(Description);

            //Nummerbox with its properties
            TextBox ValueBox = new TextBox()
            {
                Location = new Point(Description.Width + 20 + x, y),
                Size = new Size(100, 20),
                Text = value.ToString(),
                Name = name
            };

            this.Controls.Add(ValueBox);
            return ValueBox;
        }

        private void preset2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preset1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
