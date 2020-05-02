using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class RangeInfo
    {
        const int WIDTH = 8;
        const int HEIGHT = 8;

        public byte[,] Pixels;
        public int SumOfPixels;
        public int SumOfSquaredPixels;
        public RangeInfo()
        {
            Pixels = new byte[HEIGHT, WIDTH];
            SumOfPixels = 0;
            SumOfSquaredPixels = 0;
        }

        public void CalculateSumOfPixels()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    SumOfPixels += Pixels[i, j];
                }
            }
        }

        public void CalculateSumOfSquaredPixels()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    SumOfSquaredPixels += Pixels[i, j] * Pixels[i, j];
                }
            }
        }
    }
}
