using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class draws the bitmap mandelbrot image.
    /// </summary>
    public class ImageDrawer
    {
        /// <summary>
        /// The x-coordinate that is the center of the image
        /// </summary>
        public double MiddleX { get; set; }

        /// <summary>
        /// The y-coordinate that is the center of the image.
        /// </summary>
        public double MiddleY { get; set; }

        /// <summary>
        /// The scale of the image to be rendered.
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// The max integer value that the mandelbrot number can have.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// The scale of the color value per manderbrot number increment (255 devided by the max manderbrot number).
        /// </summary>
        float colorscale;

        /// <summary>
        /// Constructor for this class. Creates a new image drawer with default values for its properties.
        /// </summary>
        public ImageDrawer(double middleX = 0.0, double middleY = 0.0, double scale = 0.001, int max = 100)
        {
            MiddleX = middleX;
            MiddleY = middleY;
            Scale = scale;
            Max = max;
            colorscale = 255.0F / max;
        }

        /// <summary>
        /// Create a new mandelbrot image.
        /// </summary>
        /// <param name="height"> The height that the image will be</param>
        /// <param name="width"> The width that the image will be</param>
        /// <returns>a <see cref="Bitmap"/> with the mandelbrot image. </returns>
        public unsafe Bitmap DrawImage(int height, int width)
        {
            //To test the performance
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //Creation of bitmap, reservation of memory and some useful variables.
            var bitmap = new Bitmap(width, height);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytesPP = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int bitmapH = bitmapData.Height;
            int bitmapW = bitmapData.Width;
            byte* address = (byte*)bitmapData.Scan0;

            //Parallel.For improves speed by about 70% compared to a normal for loop.
            Parallel.For(0, bitmapH, y =>
            {
                Parallel.For(0, bitmapW, x =>
                {
                    //I have no idea why x needs to be multiplied by 2, but it works...
                    byte* data = address + y * bitmapData.Stride + x * 2;

                    // Get the coordinates of this pixel based on the image scale and center coordinate.
                    double coordinateX = x * Scale + MiddleX;
                    double coordinateY = y * Scale + MiddleY;

                    // And calculate this coordinates mandel number.
                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, Max);

                    // Get a nice color to match and color this pixel with it.
                    Color color = ColorPicker.GetColor(mandelNumber);

                    data[x] = color.B;
                    data[x + 1] = color.G;
                    data[x + 2] = color.R;
                });
            });

            //Unlocking of memory.
            bitmap.UnlockBits(bitmapData);
            sw.Stop();
            System.Console.WriteLine(sw.ElapsedMilliseconds);
            return bitmap;
        }
    }
}
