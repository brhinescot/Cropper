#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

using System.Drawing;

namespace Fusion8.Cropper
{
    partial class Options
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
            this.radioJpg = new System.Windows.Forms.RadioButton();
            this.radioPng = new System.Windows.Forms.RadioButton();
            this.qualitySlider = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bitmapDescription = new System.Windows.Forms.Label();
            this.jpgDescription = new System.Windows.Forms.Label();
            this.imageQuality = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBitmap = new System.Windows.Forms.RadioButton();
            this.pngDescription = new System.Windows.Forms.Label();
            this.themedTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualitySlider)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // themedTabControl1
            // 
            this.themedTabControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.themedTabControl1.Location = new System.Drawing.Point(55, 403);
            this.themedTabControl1.Size = new System.Drawing.Size(298, 502);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(290, 476);
            this.tabPage1.Text = "Format";
            // 
            // radioJpg
            // 
            this.radioJpg.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioJpg, 2);
            this.radioJpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioJpg.Location = new System.Drawing.Point(3, 123);
            this.radioJpg.Name = "radioJpg";
            this.radioJpg.Size = new System.Drawing.Size(292, 17);
            this.radioJpg.TabIndex = 4;
            this.radioJpg.Text = "&Jpeg";
            this.radioJpg.UseVisualStyleBackColor = true;
            // 
            // radioPng
            // 
            this.radioPng.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioPng, 2);
            this.radioPng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPng.Location = new System.Drawing.Point(3, 63);
            this.radioPng.Name = "radioPng";
            this.radioPng.Size = new System.Drawing.Size(292, 17);
            this.radioPng.TabIndex = 2;
            this.radioPng.Text = "&Png";
            this.radioPng.UseVisualStyleBackColor = true;
            // 
            // qualitySlider
            // 
            this.qualitySlider.BackColor = System.Drawing.SystemColors.Control;
            this.qualitySlider.Dock = System.Windows.Forms.DockStyle.Top;
            this.qualitySlider.LargeChange = 10;
            this.qualitySlider.Location = new System.Drawing.Point(21, 208);
            this.qualitySlider.Maximum = 100;
            this.qualitySlider.Minimum = 10;
            this.qualitySlider.Name = "qualitySlider";
            this.qualitySlider.Size = new System.Drawing.Size(274, 45);
            this.qualitySlider.TabIndex = 7;
            this.qualitySlider.TickFrequency = 10;
            this.qualitySlider.Value = 80;
            this.qualitySlider.ValueChanged += new System.EventHandler(this.HandleQualitySliderValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(341, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bitmapDescription
            // 
            this.bitmapDescription.AutoSize = true;
            this.bitmapDescription.BackColor = System.Drawing.Color.Transparent;
            this.bitmapDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bitmapDescription.Location = new System.Drawing.Point(21, 23);
            this.bitmapDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 24);
            this.bitmapDescription.Name = "bitmapDescription";
            this.bitmapDescription.Size = new System.Drawing.Size(274, 13);
            this.bitmapDescription.TabIndex = 1;
            this.bitmapDescription.Text = "{Resourced}";
            // 
            // jpgDescription
            // 
            this.jpgDescription.AutoSize = true;
            this.jpgDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jpgDescription.Location = new System.Drawing.Point(21, 143);
            this.jpgDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 24);
            this.jpgDescription.Name = "jpgDescription";
            this.jpgDescription.Size = new System.Drawing.Size(274, 13);
            this.jpgDescription.TabIndex = 5;
            this.jpgDescription.Text = "{Resourced}";
            // 
            // imageQuality
            // 
            this.imageQuality.Location = new System.Drawing.Point(21, 180);
            this.imageQuality.Name = "imageQuality";
            this.imageQuality.Size = new System.Drawing.Size(248, 25);
            this.imageQuality.TabIndex = 6;
            this.imageQuality.Text = "{Resourced}";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.273063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.72694F));
            this.tableLayoutPanel1.Controls.Add(this.radioBitmap, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.qualitySlider, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.imageQuality, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.bitmapDescription, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.jpgDescription, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioPng, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pngDescription, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioJpg, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 326);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // radioBitmap
            // 
            this.radioBitmap.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioBitmap, 2);
            this.radioBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBitmap.Location = new System.Drawing.Point(3, 3);
            this.radioBitmap.Name = "radioBitmap";
            this.radioBitmap.Size = new System.Drawing.Size(292, 17);
            this.radioBitmap.TabIndex = 0;
            this.radioBitmap.Text = "&Bitmap";
            this.radioBitmap.UseVisualStyleBackColor = true;
            // 
            // pngDescription
            // 
            this.pngDescription.AutoSize = true;
            this.pngDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pngDescription.Location = new System.Drawing.Point(21, 83);
            this.pngDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 24);
            this.pngDescription.Name = "pngDescription";
            this.pngDescription.Size = new System.Drawing.Size(274, 13);
            this.pngDescription.TabIndex = 3;
            this.pngDescription.Text = "{Resourced}";
            // 
            // Options
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(298, 326);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Options";
            this.Text = "Options";
            this.Controls.SetChildIndex(this.themedTabControl1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.themedTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qualitySlider)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.RadioButton radioJpg;
        private System.Windows.Forms.RadioButton radioPng;
        private System.Windows.Forms.TrackBar qualitySlider;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label bitmapDescription;
        private System.Windows.Forms.Label jpgDescription;
        private System.Windows.Forms.Label imageQuality;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioBitmap;
        private System.Windows.Forms.Label pngDescription;
    }
}