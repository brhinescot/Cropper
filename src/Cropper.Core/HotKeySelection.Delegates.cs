using System.Drawing;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core
{
    public partial class HotKeySelection
    {
        // ReSharper disable UnusedMember.Global

        /// <summary>
        /// Gets or sets a value indicating whether items are displayed in groups.
        /// </summary>
        /// <returns>
        /// true to display items in groups; otherwise, false. The default value is true.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public bool ShowGroups
        {
            get { return shortcutList.ShowGroups; }
            set { shortcutList.ShowGroups = value; }
        }

        /// <summary>
        /// Gets the collection of <see cref="T:System.Windows.Forms.ListViewGroup"/> objects assigned to the control.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Windows.Forms.ListViewGroupCollection"/> that contains all the groups in the <see cref="T:System.Windows.Forms.ListView"/> control.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public ListViewGroupCollection Groups
        {
            get { return shortcutList.Groups; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether the selected item in the control remains highlighted when the control loses focus.
        ///</summary>
        ///
        ///<returns>
        ///true if the selected item does not appear highlighted when the control loses focus; false if the selected item still appears highlighted when the control loses focus. The default is true.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool HideSelection
        {
            get { return shortcutList.HideSelection; }
            set { shortcutList.HideSelection = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether the text of an item or subitem has the appearance of a 
        /// hyperlink when the mouse pointer passes over it.
        ///</summary>
        ///
        ///<returns>
        ///true if the item text has the appearance of a hyperlink when the mouse passes over it; otherwise, 
        /// false. The default is false.
        ///</returns>
        ///<filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool HotTracking
        {
            get { return shortcutList.HotTracking; }
            set { shortcutList.HotTracking = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether an item is automatically selected when the mouse pointer 
        /// remains over the item for a few seconds.
        ///</summary>
        ///
        ///<returns>
        ///true if an item is automatically selected when the mouse pointer hovers over it; otherwise, false. 
        /// The default is false.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool HoverSelection
        {
            get { return shortcutList.HoverSelection; }
            set { shortcutList.HoverSelection = value; }
        }

        ///<summary>
        ///Gets a collection containing all items in the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListView.ListViewItemCollection"></see> that contains all the 
        /// items in the <see cref="T:System.Windows.Forms.ListView"></see> control.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public ListView.ListViewItemCollection Items
        {
            get { return shortcutList.Items; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether multiple items can be selected.
        ///</summary>
        ///
        ///<returns>
        ///true if multiple items in the control can be selected at one time; otherwise, false. The default is true.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool MultiSelect
        {
            get { return shortcutList.MultiSelect; }
            set { shortcutList.MultiSelect = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether a scroll bar is added to the control when there is not enough room to display all items.
        ///</summary>
        ///
        ///<returns>
        ///true if scroll bars are added to the control when necessary to allow the user to see all the items; otherwise, false. The default is true.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool Scrollable
        {
            get { return shortcutList.Scrollable; }
            set { shortcutList.Scrollable = value; }
        }

        ///<summary>
        ///Gets the items that are selected in the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListView.SelectedListViewItemCollection"></see> that contains the items that are selected in the control. If no items are currently selected, an empty <see cref="T:System.Windows.Forms.ListView.SelectedListViewItemCollection"></see> is returned.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public ListView.SelectedListViewItemCollection SelectedItems
        {
            get { return shortcutList.SelectedItems; }
        }

        ///<summary>
        ///Gets the indexes of the selected items in the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListView.SelectedIndexCollection"></see> that contains the indexes of the selected items. If no items are currently selected, an empty <see cref="T:System.Windows.Forms.ListView.SelectedIndexCollection"></see> is returned.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public ListView.SelectedIndexCollection SelectedIndices
        {
            get { return shortcutList.SelectedIndices; }
        }

        ///<summary>
        ///Gets or sets the <see cref="T:System.Windows.Forms.ImageList"></see> to use when displaying items as small icons in the control.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Windows.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:System.Windows.Forms.ListView.View"></see> property is set to <see cref="F:System.Windows.Forms.View.SmallIcon"></see>. The default is null.
        ///</returns>
        ///<filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ImageList SmallImageList
        {
            get { return shortcutList.SmallImageList; }
            set { shortcutList.SmallImageList = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether ToolTips are shown for the <see cref="T:System.Windows.Forms.ListViewItem"></see> objects contained in the <see cref="T:System.Windows.Forms.ListView"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if <see cref="T:System.Windows.Forms.ListViewItem"></see> ToolTips should be shown; otherwise, false. The default is true.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool ShowItemToolTips
        {
            get { return shortcutList.ShowItemToolTips; }
            set { shortcutList.ShowItemToolTips = value; }
        }

        ///<summary>
        ///Gets or sets the first visible item in the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListViewItem"></see> that represents the first visible item in the control.
        ///</returns>
        ///
        ///<exception cref="T:System.InvalidOperationException">The <see cref="P:System.Windows.Forms.ListView.View"></see> property is set to <see cref="F:System.Windows.Forms.View.LargeIcon"></see>,  <see cref="F:System.Windows.Forms.View.SmallIcon"></see>, or <see cref="F:System.Windows.Forms.View.Tile"></see>.</exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem TopItem
        {
            get { return shortcutList.TopItem; }
            set { shortcutList.TopItem = value; }
        }

        ///<summary>
        ///Gets the collection of all column headers that appear in the control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListView.ColumnHeaderCollection"></see> that represents the column headers that appear when the <see cref="P:System.Windows.Forms.ListView.View"></see> property is set to <see cref="F:System.Windows.Forms.View.Details"></see>.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public ListView.ColumnHeaderCollection Columns
        {
            get { return shortcutList.Columns; }
        }

        ///<summary>
        ///Gets the item in the control that currently has focus.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListViewItem"></see> that represents the item that has focus, or null if no item has the focus in the <see cref="T:System.Windows.Forms.ListView"></see>.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FocusedItem
        {
            get { return shortcutList.FocusedItem; }
            set { shortcutList.FocusedItem = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether clicking an item selects all its subitems.
        ///</summary>
        ///
        ///<returns>
        ///true if clicking an item selects the item and all its subitems; false if clicking an item selects only the item itself. The default is false.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool FullRowSelect
        {
            get { return shortcutList.FullRowSelect; }
            set { shortcutList.FullRowSelect = value; }
        }

        ///<summary>
        ///Gets or sets a value indicating whether grid lines appear between the rows and columns containing the items and subitems in the control.
        ///</summary>
        ///
        ///<returns>
        ///true if grid lines are drawn around items and subitems; otherwise, false. The default is false.
        ///</returns>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public bool GridLines
        {
            get { return shortcutList.GridLines; }
            set { shortcutList.GridLines = value; }
        }

        ///<summary>
        ///Gets or sets the column header style.
        ///</summary>
        ///
        ///<returns>
        ///One of the <see cref="T:System.Windows.Forms.ColumnHeaderStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ColumnHeaderStyle.Clickable"></see>.
        ///</returns>
        ///
        ///<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value specified is not one of the <see cref="T:System.Windows.Forms.ColumnHeaderStyle"></see> values. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ColumnHeaderStyle HeaderStyle
        {
            get { return shortcutList.HeaderStyle; }
            set { shortcutList.HeaderStyle = value; }
        }

        ///<summary>
        ///Occurs when the user clicks a column header within the list view control.
        ///</summary>
        ///<filterpriority>1</filterpriority>
        public event ColumnClickEventHandler ColumnClick
        {
            add { shortcutList.ColumnClick += value; }
            remove { shortcutList.ColumnClick -= value; }
        }

        ///<summary>
        ///Ensures that the specified item is visible within the control, scrolling the contents of the control if necessary.
        ///</summary>
        ///
        ///<param name="index">The zero-based index of the item to scroll into view. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void EnsureVisible(int index)
        {
            shortcutList.EnsureVisible(index);
        }

        ///<summary>
        ///Finds the first <see cref="T:System.Windows.Forms.ListViewItem"></see> that begins with the specified text value.
        ///</summary>
        ///
        ///<returns>
        ///The first <see cref="T:System.Windows.Forms.ListViewItem"></see> that begins with the specified text value.
        ///</returns>
        ///
        ///<param name="text">The text to search for.</param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string text)
        {
            return shortcutList.FindItemWithText(text);
        }

        ///<summary>
        ///Finds the first <see cref="T:System.Windows.Forms.ListViewItem"></see> or <see cref="T:System.Windows.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.
        ///</summary>
        ///
        ///<returns>
        ///The first <see cref="T:System.Windows.Forms.ListViewItem"></see> that begins with the specified text value.
        ///</returns>
        ///
        ///<param name="includeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
        ///<param name="startIndex">The index of the item at which to start the search.</param>
        ///<param name="text">The text to search for.</param>
        ///<exception cref="T:System.ArgumentOutOfRangeException"><paramref name="startIndex"/> is less 
        /// 0 or more than the number items in the <see cref="T:System.Windows.Forms.ListView"></see>. 
        /// </exception><filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string text, bool includeSubItemsInSearch, int startIndex)
        {
            return shortcutList.FindItemWithText(text, includeSubItemsInSearch, startIndex);
        }

        ///<summary>
        ///Finds the first <see cref="T:System.Windows.Forms.ListViewItem"></see> or <see cref="T:System.Windows.Forms.ListViewItem.ListViewSubItem"></see>, if indicated, that begins with the specified text value. The search starts at the specified index.
        ///</summary>
        ///
        ///<returns>
        ///The first <see cref="T:System.Windows.Forms.ListViewItem"></see> that begins with the specified text value.
        ///</returns>
        ///
        ///<param name="isPrefixSearch">true to match the search text to the prefix of an item; otherwise, false.</param>
        ///<param name="includeSubItemsInSearch">true to include subitems in the search; otherwise, false. </param>
        ///<param name="startIndex">The index of the item at which to start the search.</param>
        ///<param name="text">The text to search for.</param>
        ///<exception cref="T:System.ArgumentOutOfRangeException"><paramref name="startIndex"/> is less 0 or more than the number of items in the <see cref="T:System.Windows.Forms.ListView"></see>. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem FindItemWithText(string text, bool includeSubItemsInSearch, int startIndex, bool isPrefixSearch)
        {
            return shortcutList.FindItemWithText(text, includeSubItemsInSearch, startIndex, isPrefixSearch);
        }

        ///<summary>
        ///Finds the next item from the given point, searching in the specified direction
        ///</summary>
        ///
        ///<returns>
        ///The <see cref="T:System.Windows.Forms.ListViewItem"></see> that is closest to the given point, searching in the specified direction.
        ///</returns>
        ///
        ///<param name="dir">One of the <see cref="T:System.Windows.Forms.SearchDirectionHint"></see> values.</param>
        ///<param name="point">The point at which to begin searching.</param>
        ///<exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.ListView.View"></see> is set to a value other than <see cref="F:System.Windows.Forms.View.SmallIcon"></see> or <see cref="F:System.Windows.Forms.View.LargeIcon"></see>. </exception>
        public ListViewItem FindNearestItem(SearchDirectionHint dir, Point point)
        {
            return shortcutList.FindNearestItem(dir, point);
        }

        ///<summary>
        ///Finds the next item from the given x- and y-coordinates, searching in the specified direction. 
        ///</summary>
        ///
        ///<returns>
        ///The <see cref="T:System.Windows.Forms.ListViewItem"></see> that is closest to the given coordinates, searching in the specified direction.
        ///</returns>
        ///
        ///<param name="y">The y-coordinate for the point at which to begin searching.</param>
        ///<param name="searchDirection">One of the <see cref="T:System.Windows.Forms.SearchDirectionHint"></see> values.</param>
        ///<param name="x">The x-coordinate for the point at which to begin searching.</param>
        ///<exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.ListView.View"></see> is set to a value other than <see cref="F:System.Windows.Forms.View.SmallIcon"></see> or <see cref="F:System.Windows.Forms.View.LargeIcon"></see>. </exception>
        public ListViewItem FindNearestItem(SearchDirectionHint searchDirection, int x, int y)
        {
            return shortcutList.FindNearestItem(searchDirection, x, y);
        }

        ///<summary>
        ///Retrieves the item at the specified location.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Windows.Forms.ListViewItem"></see> that represents the item at the specified position. If there is no item at the specified location, the method returns null.
        ///</returns>
        ///
        ///<param name="y">The y-coordinate of the location to search for an item (expressed in client coordinates). </param>
        ///<param name="x">The x-coordinate of the location to search for an item (expressed in client coordinates). </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public ListViewItem GetItemAt(int x, int y)
        {
            return shortcutList.GetItemAt(x, y);
        }

        ///<summary>
        ///Retrieves the bounding rectangle for a specific item within the list view control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding rectangle of the specified <see cref="T:System.Windows.Forms.ListViewItem"></see>.
        ///</returns>
        ///
        ///<param name="index">The zero-based index of the item within the <see cref="T:System.Windows.Forms.ListView.ListViewItemCollection"></see> whose bounding rectangle you want to return. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public Rectangle GetItemRect(int index)
        {
            return shortcutList.GetItemRect(index);
        }

        ///<summary>
        ///Retrieves the specified portion of the bounding rectangle for a specific item within the list view control.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Drawing.Rectangle"></see> that represents the bounding rectangle for the specified portion of the specified <see cref="T:System.Windows.Forms.ListViewItem"></see>.
        ///</returns>
        ///
        ///<param name="portion">One of the <see cref="T:System.Windows.Forms.ItemBoundsPortion"></see> values that represents a portion of the <see cref="T:System.Windows.Forms.ListViewItem"></see> for which to retrieve the bounding rectangle. </param>
        ///<param name="index">The zero-based index of the item within the <see cref="T:System.Windows.Forms.ListView.ListViewItemCollection"></see> whose bounding rectangle you want to return. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public Rectangle GetItemRect(int index, ItemBoundsPortion portion)
        {
            return shortcutList.GetItemRect(index, portion);
        }

        ///<summary>
        ///Sorts the items of the list view.
        ///</summary>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Sort()
        {
            shortcutList.Sort();
        }
    }
}