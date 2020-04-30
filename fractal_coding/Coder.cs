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

        const int IDENTICAL_TRANSFORM = 0;
        const int VERTICAL_AXIS_MIRRORING = 1;
        const int HORIZONTAL_AXIS_MIRRORING = 2;
        const int FIRST_DIAGONAL_MIRRORING = 3;
        const int SECOND_DIAGONAL_MIRRORING = 4;
        const int CLOCKWISE_90_ROTATION = 5;
        const int CLOCKWISE_180_ROTATION = 6;
        const int CLOCKWISE_270_ROTATION = 7;

        const int RANGE_MATRIX_DIMENSION = 64;

        private byte[] Header;
        private byte[,] Image;
        private string OriginalImagePath;
        private RangeInfo[,] Ranges;

        public void Init()
        {
            Header = new byte[HEADER_SIZE];
            Image = new byte[HEIGHT, WIDTH];
            OriginalImagePath = null;
            Ranges = new RangeInfo[RANGE_MATRIX_DIMENSION, RANGE_MATRIX_DIMENSION];
            for(int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for(int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Ranges[i, j] = new RangeInfo();
                }
            }
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

        public void ProcessImage()
        {
            PopulateRanges();
        }

        private void PopulateRanges()
        {
            MapPixelsToRanges();
            CalculateSumsForRanges();
        }

        private void MapPixelsToRanges()
        {
            for(int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    int rangeI = i / 8;
                    int rangeJ = j / 8;

                    int pixelI = i % 8;
                    int pixelJ = j % 8;

                    Ranges[rangeI, rangeJ].Pixels[pixelI, pixelJ] = Image[i, j];
                }
            }
        }

        private void CalculateSumsForRanges()
        {
            for(int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for(int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Ranges[i, j].CalculateSumOfPixels();
                    Ranges[i, j].CalculateSumSquaredOfPixels();
                }
            }
        }

        public void SaveCoding()
        {
            if(OriginalImagePath == null)
            {
                return;
            }
        }

        public byte[,] ApplyIsometry(int isometry)
        {
            byte[,] result = new byte[HEIGHT, WIDTH];
            for(int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    switch (isometry)
                    {
                        case IDENTICAL_TRANSFORM:
                            result[i, j] = Image[i, j];
                            break;
                        case VERTICAL_AXIS_MIRRORING:
                            result[i, j] = Image[i, WIDTH - 1 - j];
                            break;
                        case HORIZONTAL_AXIS_MIRRORING:
                            result[i, j] = Image[HEIGHT - 1 - i, j];
                            break;
                        case FIRST_DIAGONAL_MIRRORING:
                            result[i, j] = Image[j, i];
                            break;
                        case SECOND_DIAGONAL_MIRRORING:
                            result[i, j] = Image[HEIGHT - 1 - j, WIDTH - 1 - i];
                            break;
                        case CLOCKWISE_90_ROTATION:
                            result[i, j] = Image[WIDTH - 1 - j, i];
                            break;
                        case CLOCKWISE_180_ROTATION:
                            result[i, j] = Image[HEIGHT - 1 - i, WIDTH - 1 - j];
                            break;
                        case CLOCKWISE_270_ROTATION:
                            result[i, j] = Image[j, WIDTH - 1 - i];
                            break;
                    }
                }
            }
            return result;
        }
    }
}
