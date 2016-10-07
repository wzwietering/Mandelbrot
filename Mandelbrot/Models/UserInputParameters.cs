using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// The user input parameters in one containing object.
    /// </summary>
    public class UserInputParameters
    {
        /// <summary>
        /// X - coordinate that is the center of the image
        /// </summary>
        public double CenterX { get; set; }

        /// <summary>
        /// Y - coordinate that is the center of the image
        /// </summary>
        public double CenterY { get; set; }

        /// <summary>
        /// Max mandel number. The mandelnumber calculator can go on until infinity, so this is he upper boundary
        /// for the possible mandel numbers that can be calculated.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// The image scale
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// The selected color scheme.
        /// </summary>
        public ColorSchemes ColorScheme { get; set; }
    }
}
