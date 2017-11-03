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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shortcutList
            // 
            this.shortcutList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.shortcutAssign.AutoSize = true;
            this.shortcutAssign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcutAssign.Location = new System.Drawing.Point(217, 3);
            this.shortcutAssign.Name = "shortcutAssign";
            this.shortcutAssign.Size = new System.Drawing.Size(72, 22);
            this.shortcutAssign.TabIndex = 5;
            this.shortcutAssign.Text = "&Assign";
            this.shortcutAssign.Click += new System.EventHandler(this.HandleShortcutAssignClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(73, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Press &Key(s):";
            // 
            // shortcut
            // 
            this.shortcut.Alt = false;
            this.shortcut.Control = false;
            this.shortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shortcut.KeyCode = System.Windows.Forms.Keys.None;
            this.shortcut.KeyData = System.Windows.Forms.Keys.None;
            this.shortcut.Location = new System.Drawing.Point(76, 3);
            this.shortcut.Mode = Fusion8.Cropper.Core.ShortcutMode.Global;
            this.shortcut.Modifiers = System.Windows.Forms.Keys.None;
            this.shortcut.Name = "shortcut";
            this.shortcut.Shift = false;
            this.shortcut.Size = new System.Drawing.Size(135, 22);
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
            this.bottomPanel.Controls.Add(this.tableLayoutPanel1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 512);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(841, 48);
            this.bottomPanel.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.11215F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.88785F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Controls.Add(this.shortcutAssign, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.shortcut, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 28);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // HotKeySelection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "HotKeySelection";
            this.Size = new System.Drawing.Size(841, 560);
            this.topPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}