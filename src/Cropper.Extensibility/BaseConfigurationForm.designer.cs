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

        protected CustomThemedTabControl ConfigurationTabControl;
        protected TabPage FirstTabPage;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ConfigurationTabControl = new CustomThemedTabControl();
            this.FirstTabPage = new TabPage();
            this.ConfigurationTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigurationTabControl
            // 
            this.ConfigurationTabControl.Controls.Add(this.FirstTabPage);
            this.ConfigurationTabControl.Dock = DockStyle.Fill;
            this.ConfigurationTabControl.Location = new Point(0, 0);
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.Size = new Size(300, 276);
            this.ConfigurationTabControl.TabIndex = 0;
            // 
            // FirstTabPage
            // 
            this.FirstTabPage.Location = new Point(4, 22);
            this.FirstTabPage.Name = "FirstTabPage";
            this.FirstTabPage.Padding = new Padding(3);
            this.FirstTabPage.Size = new Size(292, 250);
            this.FirstTabPage.TabIndex = 0;
            this.FirstTabPage.Text = "General";
            this.FirstTabPage.UseVisualStyleBackColor = true;
            // 
            // BaseConfigurationForm
            // 
            this.ClientSize = new Size(300, 276);
            this.Controls.Add(this.ConfigurationTabControl);
            this.Name = "BaseConfigurationForm";
            this.ConfigurationTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
