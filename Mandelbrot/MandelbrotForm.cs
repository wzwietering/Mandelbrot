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

        private string ColorScheme = "RedGreen";
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
                    Max = int.Parse(max.Text),
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
            this.ColorScheme = ((ToolStripMenuItem)sender).Text;
            InputHandler.StartNewImageThread(this);
        }
    }
}
