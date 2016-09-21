using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    public class ImageDrawer
    {
        public double MiddleX { get; set; }
        public double MiddleY { get; set; }
        public double Scale { get; set; }
        public int Max { get; set; }

        public ImageDrawer()
        {
            MiddleX = -1;
            MiddleY = -0.0;
            Scale = 0.005;
            Max = 100;
        }

        public Bitmap DrawImage(int height, int width)
        {
            var bitmap = new Bitmap(height, width);

            for (int x = 0; x <= width - 1; x++)
            {
                for (int y = 0; y <= height - 1; y++)
                {
                    double coordinateX = x * Scale + MiddleX;
                    double coordinateY = y * Scale + MiddleY;

                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, Max);

                    bitmap.SetPixel(y, x, Color.FromArgb(mandelNumber, mandelNumber, 100, mandelNumber % 10));
                }
            }
            return bitmap;
        }
    }
}
