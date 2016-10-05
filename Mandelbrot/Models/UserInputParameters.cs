using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class UserInputParameters
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public int Max { get; set; }
        public double Scale { get; set; }
        public ColorSchemes ColorScheme { get; set; }
    }
}
