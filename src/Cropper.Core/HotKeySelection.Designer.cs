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
            this.shortcut = new Fusion8.Cropper.Core.ShortcutTextBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.bottomLeftPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.bottomRightPanel.SuspendLayout();
            this.bottomLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shortcutList
            // 
            this.shortcutList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actionHeader,
            this.shortcutHeader});
            this.shortcutList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutList.FullRowSelect = true;
            this.shortcutList.GridLines = true;
            this.shortcutList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.shortcutList.HideSelection = false;
            this.shortcutList.Location = new System.Drawing.Point(0, 0);
            this.shortcutList.MultiSelect = false;
            this.shortcutList.Name = "shortcutList";
            this.shortcutList.Size = new System.Drawing.Size(841, 512);
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
            this.shortcutAssign.Location = new System.Drawing.Point(6, 6);
            this.shortcutAssign.Name = "shortcutAssign";
            this.shortcutAssign.Size = new System.Drawing.Size(75, 26);
            this.shortcutAssign.TabIndex = 5;
            this.shortcutAssign.Text = "&Assign";
            this.shortcutAssign.Click += new System.EventHandler(this.HandleShortcutAssignClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Press &Key(s):";
            // 
            // shortcut
            // 
            this.shortcut.Alt = false;
            this.shortcut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcut.Control = false;
            this.shortcut.KeyCode = System.Windows.Forms.Keys.None;
            this.shortcut.KeyData = System.Windows.Forms.Keys.None;
            this.shortcut.Location = new System.Drawing.Point(77, 9);
            this.shortcut.Mode = Fusion8.Cropper.Core.ShortcutMode.Global;
            this.shortcut.Modifiers = System.Windows.Forms.Keys.None;
            this.shortcut.Name = "shortcut";
            this.shortcut.Shift = false;
            this.shortcut.Size = new System.Drawing.Size(669, 20);
            this.shortcut.TabIndex = 4;
            this.shortcut.Text = "None";
            this.shortcut.Enter += new System.EventHandler(this.HandleShortcutEnter);
            this.shortcut.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HandleShortcutPreviewKeyDown);
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPanel.Controls.Add(this.shortcutList);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(841, 512);
            this.topPanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.bottomLeftPanel);
            this.bottomPanel.Controls.Add(this.bottomRightPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 512);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(841, 48);
            this.bottomPanel.TabIndex = 7;
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.Controls.Add(this.shortcutAssign);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bottomRightPanel.Location = new System.Drawing.Point(752, 0);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Size = new System.Drawing.Size(89, 48);
            this.bottomRightPanel.TabIndex = 6;
            // 
            // bottomLeftPanel
            // 
            this.bottomLeftPanel.Controls.Add(this.shortcut);
            this.bottomLeftPanel.Controls.Add(this.label2);
            this.bottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomLeftPanel.Name = "bottomLeftPanel";
            this.bottomLeftPanel.Size = new System.Drawing.Size(752, 48);
            this.bottomLeftPanel.TabIndex = 7;
            // 
            // HotKeySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "HotKeySelection";
            this.Size = new System.Drawing.Size(841, 560);
            this.topPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.bottomRightPanel.ResumeLayout(false);
            this.bottomLeftPanel.ResumeLayout(false);
            this.bottomLeftPanel.PerformLayout();
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
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel bottomLeftPanel;
        private System.Windows.Forms.Panel bottomRightPanel;
    }
}