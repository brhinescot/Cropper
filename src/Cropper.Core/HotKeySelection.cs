#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

#region Using Directives

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    public partial class HotKeySelection : UserControl
    {
        public HotKeySelection()
        {
            InitializeComponent();
//            shortcutList.Items[0].Selected = true;
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

        private void HandleShortcutAssignClick(object sender, EventArgs e)
        {
            AddShortcut();
        }

        private void AddShortcut()
        {
            shortcutList.SelectedItems[0].SubItems[1].Text = shortcut.Text;
            shortcutList.SelectedItems[0].Tag = shortcut.KeyData;
            shortcut.Focus();
        }

        private void HandleShortcutListSelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = shortcutList.SelectedItems;
            if (items.Count == 0 || items[0] == null || items[0].Tag == null)
                return;

            shortcut.KeyData = (Keys) items[0].Tag;
        }

        private void HandleShortcutPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            AddShortcut();
        }
    }
}