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

        float colorscale;

        public ImageDrawer()
        {
            MiddleX = -1;
            MiddleY = -0.0;
            Scale = 0.001;
            Max = 100;
            colorscale = 255.0F /Max;

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

                    Color color = GetColor(mandelNumber);

                    bitmap.SetPixel(y, x, color);
                }
            }
            return bitmap;
        }

        private Color GetColor(int mandelNumber)
        {
            int blue = mandelNumber < 50 ? (int)(colorscale * mandelNumber) : 0;
            var color = Color.FromArgb(255, (int)(colorscale * mandelNumber), (int)(-colorscale * (1 - mandelNumber)), blue);
            //int red = mandelNumber < 50 ? (int)(colorscale * mandelNumber) : 0 ;
            //
            //int green = mandelNumber > 50 ? (int)((colorscale * mandelNumber) - 126) : 0;
            //var color = Color.FromArgb(255, red, green, blue);
            return color;
        }
    }
}
