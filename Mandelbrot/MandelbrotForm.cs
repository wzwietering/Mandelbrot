using System;
using System.Drawing;
using System.Linq;
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

        public ColorSchemes ColorScheme = ColorSchemes.MultiColor;
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
                // Get the input parameters from the form controls.
                return new UserInputParameters
                {
                    CenterX = TryGetDouble(centerX.Text, 0),
                    CenterY = TryGetDouble(centerY.Text, 0),
                    Scale = TryGetDouble(scale.Text, 0.001),
                    Max = (int)TryGetDouble(max.Text, 100),
                    ColorScheme = ColorScheme
                };
            }
            set
            {
                // We have new parameters! Update the form controls accordingly.
                centerX.Text = value.CenterX.ToString();
                centerY.Text = value.CenterY.ToString();
                scale.Text = value.Scale.ToString();
                max.Text = value.Max.ToString();
                ColorScheme = value.ColorScheme;
            }
        }

        /// <summary>
        /// Creates a new MandelBrotForm!
        /// </summary>
        public MandelbrotForm()
        {
            this.KeyPreview = true;
            this.InputHandler = new InputHandler();

            InitializeComponent();
            CreateCustomControls();

            this.MouseClick += HandleMouseClick;
            this.KeyDown += HandleKeypress;

            // Use the first of our presets to render a nice image to start with.
            this.UserInputParameters = PresetsHandler.presets.First().InputParameters;
            InputHandler.StartNewImageThread(this);
        }

        /// <summary>
        /// Try to get a double value from a string. 
        /// </summary>
        /// <param name="text">The text </param>
        /// <param name="defaultValue">Default value, in case the user does something stupid like entering a letter.</param>
        /// <returns>The double</returns>
        private double TryGetDouble(string text, double defaultValue)
        {
            // Do a tryparse incase user doesn;t enter a numerical value
            double.TryParse(text, out defaultValue);
            return defaultValue;
        }

        private void HandleKeypress(object sender, KeyEventArgs e)
        {
            InputHandler.HandleKeyPress(this, e);
        }

        private void HandleMouseClick(object sender, MouseEventArgs e)
        {
            InputHandler.HandleMouseClick(this, e);
        }

        private void HandleGoButtonClick(object sender, EventArgs e)
        {
            InputHandler.HandleGoButtonClick(this);
        }

        private void HandleSaveClick(object sender, EventArgs e)
        {
            InputHandler.SaveImage(this);
        }

        private void PresetSelected(object sender, EventArgs e)
        {
            this.UserInputParameters = PresetsHandler.GetPresets(((ToolStripMenuItem)sender).Text);
            InputHandler.StartNewImageThread(this);
        }

        private void ColorSelected(object sender, EventArgs e)
        {
            this.ColorScheme = (ColorSchemes)Enum.Parse(typeof(ColorSchemes), ((ComboBox)sender).Text);
            InputHandler.StartNewImageThread(this);
        }

        private void about_Click(object sender, EventArgs e)
        {
            var aboutform = new About();
        }

        private void userGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Models.Constants.userGuideText);
        }
    }
}
