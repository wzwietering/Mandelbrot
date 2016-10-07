using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class draws the bitmap mandelbrot image. This is where the ***magic*** happens!
    ///                                   *
    ///         __*                *   *
    ///       / |               *   *   *
    ///      / * \          *
    ///     / *   \         |
    ///     |*  *  \        |
    ///    /*  *  * \       |
    /// __/*_____*___\__    |
    /// \______________/
    /// 
    /// </summary>
    public class ImageDrawer
    {
        /// <summary>
        /// Create a new mandelbrot image.
        /// </summary>
        /// <param name="height"> The height that the image will be</param>
        /// <param name="width"> The width that the image will be</param>
        /// <returns>a <see cref="Bitmap"/> with the mandelbrot image. </returns>
        public unsafe Bitmap DrawImage(int height, int width, UserInputParameters parameters)
        {
            //Creation of bitmap, reservation of memory and some useful variables.
            var bitmap = new Bitmap(width, height);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytesPP = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int bitmapH = bitmapData.Height;
            int bitmapW = bitmapData.Width;
            byte* address = (byte*)bitmapData.Scan0;

            //Parallel.For improves speed a lot compared to a normal for loop.
            Parallel.For(0, bitmapH, y =>
            {
                Parallel.For(0, bitmapW, x =>
                {
                    byte* data = address + y * bitmapData.Stride + x * 2;

                    // Get the coordinates of this pixel based on the image scale and center coordinate.
                    double coordinateX = x * parameters.Scale + parameters.CenterX;
                    double coordinateY = y * parameters.Scale + parameters.CenterY;

                    // And calculate this coordinates mandel number.
                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, parameters.Max);

                    // Get a nice color to match and color this pixel with it.
                    Color color = ColorPicker.GetColor(mandelNumber, parameters.ColorScheme);

                    data[x] = color.B;
                    data[x + 1] = color.G;
                    data[x + 2] = color.R;
                });
            });

            //Unlocking of memory.
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
    }
}
