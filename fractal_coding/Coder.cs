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
        const int DOMAIN_MATRIX_DIMENSION = 63;

        private byte[] Header;
        private byte[,] Image;
        private string OriginalImagePath;
        private RangeInfo[,] Ranges;
        private DomainInfo[,] Domains;

        public void Init()
        {
            Header = new byte[HEADER_SIZE];
            Image = new byte[HEIGHT, WIDTH];
            OriginalImagePath = null;

            InitRanges();
            InitDomains();
        }
        public void InitRanges()
        {
            Ranges = new RangeInfo[RANGE_MATRIX_DIMENSION, RANGE_MATRIX_DIMENSION];
            for (int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Ranges[i, j] = new RangeInfo();
                }
            }
        }
        public void InitDomains()
        {
            Domains = new DomainInfo[DOMAIN_MATRIX_DIMENSION, DOMAIN_MATRIX_DIMENSION];
            for (int i = 0; i < DOMAIN_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < DOMAIN_MATRIX_DIMENSION; j++)
                {
                    Domains[i, j] = new DomainInfo();
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
            InitRanges();
            InitDomains();
            PopulateRanges();
            PopulateDomains();
        }

        private void PopulateRanges()
        {
            MapPixelsToRanges();
            CalculateSumsForRanges();
        }

        private void MapPixelsToRanges()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
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
            for (int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    Ranges[i, j].CalculateSumOfPixels();
                    Ranges[i, j].CalculateSumOfSquaredPixels();
                }
            }
        }

        public void SaveCoding()
        {
            if (OriginalImagePath == null)
            {
                return;
            }
        }

        private void PopulateDomains()
        {
            MapPixelsToDomains();
            CalculateSumsForDomains();
            GenerateIsometries();
        }

        private void GenerateIsometries()
        {
            for (int i = 0; i < DOMAIN_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < DOMAIN_MATRIX_DIMENSION; j++)
                {
                    Domains[i, j].PopulateIsometries();
                }
            }
        }

        private void CalculateSumsForDomains()
        {
            for (int i = 0; i < DOMAIN_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < DOMAIN_MATRIX_DIMENSION; j++)
                {
                    Domains[i, j].CalculateSumOfPixels();
                    Domains[i, j].CalculateSumOfSquaredPixels();
                }
            }
        }

        private void MapPixelsToDomains()
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < HEIGHT - 8; i += 8)
            {
                for (int j = 0; j < WIDTH - 8; j += 8)
                {
                    byte[,] largeDomain = CopyPixels(i, j);
                    byte[,] sampledDomain = SubSampleDomain(largeDomain);
                    Domains[x, y].AddIdentityIsometry(sampledDomain);
                    y++;
                }
                y = 0;
                x++;
            }
        }

        private byte[,] SubSampleDomain(byte[,] largeDomain)
        {
            byte[,] result = new byte[8, 8];
            int x = 0;
            int y = 0;
            for (int i = 0; i < 16; i += 2)
            {
                for (int j = 0; j < 16; j += 2)
                {
                    int pixel1 = largeDomain[i, j];
                    int pixel2 = largeDomain[i, j + 1];
                    int pixel3 = largeDomain[i + 1, j];
                    int pixel4 = largeDomain[i + 1, j + 1];
                    double average = (pixel1 + pixel2 + pixel3 + pixel4) / 4.0;
                    result[x, y] = (byte)average;
                    y++;
                }
                y = 0;
                x++;
            }
            return result;
        }

        private byte[,] CopyPixels(int i, int j)
        {
            byte[,] largeDomain = new byte[16, 16];
            int a = 0;
            int b = 0;
            for (int x = i; x < i + 16; x++)
            {
                for (int y = j; y < j + 16; y++)
                {
                    largeDomain[a, b] = Image[x, y];
                    b++;
                }
                b = 0;
                a++;
            }
            return largeDomain;
        }

        public byte[,] ApplyIsometry(int isometry)
        {
            byte[,] result = new byte[HEIGHT, WIDTH];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
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
