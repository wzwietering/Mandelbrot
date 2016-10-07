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
                centerX.Text = value.CenterX.ToString();
                centerY.Text = value.CenterY.ToString();
                scale.Text = value.Scale.ToString();
                max.Text = value.Max.ToString();
                ColorScheme = value.ColorScheme;
            }
        }

        private double TryGetDouble(string text, double defaultValue)
        {
            double.TryParse(text, out defaultValue);
            return defaultValue;
        }

        public MandelbrotForm()
        {
            this.InputHandler = new InputHandler();

            InitializeComponent();
            CreateCustomControls();

            this.MouseClick += HandleMouseClick;
            this.Enter += HandleGoButtonClick;

            this.UserInputParameters = PresetsHandler.presets.First().InputParameters;
            InputHandler.StartNewImageThread(this);
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
    }
}
