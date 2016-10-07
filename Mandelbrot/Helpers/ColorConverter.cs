using System.Drawing;

namespace Mandelbrot
{
    /// <summary>
    /// The possible color schemes the user can choose.
    /// </summary>
    public enum ColorSchemes
    {
        RedGreen,
        RedBlue,
        BlueGreen,
        MultiColor,
    }

    /// <summary>
    /// The color picker. This class makes a color, depending on the color scheme that the user selected, and the mandel number.
    /// </summary>
    public class ColorPicker
    {
        /// <summary>
        /// Get a color based on the mandel number
        /// </summary>
        /// <param name="mandelNumber">The mandel number</param>
        /// <param name="modifier">Modifies the colors</param>
        /// <returns>A <see cref="Color"/> </returns>
        public static Color GetColor(int mandelNumber, ColorSchemes colorScheme)
        {
            switch (colorScheme)
            {
                case ColorSchemes.RedGreen:
                    return GetRedgreen(mandelNumber);
                case ColorSchemes.RedBlue:
                    return GetRedBlue(mandelNumber);
                case ColorSchemes.BlueGreen:
                    return GetBlueGreen(mandelNumber);
                default:
                case ColorSchemes.MultiColor:
                    return GetMultiColor(mandelNumber);
            }
        }

        //Below this comment you can find all the color calculations

        private static Color GetMultiColor(int mandelNumber)
        {
            int red = (int)(mandelNumber % 255);
            int blue = (int)(mandelNumber * 50) % 255;
            int green = (int)(mandelNumber * 10) % 255;
            var color = Color.FromArgb(255, red, green, blue);
            return color;
        }

        private static Color GetBlueGreen(int mandelNumber)
        {
            int red = (mandelNumber * 20) % 800/4;
            int green = (mandelNumber * 10) % 500 / 2;
            int blue = (mandelNumber *100 ) % 500 / 2;
            var color = Color.FromArgb(255, red, green, blue);
            return color;
        }

        private static Color GetRedgreen(int mandelNumber)
        {
            int red = (mandelNumber * 100) % 255;
            int green = (mandelNumber * 100 / 8) % 255;
            var color = Color.FromArgb(255, red, green, 0);
            return color;
        }

        private static Color GetRedBlue(int mandelNumber)
        {
            int red = 255- (mandelNumber * 11) % 255;
            int blue =  (mandelNumber * 31) % 765 / 3;
            int green = (mandelNumber * 9) % 100 ;
            var color = Color.FromArgb(255, red, green, blue);
            return color;
        }
    }

}
