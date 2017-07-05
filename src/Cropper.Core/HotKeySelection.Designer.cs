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
            this.actionHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shortcutHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shortcutAssign = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.shortcutKeyNames = new System.Windows.Forms.TextBox();
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
                this.shortcutHeader});
            this.shortcutList.FullRowSelect = true;
            this.shortcutList.GridLines = true;
            this.shortcutList.HideSelection = false;
            this.shortcutList.Location = new System.Drawing.Point(4, 3);
            this.shortcutList.Name = "shortcutList";
            this.shortcutList.Size = new System.Drawing.Size(312, 270);
            this.shortcutList.TabIndex = 1;
            this.shortcutList.UseCompatibleStateImageBehavior = false;
            this.shortcutList.View = System.Windows.Forms.View.Details;
            this.shortcutList.SelectedIndexChanged += new System.EventHandler(this.HandleShortcutListSelectedIndexChanged);
            // 
            // actionHeader
            // 
            this.actionHeader.Text = "Action";
            this.actionHeader.Width = 193;
            // 
            // shortcutHeader
            // 
            this.shortcutHeader.Text = "Shortcut";
            this.shortcutHeader.Width = 98;
            // 
            // shortcutAssign
            // 
            this.shortcutAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutAssign.Location = new System.Drawing.Point(241, 279);
            this.shortcutAssign.Name = "shortcutAssign";
            this.shortcutAssign.Size = new System.Drawing.Size(75, 26);
            this.shortcutAssign.TabIndex = 5;
            this.shortcutAssign.Text = "&Assign";
            this.shortcutAssign.Click += new System.EventHandler(this.HandleShortcutAssignClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Press &Key(s):";
            // 
            // shortcutKeyNames
            // 
            this.shortcutKeyNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                                                                                 | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutKeyNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shortcutKeyNames.Location = new System.Drawing.Point(78, 284);
            this.shortcutKeyNames.Name = "shortcutKeyNames";
            this.shortcutKeyNames.Size = new System.Drawing.Size(144, 13);
            this.shortcutKeyNames.TabIndex = 3;
            this.shortcutKeyNames.Enter += new System.EventHandler(this.HandleShortcutKeyNamesEnter);
            // 
            // shortcut
            // 
            this.shortcut.Alt = false;
            this.shortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                                                                         | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcut.Control = false;
            this.shortcut.KeyCode = System.Windows.Forms.Keys.None;
            this.shortcut.KeyData = System.Windows.Forms.Keys.None;
            this.shortcut.Location = new System.Drawing.Point(75, 281);
            this.shortcut.Mode = Fusion8.Cropper.Core.ShortcutMode.Global;
            this.shortcut.Modifiers = System.Windows.Forms.Keys.None;
            this.shortcut.Name = "shortcut";
            this.shortcut.Shift = false;
            this.shortcut.Size = new System.Drawing.Size(160, 20);
            this.shortcut.TabIndex = 4;
            this.shortcut.Text = "None";
            this.shortcut.Enter += new System.EventHandler(this.HandleShortcutEnter);
            this.shortcut.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleShortcutPreviewKeyDown);
            // 
            // HotKeySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shortcutKeyNames);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortcutList);
            this.Controls.Add(this.shortcutAssign);
            this.Controls.Add(this.shortcut);
            this.Name = "HotKeySelection";
            this.Size = new System.Drawing.Size(319, 308);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView shortcutList;
        private System.Windows.Forms.ColumnHeader actionHeader;
        private System.Windows.Forms.ColumnHeader shortcutHeader;
        private System.Windows.Forms.Button shortcutAssign;
        private ShortcutTextBox shortcut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortcutKeyNames;
    }
}