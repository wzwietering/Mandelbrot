using System.Drawing;

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
        public Bitmap DrawImage(int height, int width)
        {
            var bitmap = new Bitmap(width, height);
            // For each pixel in the with...
            for (int x = 0; x < width; x++)
            {
                // And each pixel in the height...
                for (int y = 0; y < height; y++)
                {
                    // Get the coordinates of this pixel based on the image scale and center coordinate.
                    double coordinateX = x * Scale + MiddleX;
                    double coordinateY = y * Scale + MiddleY;

                    // And calculate this coordinates mandel number.
                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, Max);

                    // Get a nice color to match and color this pixel with it.
                    Color color = GetColor(mandelNumber);
                    bitmap.SetPixel(x, y, color);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Get a color based on the mandel number
        /// </summary>
        /// <param name="mandelNumber">The mandel number</param>
        /// <returns>A <see cref="Color"/> </returns>
        private Color GetColor(int mandelNumber)
        {
            int blue = mandelNumber < 50 ? (int)(colorscale * mandelNumber) : 0;
            var color = Color.FromArgb(255, (int)(colorscale * mandelNumber), (int)(-colorscale * (1 - mandelNumber)), blue);
            return color;
        }
    }
}
