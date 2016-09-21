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
        public float middleX { get; set; }
        public float middleY { get; set; }
        public float scale { get; set; }
        public int max { get; set; }

        public ImageDrawer()
        {
            middleX = (float)-1;
            middleY = (float)-0.0;
            scale = (float)0.005;
            max = 100;
        }

        public Bitmap DrawImage(int height, int width)
        {
            var bitmap = new Bitmap(height, width);

            for (int x = 0; x <= width - 1; x++)
            {
                for (int y = 0; y <= height - 1; y++)
                {
                    double coordinateX = x * scale + middleX;
                    double coordinateY = y * scale + middleY;

                    int mandelNumber = MandelnumberCaculator.CalculateMandelNumber(coordinateX, coordinateY, max);

                    bitmap.SetPixel(y, x, Color.FromArgb(mandelNumber, mandelNumber, 100, mandelNumber % 10));
                }
            }
            return bitmap;
        }
    }
}
