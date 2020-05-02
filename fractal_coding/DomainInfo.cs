using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractal_coding
{
    public class DomainInfo
    {
        const int WIDTH = 8;
        const int HEIGHT = 8;

        const int IDENTICAL_TRANSFORM = 0;
        const int VERTICAL_AXIS_MIRRORING = 1;
        const int HORIZONTAL_AXIS_MIRRORING = 2;
        const int FIRST_DIAGONAL_MIRRORING = 3;
        const int SECOND_DIAGONAL_MIRRORING = 4;
        const int CLOCKWISE_90_ROTATION = 5;
        const int CLOCKWISE_180_ROTATION = 6;
        const int CLOCKWISE_270_ROTATION = 7;

        public List<byte[,]> Isometries;
        public int SumOfPixels;
        public int SumOfSquaredPixels;
        public DomainInfo()
        {
            Isometries = new List<byte[,]>();
            SumOfPixels = 0;
            SumOfSquaredPixels = 0;
        }

        public void CalculateSumOfPixels()
        {
            byte[,] identity = Isometries[0];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    SumOfPixels += identity[i, j];
                }
            }
        }

        public void CalculateSumOfSquaredPixels()
        {
            byte[,] identity = Isometries[0];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    SumOfSquaredPixels += identity[i, j] * identity[i, j];
                }
            }
        }

        public void PopulateIsometries()
        {
            for (int i = 1; i < 8; i++)
            {
                byte[,] newIsometry = CalculateIsometry(i);
                Isometries.Add(newIsometry);
            }
        }

        private byte[,] CalculateIsometry(int isometry)
        {
            byte[,] result = new byte[8, 8];
            byte[,] identity = Isometries[0];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    switch (isometry)
                    {
                        case IDENTICAL_TRANSFORM:
                            result[i, j] = identity[i, j];
                            break;
                        case VERTICAL_AXIS_MIRRORING:
                            result[i, j] = identity[i, WIDTH - 1 - j];
                            break;
                        case HORIZONTAL_AXIS_MIRRORING:
                            result[i, j] = identity[HEIGHT - 1 - i, j];
                            break;
                        case FIRST_DIAGONAL_MIRRORING:
                            result[i, j] = identity[j, i];
                            break;
                        case SECOND_DIAGONAL_MIRRORING:
                            result[i, j] = identity[HEIGHT - 1 - j, WIDTH - 1 - i];
                            break;
                        case CLOCKWISE_90_ROTATION:
                            result[i, j] = identity[WIDTH - 1 - j, i];
                            break;
                        case CLOCKWISE_180_ROTATION:
                            result[i, j] = identity[HEIGHT - 1 - i, WIDTH - 1 - j];
                            break;
                        case CLOCKWISE_270_ROTATION:
                            result[i, j] = identity[j, WIDTH - 1 - i];
                            break;
                    }
                }
            }
            return result;
        }

        public void AddIdentityIsometry(byte [,] identity)
        {
            Isometries.Add(identity);
        }
    }
}
