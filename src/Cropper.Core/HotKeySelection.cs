#region Using Directives

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    public partial class HotKeySelection : UserControl
    {
        public event EventHandler<HotKeyRegistrationEventArgs> HotKeyRegister;

        public HotKeySelection()
        {
            InitializeComponent();

            SelectFirst();
        }

        private void SelectFirst()
        {
            if (shortcutList.Items.Count <= 0)
                return;
            shortcutList.Focus();
            shortcutList.Items[0].Selected = true;
        }

        public void AddRange(IEnumerable<HotKeyData> hotKeyData)
        {
            if (hotKeyData == null)
                return;

            foreach (HotKeyData keyAction in hotKeyData)
            {
                ListViewItem item = new ListViewItem(new[] {keyAction.Name, ShortcutTextBox.GetShorcutText(keyAction.KeyData)})
                {
                    Tag = keyAction,
                    ForeColor = keyAction.Hide ? SystemColors.GrayText : SystemColors.ControlText
                };

                if (!string.IsNullOrEmpty(keyAction.Group))
                {
                    ListViewGroup listGroup = null;
                    foreach (ListViewGroup g in Groups)
                    {
                        if (!string.Equals(keyAction.Group, g.Header))
                            continue;
                        listGroup = g;
                        break;
                    }

                    if (listGroup == null)
                        Groups.Add(listGroup = new ListViewGroup(keyAction.Group));

                    item.Group = listGroup;
                }
                Items.Add(item);
            }
            SelectFirst();
        }

        private void HandleShortcutAssignClick(object sender, EventArgs e)
        {
            AddShortcut();
            shortcutKeyNames.Enabled = true;
            shortcutKeyNames.Visible = true;
        }

        private void AddShortcut()
        {
            if (shortcutList.SelectedItems.Count == 0)
                return;

            ListViewItem item = shortcutList.SelectedItems[0];

            if (item.SubItems.Count == 1)
                item.SubItems.Add(shortcut.Text);
            else
                item.SubItems[1].Text = shortcut.Text;


            HotKeyData hotKeyData = ((HotKeyData)item.Tag);

            OnHotKeyRegister(new HotKeyRegistrationEventArgs(hotKeyData.Id, item.Text, shortcut.KeyData, hotKeyData.Action, hotKeyData.KeyData, hotKeyData.Global));

            hotKeyData.KeyData = shortcut.KeyData;
            shortcutKeyNames.Text = shortcut.Text;
        }

        private void HandleShortcutListSelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = shortcutList.SelectedItems;
            if (items.Count == 0 || items[0]?.Tag == null)
                return;

            HotKeyData hotKeyData = ((HotKeyData)items[0].Tag);

            shortcut.Mode = hotKeyData.Global ? ShortcutMode.Global : ShortcutMode.Local;

            shortcutKeyNames.Text = null;
            shortcutKeyNames.Visible = true;
            shortcut.KeyData = hotKeyData.KeyData;
            shortcutKeyNames.Text = shortcut.Text;
        }

        private void HandleShortcutPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            AddShortcut();
        }

        private void HandleShortcutEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("Shortcut Enter");

            shortcut.Clear();
            shortcutKeyNames.Visible = false;
        }

        private void HandleShortcutKeyNamesEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("ShortcutKeyNames Enter");
            shortcut.Focus();
        }

        private void OnHotKeyRegister(HotKeyRegistrationEventArgs e)
        {
            EventHandler<HotKeyRegistrationEventArgs> handler = HotKeyRegister;
            handler?.Invoke(this, e);
        }
    }
}