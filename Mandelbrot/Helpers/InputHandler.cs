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
    /// <summary>
    /// This class andles all the user input for the mandelbrot form. 
    /// </summary>
    class InputHandler
    {
        /// <summary>
        /// The last rendered image that is currently displayed in the form.
        /// </summary>
        private Image CurrentImage;

        //The image is rendered lower than the top of the form because of the ui, this variable declares how much.
        private int imageOffset = 80;

        /// <summary>
        /// The image gets rendered in a new thread: renderingImageThread. We want to
        /// keep track of this thread, because if the user clicks multiple times, 
        /// we only need to render an image for the last click. 
        /// (thus, we simply abort the current renderingImageThread and make a new one).
        /// </summary>
        private Thread renderingImageThread;

        /// <summary>
        /// The user has clicked the image somewhere. Zoom in to the point where the user clicked:
        /// Take the coordinates of the click event and set these as the new center coordinates of the image. 
        /// Also if the left button was clicked: zoom in 2x (scale * 0.5).
        /// If the right button was clicked: zoom out (scale * 2)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleMouseClick(MandelbrotForm form, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Zoom(form, e.X, e.Y, 0.5);
            }
            if (e.Button == MouseButtons.Right)
            {
                Zoom(form, e.X, e.Y, 2);
            }
        }

        /// <summary>
        /// The user has pressed a hotkey (ctrl + minus, plus, or an arrow key).
        /// __________________________________________________________
        /// |~~~~~~ Zoom in, zoom out, and move it all around! ~~~~~~|
        /// |________________________________________________________|
        /// </summary>
        /// <param name="form">The mandelbrot form</param>
        /// <param name="e">The keypress event</param>
        internal void HandleKeyPress(MandelbrotForm form, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleGoButtonClick(form);
            }
            // Ctrl + minus --> zoom out
            if (e.KeyCode == Keys.OemMinus && e.Modifiers == Keys.Control)
            {
                Zoom(form, form.Width / 2, form.Height / 2, 2);
            }
            // Ctrl + Shift + plus --> zoom in
            if ((e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                Zoom(form, form.Width / 2, form.Height / 2, 0.5);
            }
            // Go left
            if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control)
            {
                Zoom(form, form.Width / 2 - form.Width / 4, form.Height / 2);
            }
            // ... and right
            if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Control)
            {
                Zoom(form, form.Width / 2 + form.Width / 4, form.Height / 2);
            }
            // ... and up
            if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                Zoom(form, form.Width / 2, form.Height / 2 - form.Height / 4);
            }
            // ... and down!
            if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                Zoom(form, form.Width / 2, form.Height / 2 + form.Height / 4);
            }
        }

        /// <summary>
        /// The user scrolled. Use this to zoom in or out, with the mouse location as the new center of the image.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="e"></param>
        internal void HandleScroll(MandelbrotForm form, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                Zoom(form, e.X, e.Y, 0.8);
            }
            else
            {
                Zoom(form, e.X, e.Y, 1.25);
            }
        }

        /// <summary>
        /// Generic zoom function to zoom the image in/out and move it around
        /// </summary>
        /// <param name="form">The mandelbrot form</param>
        /// <param name="x">The x coordinate that will be in the center of the form. </param>
        /// <param name="y">The y coordinate that will be in the center of the form. </param>
        /// <param name="scaleMultiplier">Multiply the scale. When Smaller than 1, we zoom in. When larger than 1, we zoom out.
        /// Default value is 1, so no zoom. </param>
        private void Zoom(MandelbrotForm form, int x, int y, double scaleMultiplier = 1)
        {
            var oldParameters = form.UserInputParameters;

            // Recalculate the user input.
            var newParameters = new UserInputParameters()
            {
                CenterX = (x - form.Width / 2 * scaleMultiplier) * oldParameters.Scale + oldParameters.CenterX,
                CenterY = (y - form.Height / 2 * scaleMultiplier) * oldParameters.Scale + oldParameters.CenterY,
                Scale = oldParameters.Scale * scaleMultiplier,
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

            // The input parameters might have changed, so reset them in the form so the text boxes will be updated.
            form.UserInputParameters = form.UserInputParameters;
        }

        /// <summary>
        /// Creates the mandelbrot image as new background for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartNewImageThread(MandelbrotForm form)
        {
            // A thread is still running. We don't need it anymore because the user changes the parameters.
            if (renderingImageThread != null && renderingImageThread.IsAlive)
            {
                // ... thus, we abort.
                renderingImageThread.Abort();
            }

            // ... and start a new thread
            renderingImageThread = new Thread(() => DrawMandelbrotImage(form));
            renderingImageThread.IsBackground = true;
            renderingImageThread.Start();
        }

        /// <summary>
        /// Draw a new mandelbrot image in the form.
        /// </summary>
        /// <param name="form">The form we want to create an image for.</param>
        private void DrawMandelbrotImage(MandelbrotForm form)
        {
            Graphics g = form.CreateGraphics();
            CurrentImage = (Image)ImageDrawer.DrawImage(form.Height - imageOffset, form.Width, form.UserInputParameters);
            g.DrawImage(CurrentImage, 0, imageOffset, CurrentImage.Width, CurrentImage.Height);
        }

        /// <summary>
        /// This method saves the Mandelbrot drawing to a file
        /// </summary>
        public void SaveImage()
        {
            Image background = CurrentImage;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Image";
            sfd.Filter = "PNG|*.png|JPEG|*.jpg|Bitmap Image|*.bmp";
            sfd.FileName = "Mandelbrot image";
            sfd.ShowDialog();

            try
            {
                System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();
                background.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            }
            //When there is no image, this error is thrown
            catch (NullReferenceException e)
            {

            }
            //This error is thrown when the user cancels the save
            catch (IndexOutOfRangeException i)
            {

            }
        }
    }
}

