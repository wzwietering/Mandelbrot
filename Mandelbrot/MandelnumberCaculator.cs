using System;

namespace Mandelbrot
{
    /// <summary>
    /// Use this class to calculate the mandel number of a coordinate on a plain.
    /// Mandelbrot formula: f (a,b) = (a*a-b*b+x, 2*a*b+y)
    /// </summary>
    public static class MandelnumberCaculator
    {
        /// <summary>
        /// Calculate the mandel number for coordinates (a,b) on a plain.
        /// </summary>
        /// <param name="a">Coordinate a</param>
        /// <param name="b">Coordinate b</param>
        /// <returns>The Mander number for the given coordinates on a plain.</returns>
        public static int CalculateMandelNumber(float x, float y, int max)
        {
            int mandelNumber = 0;
            double distance = 0;

            float a = 0;
            float b = 0;

            while (distance < 2 && mandelNumber < max)
            {
                var newA = (a * a - b * b) + x;
                var newB = 2 * a * b + y;

                distance = Math.Sqrt(Math.Pow(newA - a, 2) + Math.Pow(newB - b, 2));

                a = newA;
                b = newB;

                mandelNumber++;
            }

            return mandelNumber;
        }
    }
}
