using System;
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
        public static Color GetColor(int mandelNumber, string colorScheme)
        {
            switch (colorScheme)
            {
                case "RedGreen":
                    return GetRedgreen(mandelNumber);
                case "RedBlue":
                    return GetRedBlue(mandelNumber);
                case "BlueGreen":
                    return GetBlueGreen(mandelNumber);
                default:
                case "MultiColor":
                    return GetMultiColor(mandelNumber);
            }
        }

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
            int green = (int)(mandelNumber *10) % 255;
            int blue = (int)(mandelNumber *100 ) % 300 / 2;
            var color = Color.FromArgb(255, 0, green, blue);
            return color;
        }

        private static Color GetRedgreen(int mandelNumber)
        {
<<<<<<< HEAD
            int red = (int)(mandelNumber * 100 ) % 255;
            int green = (int)(mandelNumber * 100 / 8) % 255;
            var color = Color.FromArgb(255, red, green, 0);
=======
            int red = (int)(mandelNumber * 100) % 255;
            int green = (int)(mandelNumber * 100 / 8) % 255;
            var color = Color.FromArgb(255, red, green, 0);
            return color;
        }

        private static Color GetRedBlue(int mandelNumber)
        {
            int red = (int)(mandelNumber * 100) % 300;
            int blue = (int)(mandelNumber * 100) % 220;
            var color = Color.FromArgb(255, red, 0, blue);
>>>>>>> origin/master
            return color;
        }
    }

}
