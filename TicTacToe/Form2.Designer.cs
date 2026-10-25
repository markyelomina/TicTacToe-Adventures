namespace TicTacToe
{
    partial class Form2
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
            this.backImage = new System.Windows.Forms.PictureBox();
            this.easyImage = new System.Windows.Forms.PictureBox();
            this.hardImage = new System.Windows.Forms.PictureBox();
            this.intermediateImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intermediateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // backImage
            // 
            this.backImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backImage.Image = global::TicTacToe.Properties.Resources.back;
            this.backImage.Location = new System.Drawing.Point(12, 12);
            this.backImage.Name = "backImage";
            this.backImage.Size = new System.Drawing.Size(100, 100);
            this.backImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backImage.TabIndex = 4;
            this.backImage.TabStop = false;
            this.backImage.Click += new System.EventHandler(this.backImage_Click);
            // 
            // easyImage
            // 
            this.easyImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.easyImage.Image = global::TicTacToe.Properties.Resources.easy;
            this.easyImage.Location = new System.Drawing.Point(483, 97);
            this.easyImage.Name = "easyImage";
            this.easyImage.Size = new System.Drawing.Size(300, 168);
            this.easyImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.easyImage.TabIndex = 3;
            this.easyImage.TabStop = false;
            this.easyImage.Click += new System.EventHandler(this.easyImage_Click);
            // 
            // hardImage
            // 
            this.hardImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hardImage.Image = global::TicTacToe.Properties.Resources.hard;
            this.hardImage.Location = new System.Drawing.Point(483, 445);
            this.hardImage.Name = "hardImage";
            this.hardImage.Size = new System.Drawing.Size(300, 168);
            this.hardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hardImage.TabIndex = 2;
            this.hardImage.TabStop = false;
            this.hardImage.Click += new System.EventHandler(this.hardImage_Click);
            // 
            // intermediateImage
            // 
            this.intermediateImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.intermediateImage.Image = global::TicTacToe.Properties.Resources.intermediate;
            this.intermediateImage.Location = new System.Drawing.Point(483, 271);
            this.intermediateImage.Name = "intermediateImage";
            this.intermediateImage.Size = new System.Drawing.Size(300, 168);
            this.intermediateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.intermediateImage.TabIndex = 1;
            this.intermediateImage.TabStop = false;
            this.intermediateImage.Click += new System.EventHandler(this.intermediateImage_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.backImage);
            this.Controls.Add(this.easyImage);
            this.Controls.Add(this.hardImage);
            this.Controls.Add(this.intermediateImage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Difficulty Select";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.backImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intermediateImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox intermediateImage;
        private System.Windows.Forms.PictureBox hardImage;
        private System.Windows.Forms.PictureBox easyImage;
        private System.Windows.Forms.PictureBox backImage;
    }
}