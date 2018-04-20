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
            this.radioJpg = new System.Windows.Forms.RadioButton();
            this.radioJpeg = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.themedTabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // themedTabControl1
            // 
            this.themedTabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.themedTabControl1.Location = new System.Drawing.Point(19, 161);
            this.themedTabControl1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extension";
            // 
            // radioJpg
            // 
            this.radioJpg.AutoSize = true;
            this.radioJpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioJpg.Location = new System.Drawing.Point(90, 3);
            this.radioJpg.Name = "radioJpg";
            this.radioJpg.Size = new System.Drawing.Size(107, 52);
            this.radioJpg.TabIndex = 1;
            this.radioJpg.TabStop = true;
            this.radioJpg.Text = "jpg";
            this.radioJpg.UseVisualStyleBackColor = true;
            // 
            // radioJpeg
            // 
            this.radioJpeg.AutoSize = true;
            this.radioJpeg.Checked = true;
            this.radioJpeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioJpeg.Location = new System.Drawing.Point(3, 3);
            this.radioJpeg.Name = "radioJpeg";
            this.radioJpeg.Size = new System.Drawing.Size(81, 52);
            this.radioJpeg.TabIndex = 0;
            this.radioJpeg.TabStop = true;
            this.radioJpeg.Text = "jpeg";
            this.radioJpeg.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.Controls.Add(this.radioJpg, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioJpeg, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 58);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // JpegOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(300, 276);
            this.Controls.Add(this.groupBox1);
            this.Name = "JpegOptions";
            this.Text = "Options";
            this.Controls.SetChildIndex(this.themedTabControl1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.themedTabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioJpg;
        private System.Windows.Forms.RadioButton radioJpeg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}