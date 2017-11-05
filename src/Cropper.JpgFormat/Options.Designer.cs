namespace Fusion8.Cropper
{
    partial class JpegOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioJpeg = new System.Windows.Forms.RadioButton();
            this.radioJpg = new System.Windows.Forms.RadioButton();
            this.themedTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioJpg);
            this.groupBox1.Controls.Add(this.radioJpeg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extension";
            // 
            // radioJpeg
            // 
            this.radioJpeg.AutoSize = true;
            this.radioJpeg.Checked = true;
            this.radioJpeg.Location = new System.Drawing.Point(7, 20);
            this.radioJpeg.Name = "radioJpeg";
            this.radioJpeg.Size = new System.Drawing.Size(45, 17);
            this.radioJpeg.TabIndex = 0;
            this.radioJpeg.TabStop = true;
            this.radioJpeg.Text = "jpeg";
            this.radioJpeg.UseVisualStyleBackColor = true;
            // 
            // radioJpg
            // 
            this.radioJpg.AutoSize = true;
            this.radioJpg.Location = new System.Drawing.Point(58, 20);
            this.radioJpg.Name = "radioJpg";
            this.radioJpg.Size = new System.Drawing.Size(39, 17);
            this.radioJpg.TabIndex = 1;
            this.radioJpg.TabStop = true;
            this.radioJpg.Text = "jpg";
            this.radioJpg.UseVisualStyleBackColor = true;
            // 
            // JpegOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(300, 276);
            this.Name = "JpegOptions";
            this.Text = "Options";
            this.themedTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioJpg;
        private System.Windows.Forms.RadioButton radioJpeg;
    }
}