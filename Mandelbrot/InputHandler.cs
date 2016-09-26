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
        public void HandleMouseClick(Form form, MouseEventArgs e)
        {
            // Set new middle x and middle y coordinates.
            this.ImageDrawer.MiddleX = e.X * ImageDrawer.Scale + ImageDrawer.MiddleX;
            this.ImageDrawer.MiddleY = e.Y * ImageDrawer.Scale + ImageDrawer.MiddleY;
            // Set new scale
            this.ImageDrawer.Scale = this.ImageDrawer.Scale / 2;

            // And draw a new image.
            StartNewImageThread(form);
        }

        internal void HandleGoButtonClick(Form form)
        {
            StartNewImageThread(form);
        }

        public void HandleTextBoxValueChange(object sender)
        {
            int id = Int32.Parse(((NumericUpDown)sender).Name);
            var value = double.Parse(((NumericUpDown)sender).Text);

            try
            {
                switch (id)
                {
                    case 0:

                        ImageDrawer.MiddleX = value;
                        break;
                    case 1:
                        ImageDrawer.MiddleY = value;
                        break;
                    case 2:
                        ImageDrawer.Scale = value;
                        break;
                    case 3:
                        ImageDrawer.Max = (int)value;
                        break;
                }
            }
            catch (FormatException)
            {

            }
        }

        /// <summary>
        /// Creates the mandelbrot image as new background for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartNewImageThread(Form form)
        {
            var t = new Thread(() => CreateMandelbrotImage(form));
            t.Start();
        }

        private void CreateMandelbrotImage(Form form)
        {
            form.BackgroundImage = ImageDrawer.DrawImage(form.Height, form.Width);
        }
    }
}

