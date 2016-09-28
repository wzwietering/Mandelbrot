using System.Drawing;

namespace Mandelbrot
{
    public class ColorPicker
    {
        /// <summary>
        /// Get a color based on the mandel number
        /// </summary>
        /// <param name="mandelNumber">The mandel number</param>
        /// <returns>A <see cref="Color"/> </returns>
        public static Color GetColor(int mandelNumber)
        {
            int red = (int)(mandelNumber * 8) % 255;
            int blue = mandelNumber % 255;
            var color = Color.FromArgb(255, red, blue, 0);
            return color;
        }
    }

}
