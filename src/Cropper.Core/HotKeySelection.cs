using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core
{
    public partial class HotKeySelection : UserControl
    {
        public HotKeySelection()
        {
            InitializeComponent();
        }

        private void HandleShorcutAssignClick(object sender, EventArgs e)
        {
            shortcutList.SelectedItems[0].SubItems[1].Text = shortcut.Text;
        }

        private void HandleShortcutListSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}