using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var MandelnumberCaculator = new MandelnumberCaculator(0.5, 0.8);
            MandelnumberCaculator.CalculateMandelNumber(0, 0);

            Application.Run(new Form1());
        }
    }
}
