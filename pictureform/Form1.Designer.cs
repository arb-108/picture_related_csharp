﻿namespace pictureform
{
    partial class pics
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
            this.pictureBoxzoom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxzoom)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxzoom
            // 
            this.pictureBoxzoom.Location = new System.Drawing.Point(25, 12);
            this.pictureBoxzoom.Name = "pictureBoxzoom";
            this.pictureBoxzoom.Size = new System.Drawing.Size(343, 407);
            this.pictureBoxzoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxzoom.TabIndex = 0;
            this.pictureBoxzoom.TabStop = false;
            // 
            // pics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.pictureBoxzoom);
            this.MaximizeBox = false;
            this.Name = "pics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxzoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxzoom;
    }
}