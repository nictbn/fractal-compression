using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class RangeInfo
    {
        public byte[,] Pixels;
        public int SumOfPixels;
        public int SumOfSquaredPixels;
        public RangeInfo()
        {
            Pixels = new byte[8, 8];
            SumOfPixels = 0;
            SumOfSquaredPixels = 0;
        }

        public void CalculateSumOfPixels()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    SumOfPixels += Pixels[i, j];
                }
            }
        }

        public void CalculateSumSquaredOfPixels()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    SumOfSquaredPixels += Pixels[i, j] * Pixels[i, j];
                }
            }
        }
    }
}
