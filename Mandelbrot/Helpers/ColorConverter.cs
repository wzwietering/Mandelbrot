using System.Drawing;

namespace Mandelbrot
{
    public class ColorPicker
    {
        /// <summary>
        /// Get a color based on the mandel number
        /// </summary>
        /// <param name="mandelNumber">The mandel number</param>
        /// <param name="modifier">Modifies the colors</param>
        /// <returns>A <see cref="Color"/> </returns>
        public static Color GetColor(int mandelNumber, int modifier)
        {
<<<<<<< HEAD:Mandelbrot/Helpers/ColorConverter.cs
            int red = (int)(mandelNumber * 10) % 255;
            int blue = mandelNumber % 255;
=======
            int red = (int)(mandelNumber * modifier) % 255;
            int blue = (int)(mandelNumber * modifier / 8) % 255;
>>>>>>> origin/master:Mandelbrot/ColorConverter.cs
            var color = Color.FromArgb(255, red, blue, 0);
            return color;
        }
    }

}
