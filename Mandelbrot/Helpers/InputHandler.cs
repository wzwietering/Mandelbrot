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
                CenterY = (e.Y - form.Height / 4) * oldParameters.Scale + oldParameters.CenterY,
                Scale = oldParameters.Scale / 2,
                Max = oldParameters.Max,
                ColorScheme = oldParameters.ColorScheme
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
            form.UserInputParameters = form.UserInputParameters;
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

        //The image is rendered lower than the top of the form because of the ui, this variable declares how much.
        public int imageOffset = 80;

        /// <summary>
        /// Create a new image and set as the form background.
        /// </summary>
        /// <param name="form">The form we want to create an image for.</param>
        private void CreateMandelbrotImage(MandelbrotForm form)
        {
            Graphics g = form.CreateGraphics();
            g.DrawImage((Image)ImageDrawer.DrawImage(form.Height - imageOffset, form.Width, form.UserInputParameters), 0, imageOffset);
        }

        /// <summary>
        /// This method saves the Mandelbrot drawing to a file
        /// </summary>
        /// <param name="form">The form is required to retrieve the image</param>
        public void SaveImage(MandelbrotForm form)
        {
            Image background = (Image)ImageDrawer.DrawImage(form.Height - imageOffset, form.Width, form.UserInputParameters);

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

