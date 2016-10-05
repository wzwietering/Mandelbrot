using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.ImageDrawer = new ImageDrawer();
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
            var oldParameters = form.UserInputParameters;
            var newParameters = new UserInputParameters()
            {
                CenterX = (e.X - form.Width / 4) * oldParameters.Scale + oldParameters.CenterX,
                CenterY = (e.Y - form.Width / 4) * oldParameters.Scale + oldParameters.CenterY,
                Scale = oldParameters.Scale / 2,
                Max = oldParameters.Max
            };

            form.UserInputParameters = newParameters;

            // And draw a new image.
            StartNewImageThread(form);
        }

        /// <summary>
        /// User clicked the go button. Let's render a new image!
        /// </summary>
        /// <param name="form"></param>
        internal void HandleGoButtonClick(MandelbrotForm form)
        {
            StartNewImageThread(form);
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
            form.BackgroundImage = ImageDrawer.DrawImage(form.Height, form.Width, form.UserInputParameters);
        }

        /// <summary>
        /// This method saves the Mandelbrot drawing to a file
        /// </summary>
        /// <param name="form">The form is required to retrieve the image</param>
        public void SaveImage(MandelbrotForm form)
        {
            Image background = form.BackgroundImage;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Image";
            sfd.Filter = "PNG|*.png|JPEG|*.jpg|Bitmap Image|*.bmp";
            sfd.ShowDialog();

            try
            {
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                background.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            }
            //When there is no image, this error is thrown
            catch(NullReferenceException e)
            {

            }
            //This error is thrown when the user cancels the save
            catch(IndexOutOfRangeException i)
            {

            }
        }
    }
}

