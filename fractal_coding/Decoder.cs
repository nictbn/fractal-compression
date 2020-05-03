using BitReaderWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class Decoder
    {
        const int RANGE_MATRIX_DIMENSION = 64;
        const int HEIGHT = 512;
        const int WIDTH = 512;
        const int HEADER_SIZE = 1078;

        public byte[] Header;
        public byte[,] InitialImage;
        public string EncodedImagePath;
        public Encoding[,] Encodings;
        public void Init()
        {
            Header = new byte[HEADER_SIZE];
            InitialImage = new byte[HEIGHT, WIDTH];
            EncodedImagePath = null;
            InitEncodings();
        }

        public void InitEncodings()
        {
            Encodings = new Encoding[RANGE_MATRIX_DIMENSION, RANGE_MATRIX_DIMENSION];
            for (int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Encodings[i, j] = new Encoding();
                }
            }
        }

        public void ParseImage(string path)
        {
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
                        InitialImage[i, j] = (byte)(fileStream.ReadByte());
                    }
                }
            }
        }

        public void LoadEncodings(string encodedImagePath)
        {
            EncodedImagePath = encodedImagePath;
            BitReader reader = new BitReader(encodedImagePath);
            for (int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Encoding encoding = new Encoding();
                    encoding.Xd = reader.readNBits(6);
                    encoding.Yd = reader.readNBits(6);
                    encoding.Isometry = reader.readNBits(3);
                    encoding.SQuantized = reader.readNBits(5);
                    encoding.OQuantized = reader.readNBits(7);
                    Encodings[i, j] = encoding;
                }
            }
            reader.closeFile();
        }
    }
}
