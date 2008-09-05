namespace Fusion8.Cropper.Core
{
    partial class HotKeySelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shortcutList = new System.Windows.Forms.ListView();
            this.actionHeader = new System.Windows.Forms.ColumnHeader();
            this.shortcutHeader = new System.Windows.Forms.ColumnHeader();
            this.globalHeader = new System.Windows.Forms.ColumnHeader();
            this.shortcutAssign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shortcut = new Fusion8.Cropper.Core.ShortcutTextBox();
            this.SuspendLayout();
            // 
            // shortcutList
            // 
            this.shortcutList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actionHeader,
            this.shortcutHeader,
            this.globalHeader});
            this.shortcutList.FullRowSelect = true;
            this.shortcutList.GridLines = true;
            this.shortcutList.HideSelection = false;
            this.shortcutList.Location = new System.Drawing.Point(3, 16);
            this.shortcutList.Name = "shortcutList";
            this.shortcutList.Size = new System.Drawing.Size(313, 198);
            this.shortcutList.TabIndex = 1;
            this.shortcutList.UseCompatibleStateImageBehavior = false;
            this.shortcutList.View = System.Windows.Forms.View.Details;
            this.shortcutList.SelectedIndexChanged += new System.EventHandler(this.HandleShortcutListSelectedIndexChanged);
            // 
            // actionHeader
            // 
            this.actionHeader.Text = "Action";
            this.actionHeader.Width = 73;
            // 
            // shortcutHeader
            // 
            this.shortcutHeader.Text = "Shortcut";
            this.shortcutHeader.Width = 124;
            // 
            // globalHeader
            // 
            this.globalHeader.Text = "Global";
            this.globalHeader.Width = 49;
            // 
            // shortcutAssign
            // 
            this.shortcutAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutAssign.Location = new System.Drawing.Point(241, 231);
            this.shortcutAssign.Name = "shortcutAssign";
            this.shortcutAssign.Size = new System.Drawing.Size(75, 26);
            this.shortcutAssign.TabIndex = 4;
            this.shortcutAssign.Text = "&Assign";
            this.shortcutAssign.UseVisualStyleBackColor = true;
            this.shortcutAssign.Click += new System.EventHandler(this.HandleShortcutAssignClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hot Key &List";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hot &Key";
            // 
            // shortcut
            // 
            this.shortcut.Alt = false;
            this.shortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcut.Control = false;
            this.shortcut.KeyCode = System.Windows.Forms.Keys.None;
            this.shortcut.KeyData = System.Windows.Forms.Keys.None;
            this.shortcut.Location = new System.Drawing.Point(3, 233);
            this.shortcut.Modifiers = System.Windows.Forms.Keys.None;
            this.shortcut.Name = "shortcut";
            this.shortcut.Shift = false;
            this.shortcut.Size = new System.Drawing.Size(232, 20);
            this.shortcut.TabIndex = 3;
            this.shortcut.Text = "None";
            this.shortcut.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleShortcutPreviewKeyDown);
            // 
            // HotKeySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shortcutList);
            this.Controls.Add(this.shortcutAssign);
            this.Controls.Add(this.shortcut);
            this.Name = "HotKeySelection";
            this.Size = new System.Drawing.Size(319, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView shortcutList;
        private System.Windows.Forms.ColumnHeader actionHeader;
        private System.Windows.Forms.ColumnHeader shortcutHeader;
        private System.Windows.Forms.ColumnHeader globalHeader;
        private System.Windows.Forms.Button shortcutAssign;
        private ShortcutTextBox shortcut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}