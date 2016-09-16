using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// Use this class to calculate the mandel number of a coordinate on a plain.
    /// Mandelbrot formula: f (a,b) = (a*a-b*b+x, 2*a*b+y)
    /// </summary>
    public class MandelnumberCaculator
    {
        /// <summary>
        /// x and y in the formula. The value of x and y is determined by user input.
        /// </summary>
        private double x;
        private double y;

        /// <summary>
        /// Counter for the mandel number. We start at zero.
        /// </summary>
        private int mandelNumber = 0;

        /// <summary>
        /// Constructor for MandernumberCalculator. Instantiate a new object of this class.
        /// </summary>
        /// <param name="x">The x-value for the mandelbrot formula. Determined by user input.</param>
        /// <param name="y">The y-value for the mandelbrot formula. Determined by user input.</param>
        public MandelnumberCaculator(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Calculate the mandel number for coordinates (a,b) on a plain.
        /// </summary>
        /// <param name="a">Coordinate a</param>
        /// <param name="b">Coordinate b</param>
        /// <returns>The Mander number for the given coordinates on a plain.</returns>
        public int CalculateMandelNumber(double a, double b)
        {
            mandelNumber++;

            var newA = (a * a - b * b) + x;
            var newB = 2 * a * b + y;

            double distance = Math.Sqrt(Math.Pow(newA - a, 2) + Math.Pow(newB - b, 2));

            if (distance < 2)
            {
                mandelNumber = CalculateMandelNumber(newA, newB);
            }
            
            return mandelNumber;
        }
    }
}
