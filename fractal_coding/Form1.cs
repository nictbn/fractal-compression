using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractal_coding
{
    public partial class Form1 : Form
    {
        public string OriginalImagePath;
        public string InitialImagePath;
        public string EncodedImagePath;
        public Coder Coder;
        public Decoder Decoder;
        public Bitmap CleanImage = new Bitmap(512, 512);
        public Form1()
        {
            InitializeComponent();
            Coder = new Coder();
            Decoder = new Decoder();
            Coder.Init();
            Decoder.Init();
        }

        private void CoderLoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\School";
                openFileDialog.Filter = "BMP FIles (*.bmp)|*.BMP";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OriginalImagePath = openFileDialog.FileName;
                    Coder.ParseImage(openFileDialog.FileName);
                    using (var bmpTemp = new Bitmap(OriginalImagePath))
                    {
                        OriginalImagePictureBox.Image = new Bitmap(bmpTemp);
                        CleanImage = new Bitmap(bmpTemp);
                    }
                }
            }
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            ProcessBackgroundWorker.RunWorkerAsync();
        }

        private void CoderSaveButton_Click(object sender, EventArgs e)
        {
            Coder.SaveCoding();
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            int numberOfSteps = Convert.ToInt32(NumberOfStepsNumericUpDown.Value);
            Decoder.ApplyTransforms(numberOfSteps);
            Bitmap resultingImage = new Bitmap(512, 512);
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int color = Decoder.InitialImage[i, j];
                    resultingImage.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
            DecodedImagePictureBox.Image = resultingImage;
            CalculatePSNR();
        }

        private void CalculatePSNR()
        {
            double maxError = GetCoderImageMaxIntensity();
            double nominator = maxError * maxError * 512D * 512D;
            double denominator = GetSumOfSquaredDifferences();
            double fraction = 1;
            if (denominator != 0)
            {
                fraction = nominator / denominator;
            }
            double PSNR = 10 * Math.Log10(fraction);
            PSNRTextBox.Text = PSNR.ToString();
        }

        private double GetSumOfSquaredDifferences()
        {
            double result = 0.0;
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    double original = Coder.Image[i, j];
                    double decoded = Decoder.InitialImage[i, j];
                    double squaredDifference = (original - decoded) * (original - decoded);
                    result += squaredDifference;
                }
            }
            return result;
        }

        private double GetCoderImageMaxIntensity()
        {
            double maxIntensity = 0.0;
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    double currentIntensity = Coder.Image[i, j];
                    if ( maxIntensity < currentIntensity)
                    {
                        maxIntensity = currentIntensity;
                    }
                }
            }
            return maxIntensity;
        }

        private void ProcessBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Coder.ProcessImage(ProcessBackgroundWorker);
            e.Result = 0;
        }

        private void ProcessBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProcessProgressBar.Value = e.ProgressPercentage;
        }

        private void ProcessBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProcessProgressBar.Value = (int)e.Result;
        }

        private void OriginalImagePictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            label1.Text = coordinates.X.ToString();
            label2.Text = coordinates.Y.ToString();
            int x = coordinates.X;
            int y = coordinates.Y;
            if (y < 0)
            {
                y = 0;
            }
            if (y > 511)
            {
                y = 511;
            }
            if (x < 0)
            {
                x = 0;
            }
            if (x > 511)
            {
                x = 511;
            }
            x = x / 8;
            y = y / 8;
            Encoding encoding = Coder.Encodings[y, x];
            XdTextBox.Text = encoding.Xd.ToString();
            YdTextBox.Text = encoding.Yd.ToString();
            int xd = encoding.Xd * 8;
            int yd = encoding.Yd * 8;
            IsometryTextBox.Text = encoding.Isometry.ToString();
            QuantizedSTextBox.Text = encoding.SQuantized.ToString();
            QuantizedOTextBox.Text = encoding.OQuantized.ToString();
            Bitmap imageWithBlocks = new Bitmap(CleanImage);
            using (Graphics g = Graphics.FromImage(imageWithBlocks))
            {
                Pen whitePen = new Pen(Color.White, 1);
                Rectangle smallRectangle = new Rectangle(x * 8, y * 8, 8, 8);
                Rectangle bigRectangle = new Rectangle(yd, xd, 16, 16);
                g.DrawRectangle(whitePen, smallRectangle);
                g.DrawRectangle(whitePen, bigRectangle);
            }
            OriginalImagePictureBox.Image = imageWithBlocks;

            Bitmap range = GenerateBitmap(y * 8, x * 8, 8, Coder.Image);
            Bitmap domain = GenerateBitmap(xd, yd, 16, Coder.Image);
            RangePictureBox.Image = range;
            DomainPictureBox.Image = domain;
        }

        private Bitmap GenerateBitmap(int line, int column, int scanDimension, byte[,] image)
        {
            byte[,] result = new byte[scanDimension * 10, scanDimension * 10];
            byte[,] minimizedImage = new byte[scanDimension, scanDimension];
            int a = 0;
            int b = 0;
            for (int i = line; i < line + scanDimension; i++)
            {
                for (int j = column; j < column + scanDimension; j++)
                {
                    minimizedImage[a, b] = image[i, j];
                    b++;
                }
                b = 0;
                a++;
            }

            for (int i = 0; i < scanDimension; i++)
            {
                for (int j = 0; j < scanDimension; j++)
                {
                    byte pixel = minimizedImage[i, j];
                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            int positionI = i * 10 + k;
                            int positionJ = j * 10 + l;
                            result[positionI, positionJ] = pixel;
                        }
                    }
                }
            }

            Bitmap resultBitmap = new Bitmap(scanDimension * 10, scanDimension * 10);
            for (int i = 0; i < scanDimension * 10; i++)
            {
                for (int j = 0; j < scanDimension * 10; j++)
                {
                    byte color = result[i, j];
                    resultBitmap.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
            return resultBitmap;
        }

        private void LoadInitialImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\School";
                openFileDialog.Filter = "BMP FIles (*.bmp)|*.BMP";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    InitialImagePath = openFileDialog.FileName;
                    Decoder.ParseImage(InitialImagePath);
                    using (var bmpTemp = new Bitmap(InitialImagePath))
                    {
                        DecodedImagePictureBox.Image = new Bitmap(bmpTemp);
                    }
                }
            }
        }

        private void DecoderLoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\School";
                openFileDialog.Filter = "Fractal Files (*.f)|*.f";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EncodedImagePath = openFileDialog.FileName;
                    Decoder.LoadEncodings(EncodedImagePath);
                }
            } 
        }

        private void DecoderSaveButton_Click(object sender, EventArgs e)
        {
            Decoder.SaveDecodedImage();
        }

        private void DecodedImagePictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            int x = coordinates.X;
            int y = coordinates.Y;
            if (y < 0)
            {
                y = 0;
            }
            if (y > 511)
            {
                y = 511;
            }
            if (x < 0)
            {
                x = 0;
            }
            if (x > 511)
            {
                x = 511;
            }
            x = x / 8;
            y = y / 8;
            Encoding encoding = Decoder.Encodings[y, x];
            XdTextBox.Text = encoding.Xd.ToString();
            YdTextBox.Text = encoding.Yd.ToString();
            int xd = encoding.Xd * 8;
            int yd = encoding.Yd * 8;
            IsometryTextBox.Text = encoding.Isometry.ToString();
            QuantizedSTextBox.Text = encoding.SQuantized.ToString();
            QuantizedOTextBox.Text = encoding.OQuantized.ToString();
            Bitmap imageWithBlocks = new Bitmap(512, 512);
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int color = Decoder.InitialImage[i, j];
                    imageWithBlocks.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
            using (Graphics g = Graphics.FromImage(imageWithBlocks))
            {
                Pen whitePen = new Pen(Color.White, 1);
                Rectangle smallRectangle = new Rectangle(x * 8, y * 8, 8, 8);
                Rectangle bigRectangle = new Rectangle(yd, xd, 16, 16);
                g.DrawRectangle(whitePen, smallRectangle);
                g.DrawRectangle(whitePen, bigRectangle);
            }
            DecodedImagePictureBox.Image = imageWithBlocks;
            
            Bitmap range = GenerateBitmap(y * 8, x * 8, 8, Decoder.InitialImage);
            Bitmap domain = GenerateBitmap(xd, yd, 16, Decoder.InitialImage);
            RangePictureBox.Image = range;
            DomainPictureBox.Image = domain;
            
        }
    }
}
