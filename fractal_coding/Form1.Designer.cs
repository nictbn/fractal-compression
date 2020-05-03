namespace fractal_coding
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OriginalImagePictureBox = new System.Windows.Forms.PictureBox();
            this.DecodedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.ProcessProgressBar = new System.Windows.Forms.ProgressBar();
            this.CoderLoadButton = new System.Windows.Forms.Button();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.CoderSaveButton = new System.Windows.Forms.Button();
            this.RangePictureBox = new System.Windows.Forms.PictureBox();
            this.DomainPictureBox = new System.Windows.Forms.PictureBox();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.QuantizedOTextBox = new System.Windows.Forms.TextBox();
            this.QuantizedSTextBox = new System.Windows.Forms.TextBox();
            this.IsometryTextBox = new System.Windows.Forms.TextBox();
            this.YdTextBox = new System.Windows.Forms.TextBox();
            this.XdTextBox = new System.Windows.Forms.TextBox();
            this.XdLabel = new System.Windows.Forms.Label();
            this.YdLabel = new System.Windows.Forms.Label();
            this.IsometryLabel = new System.Windows.Forms.Label();
            this.QuantizedSLabel = new System.Windows.Forms.Label();
            this.QuantizedOLabel = new System.Windows.Forms.Label();
            this.DecoderSaveButton = new System.Windows.Forms.Button();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.DecoderLoadButton = new System.Windows.Forms.Button();
            this.LoadInitialImageButton = new System.Windows.Forms.Button();
            this.NumberOfStepsLabel = new System.Windows.Forms.Label();
            this.NumberOfStepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PSNRLabel = new System.Windows.Forms.Label();
            this.PSNRTextBox = new System.Windows.Forms.TextBox();
            this.ProcessBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecodedImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DomainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfStepsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalImagePictureBox
            // 
            this.OriginalImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.OriginalImagePictureBox.Name = "OriginalImagePictureBox";
            this.OriginalImagePictureBox.Size = new System.Drawing.Size(512, 512);
            this.OriginalImagePictureBox.TabIndex = 0;
            this.OriginalImagePictureBox.TabStop = false;
            // 
            // DecodedImagePictureBox
            // 
            this.DecodedImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DecodedImagePictureBox.Location = new System.Drawing.Point(573, 12);
            this.DecodedImagePictureBox.Name = "DecodedImagePictureBox";
            this.DecodedImagePictureBox.Size = new System.Drawing.Size(512, 512);
            this.DecodedImagePictureBox.TabIndex = 1;
            this.DecodedImagePictureBox.TabStop = false;
            // 
            // ProcessProgressBar
            // 
            this.ProcessProgressBar.Location = new System.Drawing.Point(12, 557);
            this.ProcessProgressBar.Maximum = 4096;
            this.ProcessProgressBar.Name = "ProcessProgressBar";
            this.ProcessProgressBar.Size = new System.Drawing.Size(1073, 23);
            this.ProcessProgressBar.TabIndex = 2;
            // 
            // CoderLoadButton
            // 
            this.CoderLoadButton.Location = new System.Drawing.Point(12, 595);
            this.CoderLoadButton.Name = "CoderLoadButton";
            this.CoderLoadButton.Size = new System.Drawing.Size(75, 23);
            this.CoderLoadButton.TabIndex = 3;
            this.CoderLoadButton.Text = "Load";
            this.CoderLoadButton.UseVisualStyleBackColor = true;
            this.CoderLoadButton.Click += new System.EventHandler(this.CoderLoadButton_Click);
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(12, 624);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(75, 23);
            this.ProcessButton.TabIndex = 4;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // CoderSaveButton
            // 
            this.CoderSaveButton.Location = new System.Drawing.Point(12, 653);
            this.CoderSaveButton.Name = "CoderSaveButton";
            this.CoderSaveButton.Size = new System.Drawing.Size(75, 23);
            this.CoderSaveButton.TabIndex = 5;
            this.CoderSaveButton.Text = "Save";
            this.CoderSaveButton.UseVisualStyleBackColor = true;
            this.CoderSaveButton.Click += new System.EventHandler(this.CoderSaveButton_Click);
            // 
            // RangePictureBox
            // 
            this.RangePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RangePictureBox.Location = new System.Drawing.Point(396, 691);
            this.RangePictureBox.Name = "RangePictureBox";
            this.RangePictureBox.Size = new System.Drawing.Size(80, 80);
            this.RangePictureBox.TabIndex = 6;
            this.RangePictureBox.TabStop = false;
            // 
            // DomainPictureBox
            // 
            this.DomainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DomainPictureBox.Location = new System.Drawing.Point(514, 611);
            this.DomainPictureBox.Name = "DomainPictureBox";
            this.DomainPictureBox.Size = new System.Drawing.Size(160, 160);
            this.DomainPictureBox.TabIndex = 7;
            this.DomainPictureBox.TabStop = false;
            // 
            // DomainLabel
            // 
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainLabel.Location = new System.Drawing.Point(511, 595);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(103, 13);
            this.DomainLabel.TabIndex = 8;
            this.DomainLabel.Text = "Selected Domain";
            // 
            // RangeLabel
            // 
            this.RangeLabel.AutoSize = true;
            this.RangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeLabel.Location = new System.Drawing.Point(393, 672);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(98, 13);
            this.RangeLabel.TabIndex = 9;
            this.RangeLabel.Text = "Selected Range";
            // 
            // QuantizedOTextBox
            // 
            this.QuantizedOTextBox.Location = new System.Drawing.Point(111, 751);
            this.QuantizedOTextBox.Name = "QuantizedOTextBox";
            this.QuantizedOTextBox.ReadOnly = true;
            this.QuantizedOTextBox.Size = new System.Drawing.Size(75, 20);
            this.QuantizedOTextBox.TabIndex = 10;
            this.QuantizedOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // QuantizedSTextBox
            // 
            this.QuantizedSTextBox.Location = new System.Drawing.Point(111, 703);
            this.QuantizedSTextBox.Name = "QuantizedSTextBox";
            this.QuantizedSTextBox.ReadOnly = true;
            this.QuantizedSTextBox.Size = new System.Drawing.Size(75, 20);
            this.QuantizedSTextBox.TabIndex = 11;
            this.QuantizedSTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IsometryTextBox
            // 
            this.IsometryTextBox.Location = new System.Drawing.Point(111, 653);
            this.IsometryTextBox.Name = "IsometryTextBox";
            this.IsometryTextBox.ReadOnly = true;
            this.IsometryTextBox.Size = new System.Drawing.Size(75, 20);
            this.IsometryTextBox.TabIndex = 12;
            this.IsometryTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // YdTextBox
            // 
            this.YdTextBox.Location = new System.Drawing.Point(12, 748);
            this.YdTextBox.Name = "YdTextBox";
            this.YdTextBox.ReadOnly = true;
            this.YdTextBox.Size = new System.Drawing.Size(75, 20);
            this.YdTextBox.TabIndex = 13;
            this.YdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // XdTextBox
            // 
            this.XdTextBox.Location = new System.Drawing.Point(15, 703);
            this.XdTextBox.Name = "XdTextBox";
            this.XdTextBox.ReadOnly = true;
            this.XdTextBox.Size = new System.Drawing.Size(72, 20);
            this.XdTextBox.TabIndex = 14;
            this.XdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // XdLabel
            // 
            this.XdLabel.AutoSize = true;
            this.XdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XdLabel.Location = new System.Drawing.Point(12, 687);
            this.XdLabel.Name = "XdLabel";
            this.XdLabel.Size = new System.Drawing.Size(26, 13);
            this.XdLabel.TabIndex = 15;
            this.XdLabel.Text = "Xd:";
            // 
            // YdLabel
            // 
            this.YdLabel.AutoSize = true;
            this.YdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YdLabel.Location = new System.Drawing.Point(12, 732);
            this.YdLabel.Name = "YdLabel";
            this.YdLabel.Size = new System.Drawing.Size(26, 13);
            this.YdLabel.TabIndex = 16;
            this.YdLabel.Text = "Yd:";
            // 
            // IsometryLabel
            // 
            this.IsometryLabel.AutoSize = true;
            this.IsometryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsometryLabel.Location = new System.Drawing.Point(111, 637);
            this.IsometryLabel.Name = "IsometryLabel";
            this.IsometryLabel.Size = new System.Drawing.Size(58, 13);
            this.IsometryLabel.TabIndex = 17;
            this.IsometryLabel.Text = "Isometry:";
            // 
            // QuantizedSLabel
            // 
            this.QuantizedSLabel.AutoSize = true;
            this.QuantizedSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantizedSLabel.Location = new System.Drawing.Point(111, 687);
            this.QuantizedSLabel.Name = "QuantizedSLabel";
            this.QuantizedSLabel.Size = new System.Drawing.Size(80, 13);
            this.QuantizedSLabel.TabIndex = 18;
            this.QuantizedSLabel.Text = "Quantized S:";
            // 
            // QuantizedOLabel
            // 
            this.QuantizedOLabel.AutoSize = true;
            this.QuantizedOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantizedOLabel.Location = new System.Drawing.Point(111, 735);
            this.QuantizedOLabel.Name = "QuantizedOLabel";
            this.QuantizedOLabel.Size = new System.Drawing.Size(81, 13);
            this.QuantizedOLabel.TabIndex = 19;
            this.QuantizedOLabel.Text = "Quantized O:";
            // 
            // DecoderSaveButton
            // 
            this.DecoderSaveButton.Location = new System.Drawing.Point(969, 653);
            this.DecoderSaveButton.Name = "DecoderSaveButton";
            this.DecoderSaveButton.Size = new System.Drawing.Size(103, 23);
            this.DecoderSaveButton.TabIndex = 22;
            this.DecoderSaveButton.Text = "Save";
            this.DecoderSaveButton.UseVisualStyleBackColor = true;
            // 
            // DecodeButton
            // 
            this.DecodeButton.Location = new System.Drawing.Point(969, 624);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(103, 23);
            this.DecodeButton.TabIndex = 21;
            this.DecodeButton.Text = "Decode # steps";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // DecoderLoadButton
            // 
            this.DecoderLoadButton.Location = new System.Drawing.Point(969, 595);
            this.DecoderLoadButton.Name = "DecoderLoadButton";
            this.DecoderLoadButton.Size = new System.Drawing.Size(103, 23);
            this.DecoderLoadButton.TabIndex = 20;
            this.DecoderLoadButton.Text = "Load";
            this.DecoderLoadButton.UseVisualStyleBackColor = true;
            // 
            // LoadInitialImageButton
            // 
            this.LoadInitialImageButton.Location = new System.Drawing.Point(776, 595);
            this.LoadInitialImageButton.Name = "LoadInitialImageButton";
            this.LoadInitialImageButton.Size = new System.Drawing.Size(103, 23);
            this.LoadInitialImageButton.TabIndex = 23;
            this.LoadInitialImageButton.Text = "Load Initial";
            this.LoadInitialImageButton.UseVisualStyleBackColor = true;
            // 
            // NumberOfStepsLabel
            // 
            this.NumberOfStepsLabel.AutoSize = true;
            this.NumberOfStepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfStepsLabel.Location = new System.Drawing.Point(773, 637);
            this.NumberOfStepsLabel.Name = "NumberOfStepsLabel";
            this.NumberOfStepsLabel.Size = new System.Drawing.Size(105, 13);
            this.NumberOfStepsLabel.TabIndex = 25;
            this.NumberOfStepsLabel.Text = "Number of Steps:";
            // 
            // NumberOfStepsNumericUpDown
            // 
            this.NumberOfStepsNumericUpDown.Location = new System.Drawing.Point(776, 653);
            this.NumberOfStepsNumericUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NumberOfStepsNumericUpDown.Name = "NumberOfStepsNumericUpDown";
            this.NumberOfStepsNumericUpDown.ReadOnly = true;
            this.NumberOfStepsNumericUpDown.Size = new System.Drawing.Size(103, 20);
            this.NumberOfStepsNumericUpDown.TabIndex = 26;
            this.NumberOfStepsNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PSNRLabel
            // 
            this.PSNRLabel.AutoSize = true;
            this.PSNRLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSNRLabel.Location = new System.Drawing.Point(776, 687);
            this.PSNRLabel.Name = "PSNRLabel";
            this.PSNRLabel.Size = new System.Drawing.Size(45, 13);
            this.PSNRLabel.TabIndex = 28;
            this.PSNRLabel.Text = "PSNR:";
            // 
            // PSNRTextBox
            // 
            this.PSNRTextBox.Location = new System.Drawing.Point(776, 703);
            this.PSNRTextBox.Name = "PSNRTextBox";
            this.PSNRTextBox.ReadOnly = true;
            this.PSNRTextBox.Size = new System.Drawing.Size(103, 20);
            this.PSNRTextBox.TabIndex = 27;
            this.PSNRTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProcessBackgroundWorker
            // 
            this.ProcessBackgroundWorker.WorkerReportsProgress = true;
            this.ProcessBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessBackgroundWorker_DoWork);
            this.ProcessBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProcessBackgroundWorker_ProgressChanged);
            this.ProcessBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ProcessBackgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 776);
            this.Controls.Add(this.PSNRLabel);
            this.Controls.Add(this.PSNRTextBox);
            this.Controls.Add(this.NumberOfStepsNumericUpDown);
            this.Controls.Add(this.NumberOfStepsLabel);
            this.Controls.Add(this.LoadInitialImageButton);
            this.Controls.Add(this.DecoderSaveButton);
            this.Controls.Add(this.DecodeButton);
            this.Controls.Add(this.DecoderLoadButton);
            this.Controls.Add(this.QuantizedOLabel);
            this.Controls.Add(this.QuantizedSLabel);
            this.Controls.Add(this.IsometryLabel);
            this.Controls.Add(this.YdLabel);
            this.Controls.Add(this.XdLabel);
            this.Controls.Add(this.XdTextBox);
            this.Controls.Add(this.YdTextBox);
            this.Controls.Add(this.IsometryTextBox);
            this.Controls.Add(this.QuantizedSTextBox);
            this.Controls.Add(this.QuantizedOTextBox);
            this.Controls.Add(this.RangeLabel);
            this.Controls.Add(this.DomainLabel);
            this.Controls.Add(this.DomainPictureBox);
            this.Controls.Add(this.RangePictureBox);
            this.Controls.Add(this.CoderSaveButton);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.CoderLoadButton);
            this.Controls.Add(this.ProcessProgressBar);
            this.Controls.Add(this.DecodedImagePictureBox);
            this.Controls.Add(this.OriginalImagePictureBox);
            this.Name = "Form1";
            this.Text = "Fractal Coding";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecodedImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DomainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfStepsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OriginalImagePictureBox;
        private System.Windows.Forms.PictureBox DecodedImagePictureBox;
        private System.Windows.Forms.ProgressBar ProcessProgressBar;
        private System.Windows.Forms.Button CoderLoadButton;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Button CoderSaveButton;
        private System.Windows.Forms.PictureBox RangePictureBox;
        private System.Windows.Forms.PictureBox DomainPictureBox;
        private System.Windows.Forms.Label DomainLabel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.TextBox QuantizedOTextBox;
        private System.Windows.Forms.TextBox QuantizedSTextBox;
        private System.Windows.Forms.TextBox IsometryTextBox;
        private System.Windows.Forms.TextBox YdTextBox;
        private System.Windows.Forms.TextBox XdTextBox;
        private System.Windows.Forms.Label XdLabel;
        private System.Windows.Forms.Label YdLabel;
        private System.Windows.Forms.Label IsometryLabel;
        private System.Windows.Forms.Label QuantizedSLabel;
        private System.Windows.Forms.Label QuantizedOLabel;
        private System.Windows.Forms.Button DecoderSaveButton;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Button DecoderLoadButton;
        private System.Windows.Forms.Button LoadInitialImageButton;
        private System.Windows.Forms.Label NumberOfStepsLabel;
        private System.Windows.Forms.NumericUpDown NumberOfStepsNumericUpDown;
        private System.Windows.Forms.Label PSNRLabel;
        private System.Windows.Forms.TextBox PSNRTextBox;
        private System.ComponentModel.BackgroundWorker ProcessBackgroundWorker;
    }
}

