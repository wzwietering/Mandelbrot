using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    class InputHandler
    {
        public ImageDrawer ImageDrawer { get; private set; }

        public InputHandler()
        {
            this.ImageDrawer = new ImageDrawer(middleX: 0.1);
        }

        /// <summary>
        /// The user has clicked the image somewhere. Zoom in to the point where the user clicked:
        /// Take the coordinates of the click event and set these as the new center coordinates of the image. 
        /// Also enlarge 2x (so devide scale by 2).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleMouseClick(MandelbrotForm form, MouseEventArgs e)
        {
            // Set new middle x and middle y coordinates.
            this.ImageDrawer.CenterX = (e.X - form.Width / 4) * ImageDrawer.Scale + ImageDrawer.CenterX;
            this.ImageDrawer.CenterY = (e.Y - form.Height / 4) * ImageDrawer.Scale + ImageDrawer.CenterY ;
            // Set new scale
            this.ImageDrawer.Scale = this.ImageDrawer.Scale / 2;

            // And draw a new image.
            StartNewImageThread(form);
        }

        /// <summary>
        /// User clicked the go button. Let's render a new image!
        /// </summary>
        /// <param name="form"></param>
        internal void HandleGoButtonClick(MandelbrotForm form)
        {
            SetImageDrawerValues(form);
            StartNewImageThread(form);
        }

        /// <summary>
        /// Set the values in the textboxes to the imagedrawer properties.
        /// </summary>
        /// <param name="form">The form that contains the textboxes.</param>
        private void SetImageDrawerValues(MandelbrotForm form)
        {
            ImageDrawer.CenterX = double.Parse(form.centerX.Text);
            ImageDrawer.CenterY = double.Parse(form.centerY.Text);
            ImageDrawer.Scale = double.Parse(form.scale.Text);
            ImageDrawer.Max = int.Parse(form.max.Text);
        }

        /// <summary>
        /// Creates the mandelbrot image as new background for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartNewImageThread(MandelbrotForm form)
        {
            var t = new Thread(() => CreateMandelbrotImage(form));
            t.Start();
        }

        /// <summary>
        /// Create a new image and set as the form background.
        /// </summary>
        /// <param name="form">The form we want to create an image for.</param>
        private void CreateMandelbrotImage(MandelbrotForm form)
        {
            form.BackgroundImage = ImageDrawer.DrawImage(form.Height, form.Width);
        }
    }
}

