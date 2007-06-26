using System.Drawing;
using System.Windows.Forms;

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    /// 
    /// </summary>
    partial class BaseConfigurationForm
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

        protected CustomThemedTabControl themedTabControl1;
        protected TabPage tabPage1;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.themedTabControl1 = new CustomThemedTabControl();
            this.tabPage1 = new TabPage();
            this.themedTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigurationTabControl
            // 
            this.themedTabControl1.Controls.Add(this.tabPage1);
            this.themedTabControl1.Dock = DockStyle.Fill;
            this.themedTabControl1.Location = new Point(0, 0);
            this.themedTabControl1.Name = "themedTabControl1";
            this.themedTabControl1.SelectedIndex = 0;
            this.themedTabControl1.Size = new Size(300, 276);
            this.themedTabControl1.TabIndex = 0;
            // 
            // FirstTabPage
            // 
            this.tabPage1.Location = new Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(292, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BaseConfigurationForm
            // 
            this.ClientSize = new Size(300, 276);
            this.Controls.Add(this.themedTabControl1);
            this.Name = "BaseConfigurationForm";
            this.themedTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
