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
        const int EIGHT = 8;
        const int IDENTICAL_TRANSFORM = 0;
        const int VERTICAL_AXIS_MIRRORING = 1;
        const int HORIZONTAL_AXIS_MIRRORING = 2;
        const int FIRST_DIAGONAL_MIRRORING = 3;
        const int SECOND_DIAGONAL_MIRRORING = 4;
        const int CLOCKWISE_90_ROTATION = 5;
        const int CLOCKWISE_180_ROTATION = 6;
        const int CLOCKWISE_270_ROTATION = 7;

        public byte[] Header;
        public byte[,] InitialImage;
        public byte[,] AuxiliaryImage;
        public string EncodedImagePath;
        public Encoding[,] Encodings;
        public void Init()
        {
            Header = new byte[HEADER_SIZE];
            InitialImage = new byte[HEIGHT, WIDTH];
            AuxiliaryImage = new byte[HEIGHT, WIDTH];
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
                    Encodings[i, j].DequantizeScaleAndOffset();
                }
            }
            reader.closeFile();
        }

        public void ApplyTransforms(int numberOfTimes)
        {
  
            for (int i = 0; i < numberOfTimes; i++)
            {
                ApplyAllTransforms();
            }
        }

        private void ApplyAllTransforms()
        {
            for (int i = 0; i < RANGE_MATRIX_DIMENSION; i++)
            {
                for (int j = 0; j < RANGE_MATRIX_DIMENSION; j++)
                {
                    byte[,] domain = GetDomain(Encodings[i, j].Xd, Encodings[i, j].Yd);
                    byte[,] sampledDomain = SampleDomain(domain);
                    byte[,] isometry = ApplyIsometry(Encodings[i, j].Isometry, sampledDomain);
                    ApplyScaleAndOffset(Encodings[i, j].SDequantized, Encodings[i, j].ODequantized, isometry);
                    int copyPositionI = i * 8;
                    int copyPositionJ = j * 8;
                    int a = 0;
                    int b = 0;
                    for (int m = copyPositionI; m < copyPositionI + 8; m++)
                    {
                        for (int n = copyPositionJ; n < copyPositionJ + 8; n++) 
                        {
                            AuxiliaryImage[m, n] = isometry[a, b];
                            b++;
                        }
                        b = 0;
                        a++;
                    }
                }
            }
            InitialImage = AuxiliaryImage;
            AuxiliaryImage = new byte[HEIGHT, WIDTH];
        }

        private byte[,] GetDomain(int xd, int yd)
        {
            int realI = xd * 8;
            int realJ = yd * 8;
            byte[,] result = new byte[16, 16];
            int a = 0;
            int b = 0;
            for (int i = realI; i < realI + 16; i++)
            {
                for (int j = realJ; j < realJ + 16; j++)
                {
                    result[a, b] = InitialImage[i, j];
                    b++;
                }
                b = 0;
                a++;
            }
            return result;
        }

        private byte[,] SampleDomain(byte[,] domain)
        {
            byte[,] result = new byte[8, 8];
            int a = 0;
            int b = 0;
            for (int i = 0; i < 16; i += 2)
            {
                for (int j = 0; j < 16; j += 2)
                {
                    int firstPixel = domain[i, j];
                    int secondPixel = domain[i, j + 1];
                    int thirdPixel = domain[i + 1, j];
                    int fourthPixel = domain[i + 1, j + 1];
                    int average = (int) (1.0 * firstPixel + secondPixel + thirdPixel + fourthPixel) / 4;
                    result[a, b] = (byte) average;
                    b++;
                }
                b = 0;
                a++;
            }
            return result;
        }

        private byte[,] ApplyIsometry(int isometry, byte[,] sampledDomain)
        {
            byte[,] result = new byte[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j ++)
                {
                    switch (isometry)
                    {
                        case IDENTICAL_TRANSFORM:
                            result[i, j] = sampledDomain[i, j];
                            break;
                        case VERTICAL_AXIS_MIRRORING:
                            result[i, j] = sampledDomain[i, EIGHT - 1 - j];
                            break;
                        case HORIZONTAL_AXIS_MIRRORING:
                            result[i, j] = sampledDomain[EIGHT - 1 - i, j];
                            break;
                        case FIRST_DIAGONAL_MIRRORING:
                            result[i, j] = sampledDomain[j, i];
                            break;
                        case SECOND_DIAGONAL_MIRRORING:
                            result[i, j] = sampledDomain[EIGHT - 1 - j, EIGHT - 1 - i];
                            break;
                        case CLOCKWISE_90_ROTATION:
                            result[i, j] = sampledDomain[EIGHT - 1 - j, i];
                            break;
                        case CLOCKWISE_180_ROTATION:
                            result[i, j] = sampledDomain[EIGHT - 1 - i, EIGHT - 1 - j];
                            break;
                        case CLOCKWISE_270_ROTATION:
                            result[i, j] = sampledDomain[j, EIGHT - 1 - i];
                            break;
                    }
                }
            }
            return result;
        }

        private void ApplyScaleAndOffset(double scale, double offset, byte[,] isometry)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    double value = isometry[i, j] * scale + offset;
                    int result = (int) value;
                    if (result > 255)
                    {
                        result = 255;
                    }

                    if (result < 0)
                    {
                        result = 0;
                    }
                    isometry[i, j] = (byte)result;
                }
            }
        }
    }
}
