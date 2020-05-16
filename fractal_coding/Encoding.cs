using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class Encoding
    {
        public int Xd;
        public int Yd;
        public int Isometry;
        public int SQuantized;
        public int OQuantized;
        public double SDequantized;
        public double ODequantized;
        private int S_BITS = 5;
        private int O_BITS = 7;
        private int GREY_LEVELS = 255;
        private double MAX_SCALE = 1.0;
        public Encoding()
        {
            Xd = 0;
            Yd = 0;
            Isometry = 0;
            SQuantized = 0;
            OQuantized = 0;
            SDequantized = 0.0;
            ODequantized = 0.0;
        }

        public void DequantizeScaleAndOffset()
        {
            ComputeDequantizedS();
            ComputeDequantizedO();
        }

        private void ComputeDequantizedS()
        {
            SDequantized = (double) SQuantized / (double) (1 << S_BITS) * (2.0 * MAX_SCALE) - MAX_SCALE;
        }

        private void ComputeDequantizedO()
        {
            ODequantized = (double)OQuantized / (double)((1 << O_BITS) - 1) * ((1.0 + Math.Abs(SDequantized)) * GREY_LEVELS);
            if (SDequantized > 0.0)
            {
                ODequantized -= SDequantized * GREY_LEVELS;
            }
        }
    }
}
