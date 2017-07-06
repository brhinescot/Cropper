#region Using Directives

using System;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     Summary description for Prompt.
    /// </summary>
    public class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        public string Value
        {
            get => promptText.Text;
            set => promptText.Text = value;
        }

        private static bool ValidateFileName(string name)
        {
            return !(name.IndexOfAny(new[] {'/', '*', ':', '?', '"', '<', '>', '|'}) >= 0);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.promptText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(128, 64);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 29);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&OK";
            this.okButton.Click += new System.EventHandler(this.HandleOkClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(208, 64);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Skip";
            this.cancelButton.Click += new System.EventHandler(this.HandleCancelClick);
            // 
            // promptText
            // 
            this.promptText.Location = new System.Drawing.Point(16, 32);
            this.promptText.Name = "promptText";
            this.promptText.Size = new System.Drawing.Size(264, 20);
            this.promptText.TabIndex = 1;
            this.promptText.TextChanged += new System.EventHandler(this.HandlePromptTextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Enter text for the template prompt.";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // Prompt
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(298, 107);
            this.Controls.Add(this.promptText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prompt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Prompt";
            ((System.ComponentModel.ISupportInitialize) (this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private void HandleOkClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void HandleCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void HandlePromptTextChanged(object sender, EventArgs e)
        {
            TextBox validateBox = sender as TextBox;
            if (validateBox == null)
                return;

            if (!ValidateFileName(validateBox.Text))
            {
                errorProvider.SetError(validateBox, SR.MessageInvalidTemplateCharacters);
                okButton.Enabled = false;
            }
            else
            {
                errorProvider.SetError(validateBox, string.Empty);
                okButton.Enabled = true;
            }
        }

        #region Member Fields

        private Button okButton;
        private Button cancelButton;
        private TextBox promptText;
        private Label label1;
        private ErrorProvider errorProvider;
        private IContainer components;

        #endregion
    }
}