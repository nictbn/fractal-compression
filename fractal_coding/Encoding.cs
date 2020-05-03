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
        public Encoding()
        {
            Xd = 32;
            Yd = 0;
            Isometry = 0;
            SQuantized = 0;
            OQuantized = 0;
        }
    }
}
