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
        public Coder Coder;
        public Form1()
        {
            InitializeComponent();
            Coder = new Coder();
            Coder.Init();
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
            int isometry = Convert.ToInt32(NumberOfStepsNumericUpDown.Value);
            byte[,] result = Coder.ApplyIsometry(isometry);
            Bitmap bmp = new Bitmap(512, 512);
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    int color = result[i, j];
                    bmp.SetPixel(j, i, Color.FromArgb(color, color, color));
                }
            }
            DecodedImagePictureBox.Image = bmp;
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
    }
}
