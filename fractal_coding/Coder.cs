using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class Coder
    {
        const int HEADER_SIZE = 1078;
        const int HEIGHT = 512;
        const int WIDTH = 512;

        private byte[] Header;
        private byte[,] Image;
        private string OriginalImagePath;

        public void Init()
        {
            Header = new byte[HEADER_SIZE];
            Image = new byte[HEIGHT, WIDTH];
            OriginalImagePath = null;
        }

        public void ParseImage(string path)
        {
            OriginalImagePath = path;
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                for (int i = 0; i < HEADER_SIZE; i++)
                {
                    Header[i] = (byte)(fileStream.ReadByte());
                }

                for (int i = HEIGHT - 1; i >= 0; i--)
                {
                    for (int j = 0; j < WIDTH; j++)
                    {
                        Image[i, j] = (byte)(fileStream.ReadByte());
                    }
                }
            }
        }
    }
}
