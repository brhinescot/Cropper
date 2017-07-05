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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Fusion8.Cropper.Core;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
	#region ResizeRegion enum

	internal enum ResizeRegion
	{
		None,
		N,
		NE,
		E,
		SE,
		S,
		SW,
		W,
		NW
	}

	#endregion

	/// <summary>
	/// Represents a form for marking off the cropped area of the desktop.
	/// </summary>
	public class MainCropForm : CropForm
	{
		#region Constants

		private const int ResizeBorderWidth = 15;
		private const int TransparentMargin = 60;
		private const int TabHeight = 15;
		private const int TabTopWidth = 45;
		private const int TabBottomWidth = 60;

		// Form measurments and sizes
		private const int MinimumDialogWidth = 230;
		private const int MinimumDialogHeight = 180;
		private const int DefaultSizingInterval = 1;
		private const int AlternateSizingInterval = 10;
		private const int MinimumThumbnailSize = 20;
		private const int MinimumSizeForCrosshairDraw = 30;
		private const int CrosshairLengthFromCenter = 10;
		private const int FormatDescriptionOffset = 5;
		private const int MinimumPadForFormatDescriptionDraw = 5;
		private const int DefaultMaxThumbnailSize = 80;
		private const int DefaultVisibleHeightWidth = 180;
		private const int DefaultPositionLeft = 100;
		private const int DefaultPositionTop = 100;
		private const double DefaultLayerOpacity = 0.4;

		#endregion

		#region Member Variables

		private bool showAbout;
		private bool showHelp;
		private bool isThumbnailed;
		private bool isDisposed;
		private bool highlight;
		private int colorIndex = 0;

		private double maxThumbSize = DefaultMaxThumbnailSize;
		// String displayed on form describing the current output format. 
		private string outputDescription;

		private Point middle = new Point();
		private Point offset;
		private Point mouseDownPoint;

		// Point locations for drawing the tabs.
		private readonly Point[] points = new Point[]
			{
				new Point(TransparentMargin - TabHeight,
				          TransparentMargin - TabHeight),
				new Point(TransparentMargin + TabTopWidth,
				          TransparentMargin - TabHeight),
				new Point(TransparentMargin + TabBottomWidth,
				          TransparentMargin),
				new Point(TransparentMargin,
				          TransparentMargin),
				new Point(TransparentMargin,
				          TransparentMargin + TabBottomWidth),
				new Point(TransparentMargin - TabHeight,
				          TransparentMargin + TabTopWidth)
			};

		private Rectangle mouseDownRect;
		private Rectangle dialogCloseRectangle;
		private Rectangle thumbnailRectangle;
		private Rectangle visibleFormArea;
		private Size userFormSize;

		private Size thumbnailSize = new Size(DefaultMaxThumbnailSize,
		                                      DefaultMaxThumbnailSize);

		private readonly Font feedbackFont = new Font("Verdana", 8f);

		// Brushes
		// TODO: [Performance] Use one brush and set colors as needed.
		// Brush for the tab background.
		private readonly SolidBrush tabBrush = new SolidBrush(Color.SteelBlue);
		private readonly SolidBrush tabTextBrush = new SolidBrush(Color.Black);
		// Brush for the visible form background.
		private readonly SolidBrush areaBrush = new SolidBrush(Color.White);
		// Brush for the visible form background.
		private readonly Pen outlinePen = new Pen(Color.Black);
		// Brush for the drawn text and lines.
		private readonly SolidBrush formTextBrush = new SolidBrush(Color.Black);

		private readonly ArrayList colorTables = new ArrayList();
		private CropFormColorTable currentColorTable;
		private readonly ContextMenu menu = new ContextMenu();
        private MenuItem outputMenuItem;
		private MenuItem opacityMenuItem;
		private MenuItem showHideMenu;
	    private MenuItem toggleThumbnailMenu;
        private NotifyIcon notifyIcon;

		private ResizeRegion resizeRegion = ResizeRegion.None;
		private ResizeRegion thumbResizeRegion;
		private readonly ImageCapture imageCapture;

	    #endregion

		#region Property Accessors

		/// <summary>
		/// Gets the visible client rectangle.
		/// </summary>
		/// <value></value>
		public Rectangle VisibleClientRectangle
		{
			get
			{
				if (isDisposed)
					throw new ObjectDisposedException(ToString());

				Rectangle visibleClient = new Rectangle(VisibleLeft,
				                                        VisibleTop,
				                                        VisibleWidth,
				                                        VisibleHeight);
				return visibleClient;
			}
		}

		#endregion

		#region Private Property Accessors

		private int VisibleWidth
		{
			get { return Width - (TransparentMargin*2); }
			set { Width = value + (TransparentMargin*2); }
		}

		private int VisibleHeight
		{
			get { return Height - (TransparentMargin*2); }
			set { Height = value + (TransparentMargin*2); }
		}

		private int VisibleLeft
		{
			get { return Left + (TransparentMargin); }
			set { Left = value - (TransparentMargin); }
		}

		private int VisibleTop
		{
			get { return Top + (TransparentMargin); }
			set { Top = value - (TransparentMargin); }
		}

		private Size VisibleClientSize
		{
		    get
		    {
                return new Size(VisibleWidth, VisibleHeight);
		    }
		    set
			{
			    VisibleWidth = value.Width;
			    VisibleHeight = value.Height;
			}
		}

		#endregion

		#region .ctor

		public MainCropForm()
		{
		    Configuration.Current.ActiveCropWindow = this;
			imageCapture = new ImageCapture();
		    RegisterHotKeys();
            ApplyConfiguration();
			colorTables.Add(new CropFormBlueColorTable());
			colorTables.Add(new CropFormDarkColorTable());
			colorTables.Add(new CropFormLightColorTable());
			currentColorTable = (CropFormColorTable) colorTables[0];
			SetColors();
			SetUpForm();
			SetUpMenu();
			if (LimitMaxWorkingSet()) Process.GetCurrentProcess().MaxWorkingSet = (IntPtr) 5000000;
            SaveConfiguration();
		}

        /// <summary>
        /// Determines if the MaxWorkingSet should be limited.
        /// </summary>
        /// <returns>true if MaxWorkingSet should be limited; otherwise, false</returns>
        /// <remarks>This is only used to prevent an exception in Windows 2000 when the user is not part of the BUILTIN\Administrators group. This can be removed when Windows 2000 is no longer supported (July 13, 2010)</remarks>
        private static bool LimitMaxWorkingSet()
        {
            var windows2000 = Environment.OSVersion.Version.Major == 5 &&
                              Environment.OSVersion.Version.Minor == 0 &&
                              Environment.OSVersion.Version.Build == 2195;
            if (windows2000)
            {
                var administratorsGroupSid = "S-1-5-32-544";
                foreach (var group in System.Security.Principal.WindowsIdentity.GetCurrent().Groups)
                {
                    if (group.Value == administratorsGroupSid)
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }

        #endregion

	    #region Hot Keys

	    private void RegisterHotKeys()
	    {
	        const string prefix = "com.colossusinteractive.cropper.hotkey";

	        HotKeys.RegisterGlobal(prefix + ".showhide", Keys.F8 | Keys.Control, this, "Show/Hide Cropper", () => CycleFormVisibility(true), groupName: "Global");

	        HotKeys.RegisterLocal(prefix + ".thumbnail", Keys.T, "Toggle Thumbnail", () => ToggleThumbnail(toggleThumbnailMenu), groupName: "Thumbnail");
	        HotKeys.RegisterLocal(prefix + ".increasethumb", Keys.OemOpenBrackets | Keys.Alt, "Increase Thumbnail Size", () => ResizeThumbnail(DefaultSizingInterval), groupName: "Thumbnail");
	        HotKeys.RegisterLocal(prefix + ".decreasethumb", Keys.OemCloseBrackets | Keys.Alt, "Decrease Thumbnail Size", () => ResizeThumbnail(-DefaultSizingInterval), groupName: "Thumbnail");
	        HotKeys.RegisterLocal(prefix + ".increasethumbalt", Keys.OemOpenBrackets | Keys.Alt | Keys.Control, "Increase Thumbnail Size Big", () => ResizeThumbnail(AlternateSizingInterval), groupName: "Thumbnail");
	        HotKeys.RegisterLocal(prefix + ".decreasethumbalt", Keys.OemCloseBrackets | Keys.Alt | Keys.Control, "Decrease Thumbnail Size Big", () => ResizeThumbnail(-AlternateSizingInterval), groupName: "Thumbnail");

	        HotKeys.RegisterLocal(prefix + ".centerincrease", Keys.OemOpenBrackets, "Center Size Increase", () => CenterSize(DefaultSizingInterval), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".centerdecrease", Keys.OemCloseBrackets, "Center Size Decrease", () => CenterSize(-DefaultSizingInterval), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".centerincreasealt", Keys.OemOpenBrackets | Keys.Control, "Center Size Increase Big", () => CenterSize(AlternateSizingInterval), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".centerdecreasealt", Keys.OemCloseBrackets | Keys.Control, "Center Size Decrease Big", () => CenterSize(-AlternateSizingInterval), groupName: "Size");

	        HotKeys.RegisterLocal(prefix + ".increasewidth", Keys.Right | Keys.Alt, "Increase Width", () => Width = Width + DefaultSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".decreasewidth", Keys.Left | Keys.Alt, "Decrease Width", () => Width = Width - DefaultSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".increasewidthalt", Keys.Right | Keys.Alt | Keys.Control, "Increase Width Big", () => Width = Width + AlternateSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".decreasewidthalt", Keys.Left | Keys.Alt | Keys.Control, "Decrease Width Big", () => Width = Width - AlternateSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".increaseheight", Keys.Up | Keys.Alt, "Increase Height", () => Height = Height - DefaultSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".decreaseheight", Keys.Down | Keys.Alt, "Decrease Height", () => Height = Height + DefaultSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".increaseheightalt", Keys.Up | Keys.Alt | Keys.Control, "Increase Height Big", () => Height = Height - AlternateSizingInterval, groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".decreaseheightalt", Keys.Down | Keys.Alt | Keys.Control, "Decrease Height Big", () => Height = Height + AlternateSizingInterval, groupName: "Size");

	        HotKeys.RegisterLocal(prefix + ".moveleft", Keys.Left, "Move Left", () => Left = Left - DefaultSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".moveright", Keys.Right, "Move Right", () => Left = Left + DefaultSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".moveleftalt", Keys.Left | Keys.Control, "Move Left Big", () => Left = Left - AlternateSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".moverightalt", Keys.Right | Keys.Control, "Move Right Big", () => Left = Left + AlternateSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".moveup", Keys.Up, "Move Up", () => Top = Top - DefaultSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".movedown", Keys.Down, "Move Down", () => Top = Top + DefaultSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".moveupalt", Keys.Up | Keys.Control, "Move Up Big", () => Top = Top - AlternateSizingInterval, groupName: "Position");
	        HotKeys.RegisterLocal(prefix + ".movedownalt", Keys.Down | Keys.Control, "Move Down Big", () => Top = Top + AlternateSizingInterval, groupName: "Position");

	        HotKeys.RegisterLocal(prefix + ".sizedefault", Keys.NumPad0 | Keys.Control, "Default Size", () => ResetForm(true), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size1", Keys.NumPad1 | Keys.Control, "Saved Size 1", () => ApplyCropSize(0), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size2", Keys.NumPad2 | Keys.Control, "Saved Size 2", () => ApplyCropSize(1), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size3", Keys.NumPad3 | Keys.Control, "Saved Size 3", () => ApplyCropSize(2), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size4", Keys.NumPad4 | Keys.Control, "Saved Size 4", () => ApplyCropSize(3), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size5", Keys.NumPad5 | Keys.Control, "Saved Size 5", () => ApplyCropSize(4), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size6", Keys.NumPad6 | Keys.Control, "Saved Size 6", () => ApplyCropSize(5), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size7", Keys.NumPad7 | Keys.Control, "Saved Size 7", () => ApplyCropSize(6), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size8", Keys.NumPad8 | Keys.Control, "Saved Size 8", () => ApplyCropSize(7), groupName: "Size");
	        HotKeys.RegisterLocal(prefix + ".size9", Keys.NumPad9 | Keys.Control, "Saved Size 9", () => ApplyCropSize(8), groupName: "Size");

	        HotKeys.RegisterLocal(prefix + ".browse", Keys.B | Keys.Control, "Browse Captures", BrowseCaptures, groupName: "General");

	        HotKeys.RegisterGlobal(prefix + ".printscreen", Keys.PrintScreen, this, "Capture Desktop", () => TakeScreenShot(ScreenShotBounds.FullScreen), hide: true);
	        HotKeys.RegisterGlobal(prefix + ".altprintscreen", Keys.PrintScreen | Keys.Alt, this, "Capture Active Window", () => TakeScreenShot(ScreenShotBounds.ActiveForm), hide: true);
	        HotKeys.RegisterGlobal(prefix + ".ctrlaltprintscreen", Keys.PrintScreen | Keys.Alt | Keys.Control, this, "Capture at Point", () => TakeScreenShot(ScreenShotBounds.Window), hide: true);

	        HotKeys.RegisterLocal(prefix + ".nextcolor", Keys.Tab, "Next Color", CycleColors, hide: true);
	        HotKeys.RegisterLocal(prefix + ".nextsize", Keys.Tab | Keys.Shift, "Next Size", CycleSizes, hide: true);

	        HotKeys.RegisterLocal(prefix + ".hide", Keys.Escape, "Hide Cropper", () => CycleFormVisibility(true), hide: true, groupName: "General");
	        HotKeys.RegisterLocal(prefix + ".screenshot", Keys.Enter, "Take Screenshot", () => TakeScreenShot(ScreenShotBounds.Rectangle), hide: true, groupName: "General");
	    }

	    /// <summary>
	    /// Raises the <see cref="CropForm.HotKeyPressed"/> event.
	    /// </summary>
	    /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
	    protected override void OnHotKeyPressed(KeyEventArgs e)
	    {
	        if (isDisposed)
	            throw new ObjectDisposedException((this).ToString());

	        base.OnHotKeyPressed(e);

	        if (!e.Handled)
	            HotKeys.Process(e.KeyData);
	    }

	    #endregion

        #region Menu Handling

        /// <summary>
        /// Setup the main context menu
        /// </summary>
        private void SetUpMenu()
		{
			AddTopLevelMenuItems();
			if (Configuration.Current.ShowOpacityMenu)
				AddOpacitySubMenu();
			AddOutputSubMenus();
		}

	    private void AddTopLevelMenuItems()
		{
			outputMenuItem = AddTopLevelMenuItem(SR.MenuOutput, null);
		    toggleThumbnailMenu = AddTopLevelMenuItem(SR.MenuThumbnail, HandleMenuThumbnailClick);
		    toggleThumbnailMenu.Checked = isThumbnailed;
            AddTopLevelMenuItem(SR.MenuOptions, HandleMenuOptionsClick);
			AddTopLevelMenuItem(SR.MenuBrowse, HandleMenuBrowseClick);
			AddTopLevelMenuItem(SR.MenuSeperator, null);
			AddTopLevelMenuItem(SR.MenuOnTop, HandleMenuOnTopClick).Checked = TopMost;
            AddTopLevelMenuItem(SR.MenuInvert, HandleMenuInvertClick);
		    
            MenuItem predefinedSizes = AddTopLevelMenuItem(SR.MenuSize, null);
		    if(Configuration.Current.PredefinedSizes.Length == 0)
		    {
		        MenuItem nextSize = AddSubMenuItem(predefinedSizes, "None Defined", null);
		        nextSize.Enabled = false;
		    }
		    foreach (CropSize size in Configuration.Current.PredefinedSizes)
		    {
                MenuItem nextSize = AddSubMenuItem(predefinedSizes, size.ToString(), HandleMenuSizeClick);
		        nextSize.Tag = size;
		    }
            AddSubMenuItem(predefinedSizes, SR.MenuSeperator, null);
            AddSubMenuItem(predefinedSizes, "Add Current", HandleMenuSizeCurrentClick);
		    
			if (Configuration.Current.ShowOpacityMenu)
				opacityMenuItem = AddTopLevelMenuItem(SR.MenuOpacity, null);
		    
			AddTopLevelMenuItem(SR.MenuSeperator, null);
			showHideMenu = AddTopLevelMenuItem(SR.MenuHide, HandleMenuShowHideClick);
			AddTopLevelMenuItem(SR.MenuReset, HandleMenuResetClick);
			AddTopLevelMenuItem(SR.MenuSeperator, null);
            MenuItem helpMenuItem = AddTopLevelMenuItem(SR.MenuHelp, null);
            AddSubMenuItem(helpMenuItem, SR.MenuHelpHowTo, HandleMenuHelpClick);
            AddSubMenuItem(helpMenuItem, SR.MenuAbout, HandleMenuAboutClick);
            AddSubMenuItem(helpMenuItem, SR.MenuSeperator, null);
            AddSubMenuItem(helpMenuItem, SR.MenuHelpWeb, HandleMenuHelpWebClick);
			AddTopLevelMenuItem(SR.MenuSeperator, null);
			AddTopLevelMenuItem(SR.MenuExit, HandleMenuExitClick);
		}

	    private void AddOpacitySubMenu()
	    {
	        for (int i = 10; i <= 90; i += 10)
	        {
	            MenuItem subMenu;
	            subMenu = new MenuItem(i + "%");
	            subMenu.RadioCheck = true;
	            subMenu.Click += HandleMenuOpacityClick;
	            opacityMenuItem.MenuItems.Add(subMenu);
	            if (i == Convert.ToInt32(Configuration.Current.UserOpacity*100))
	                subMenu.Checked = true;
	        }
	    }

	    private MenuItem AddTopLevelMenuItem(string text, EventHandler handler)
		{
			MenuItem mi = new MenuItem(text);
			if (handler != null)
				mi.Click += handler;
			menu.MenuItems.Add(mi);

			return mi;
		}

        private static MenuItem AddSubMenuItem(Menu parent, string text, EventHandler handler)
        {
            MenuItem mi = new MenuItem(text);
            if (handler != null)
                mi.Click += handler;
            parent.MenuItems.Add(mi);

            return mi;
        }

		private void RefreshMenuItems()
		{
			menu.MenuItems.Clear();
			SetUpMenu();
		}

		private void AddOutputSubMenus()
		{
			foreach (IPersistableImageFormat imageOutputFormat in ImageCapture.ImageOutputs)
			{
				MenuItem menuItem = imageOutputFormat.Menu;
				imageOutputFormat.ImageFormatClick += HandleImageFormatClick;
				if (menuItem != null)
				{
					outputMenuItem.MenuItems.Add(menuItem);
					if (imageCapture.ImageFormat == null || menuItem.Text != imageCapture.ImageFormat.Description)
						ClearImageFormatChecks(menuItem);
					else if (!menuItem.IsParent)
						menuItem.Checked = true;
				}
			}
		}

		private static void ClearImageFormatChecks(Menu menuItem)
		{
			foreach (MenuItem item in menuItem.MenuItems)
			{
				if (item.IsParent) ClearImageFormatChecks(item);
				item.Checked = false;
			}
		}

	    private void ResetForm(bool sizeOnly = false)
	    {
	        VisibleWidth = DefaultVisibleHeightWidth;
	        VisibleHeight = DefaultVisibleHeightWidth;
	        if (sizeOnly)
	            return;

	        VisibleLeft = DefaultPositionLeft;
	        VisibleTop = DefaultPositionTop;
	        Configuration.Current.UserOpacity = DefaultLayerOpacity;
	        maxThumbSize = DefaultMaxThumbnailSize;
	    }

        private void HandleMenuOnTopClick(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem) sender;
			TopMost = mi.Checked = !mi.Checked;
		}

		private void HandleMenuShowHideClick(object sender, EventArgs e)
		{
			CycleFormVisibility(true);
		}

		private void CycleFormVisibility(bool allowHide)
		{
			if (Visible && allowHide)
			{
				DialogCloseIfNeeded();
				showHideMenu.Text = SR.MenuShow;
				Hide();
				if (LimitMaxWorkingSet()) Process.GetCurrentProcess().MaxWorkingSet = (IntPtr) 5000000;
				GC.Collect(2);
			}
			else if (!Visible)
			{
				showHideMenu.Text = SR.MenuHide;
				Show();
				Activate();
			}
			else
			{
				Activate();
			}
		}

		private void HandleMenuResetClick(object sender, EventArgs e)
		{
			ResetForm();
		}

		private void HandleMenuThumbnailClick(object sender, EventArgs e)
		{
		    ToggleThumbnail((MenuItem)sender);
        }

		private void HandleMenuInvertClick(object sender, EventArgs e)
		{
			CycleColors();
		}

        private void HandleMenuSizeClick(object sender, EventArgs e)
		{
            MenuItem item = sender as MenuItem;
            if(item == null)
                return;

            if(!(item.Tag is CropSize))
                return;

            CropSize size = (CropSize) item.Tag;
            VisibleClientSize = new Size(size.Width, size.Height);
		}

        private void HandleMenuSizeCurrentClick(object sender, EventArgs e)
        {
            CropSize size = new CropSize(VisibleClientSize.Width, VisibleClientSize.Height);
            List<CropSize> list = new List<CropSize>(Configuration.Current.PredefinedSizes);
            if (list.Contains(size))
                return;

            list.Add(size);
            CropSize[] cropSizes = list.ToArray();

            //Array.Sort(cropSizes);

            Configuration.Current.PredefinedSizes = cropSizes;
            RefreshMenuItems();
        }

	    private void HandleMenuOptionsClick(object sender, EventArgs e)
		{
			ShowOptionsDialog();
		}

		private void ShowOptionsDialog()
		{
		    Options options = new Options { Visible = false };
		    if (options.ShowDialog(this) != DialogResult.OK)
		        return;

		    SetColors();
		    RefreshMenuItems();
		    SaveConfiguration();
        }

		private void HandleMenuBrowseClick(object sender, EventArgs e)
		{
		    BrowseCaptures();
        }


	    private void BrowseCaptures()
	    {
	        if (!Directory.Exists(Configuration.Current.OutputPath))
	            Directory.CreateDirectory(Configuration.Current.OutputPath);
	        if (string.IsNullOrEmpty(imageCapture.LastImageCaptured) || !File.Exists(imageCapture.LastImageCaptured))
	            Process.Start(Configuration.Current.OutputPath);
	        else
	        {
	            // Browse to folder and select last image
	            // Thanks to Jon Galloway
	            ProcessStartInfo processStartInfo = new ProcessStartInfo();
	            processStartInfo.FileName = "explorer";
	            processStartInfo.UseShellExecute = true;
	            processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
	            processStartInfo.Arguments = "/e,/select,\"" + imageCapture.LastImageCaptured + "\"";
	            Process.Start(processStartInfo);
	        }
	    }

        private void HandleMenuHelpClick(object sender, EventArgs e)
		{
			DialogShow(b => showHelp = b);
		}

		private void HandleMenuAboutClick(object sender, EventArgs e)
		{
			DialogShow(b => showAbout = b);
		}

        private static void HandleMenuHelpWebClick(object sender, EventArgs e)
        {
            Process.Start(SR.HomepageLinkUrl);
        }

		private void HandleMenuExitClick(object sender, EventArgs e)
		{
			Close();
		}

		private void EnsureMinimumDialogWidth()
		{
			userFormSize = VisibleClientSize;
			if (VisibleWidth < MinimumDialogWidth | VisibleHeight < MinimumDialogHeight)
				VisibleClientSize = new Size(MinimumDialogWidth, MinimumDialogHeight);
		}

		private void HandleMenuOpacityClick(object sender, EventArgs e)
		{
			MenuItem menuItem = (MenuItem) sender;
			foreach (MenuItem childItems in menuItem.Parent.MenuItems)
				childItems.Checked = false;
			menuItem.Checked = true;

			Configuration.Current.UserOpacity = double.Parse(menuItem.Text.Replace("%", ""), CultureInfo.InvariantCulture)/100;
			SetColors();
		}

		private void HandleImageFormatClick(object sender, ImageFormatEventArgs e)
		{
			ClearImageFormatChecks(outputMenuItem);
			e.ClickedMenuItem.Checked = true;
			imageCapture.ImageFormat = e.ImageOutputFormat;
			outputDescription = e.ImageOutputFormat.Description;
			notifyIcon.Text = "Cropper\nOutput: " + outputDescription;
			PaintLayeredWindow();
		}

		#endregion

		#region Event Overrides

		#region Mouse Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			HandleMouseDown(e);
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			CheckForDialogClosing();
			HandleMouseUp();
			base.OnMouseUp(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			if (e.Delta > 0)
				CenterSize(AlternateSizingInterval);
			else
				CenterSize(-AlternateSizingInterval);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.DoubleClick"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnDoubleClick(EventArgs e)
		{
			TakeScreenShot(ScreenShotBounds.Rectangle);
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			HandleMouseMove(e);
		}

		#endregion

		/// <summary>
		/// Raises the <see cref="Form.KeyDown"/> event.
		/// </summary>
		/// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
		    if (isDisposed)
		        throw new ObjectDisposedException((this).ToString());

		    base.OnKeyDown(e);
		    if (e.Handled)
		        return;

		    e.Handled = true;
		    e.SuppressKeyPress = true;
		    HotKeys.Process(e.KeyData);
        }

		/// <summary>
		/// Raises the <see cref="Form.Closing"/> event.
		/// </summary>
		/// <param name="e">A <see cref="CancelEventArgs"/> that contains the event data.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			if (isDisposed)
				throw new ObjectDisposedException((this).ToString());

			SaveConfiguration();
		    base.OnClosing(e);
		}

	    private void SaveConfiguration() 
        {
	        string description = string.Empty;
	        if (imageCapture.ImageFormat != null)
	            description = imageCapture.ImageFormat.Description;

	        Configuration.Current.ImageFormat = description;
	        Configuration.Current.MaxThumbnailSize = maxThumbSize;
	        Configuration.Current.IsThumbnailed = isThumbnailed;
	        Configuration.Current.Location = Location;
	        Configuration.Current.UserSize = VisibleClientSize;
	        Configuration.Current.ColorIndex = colorIndex;
	        Configuration.Current.AlwaysOnTop = TopMost;
	        Configuration.Current.Hidden = !Visible;

            try
            {
                Configuration.Save();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "There was a problem saving your current settings. This may be caused by a plug-in. No changes have been made to your configuration.",
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

	    protected override void OnResize(EventArgs e)
		{
			middle.X = (VisibleWidth/2) + TransparentMargin;
			middle.Y = (VisibleHeight/2) + TransparentMargin;

			if (VisibleWidth <= 1)
				VisibleWidth = 1;
			if (VisibleHeight <= 1)
				VisibleHeight = 1;

			visibleFormArea = new Rectangle(TransparentMargin,
			                                TransparentMargin,
			                                VisibleWidth - 1,
			                                VisibleHeight - 1);

			if (showAbout || showHelp)
			{
				showAbout = false;
				showHelp = false;
			}

			base.OnResize(e);
		}

		protected override void OnPaintLayer(PaintLayerEventArgs e)
		{
			PaintUI(e.Graphics);
			base.OnPaintLayer(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, Icon.Handle);
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, notifyIcon.Icon.Handle);
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, Text);
			base.OnLoad(e);
		}

		protected override void OnClosed(EventArgs e)
		{
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, IntPtr.Zero);
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, IntPtr.Zero);
			NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, null);
			base.OnClosed(e);
		}

		#endregion

		#region Form Manipulation

		private void HandleMouseUp()
		{
			resizeRegion = ResizeRegion.None;
			thumbResizeRegion = ResizeRegion.None;
			Cursor = Cursors.Default;
		}

		private void HandleMouseDown(MouseEventArgs e)
		{
			offset = new Point(e.X, e.Y);
			mouseDownRect = ClientRectangle;
			mouseDownPoint = MousePosition;

			if (IsInResizeArea())
				resizeRegion = GetResizeRegion();
			else if (IsInThumbnailResizeArea())
				thumbResizeRegion = ResizeRegion.SE;
		}

//		private void ShowMoveCursor(MouseEventArgs e)
//		{
//			if (resizeRegion == ResizeRegion.None &&
//				thumbResizeRegion == ResizeRegion.None &&
//				e.Button == MouseButtons.Left)
//				Cursor = Cursors.SizeAll;
//		}

		private void HandleMouseMove(MouseEventArgs e)
		{
			bool mouseIsInResizeArea = resizeRegion != ResizeRegion.None;
			bool mouseIsInThumbResizeArea = thumbResizeRegion != ResizeRegion.None;

			if (mouseIsInResizeArea)
			{
				HandleResize();
			}
			else if (mouseIsInThumbResizeArea)
			{
				HandleThumbResize();
			}
			else
			{
				bool mouseOnFormShouldMove = e.Button == MouseButtons.Left;
				bool mouseInResizeAreaCanResize = IsInResizeArea() && e.Button != MouseButtons.Left;
				bool mouseInThumbResizeAreaCanResize = IsInThumbnailResizeArea() && e.Button != MouseButtons.Left;
				bool mouseNotInResizeArea = resizeRegion == ResizeRegion.None;
				bool mouseNotInThumbResizeArea = thumbResizeRegion == ResizeRegion.None;

				if (mouseOnFormShouldMove)
					Location = CalculateNewFormLocation();

				if (mouseInResizeAreaCanResize)
					SetResizeCursor(GetResizeRegion());
				else if (mouseInThumbResizeAreaCanResize)
					SetResizeCursor(ResizeRegion.SE);
				else if (mouseNotInResizeArea && mouseNotInThumbResizeArea && !mouseOnFormShouldMove)
					Cursor = Cursors.Default;
			}
		}

		private void ResizeThumbnail(int interval)
		{
			maxThumbSize = maxThumbSize + interval;
			if (maxThumbSize < MinimumThumbnailSize)
				maxThumbSize = MinimumThumbnailSize;
			PaintLayeredWindow();
		}

		private ResizeRegion GetResizeRegion()
		{
			Point clientCursorPos = PointToClient(MousePosition);
			if (
				(clientCursorPos.X >= (Width - (TransparentMargin + ResizeBorderWidth))) &
				(clientCursorPos.Y >= (Height - (TransparentMargin + ResizeBorderWidth))))
				return ResizeRegion.SE;
			else if (clientCursorPos.X >= (Width - (TransparentMargin + ResizeBorderWidth)))
				return ResizeRegion.E;
			else if (clientCursorPos.Y >= (Height - (TransparentMargin + ResizeBorderWidth)))
				return ResizeRegion.S;
			else
				return ResizeRegion.None;
		}

		private void HandleResize()
		{
			int diffX = MousePosition.X - mouseDownPoint.X;
			int diffY = MousePosition.Y - mouseDownPoint.Y;

			FreezePainting = true;
			switch (resizeRegion)
			{
				case ResizeRegion.E:
					Width = mouseDownRect.Width + diffX;
					break;
				case ResizeRegion.S:
					Height = mouseDownRect.Height + diffY;
					break;
				case ResizeRegion.SE:
					Width = mouseDownRect.Width + diffX;
					Height = mouseDownRect.Height + diffY;
					break;
			}
			FreezePainting = false;
		}

		private void HandleThumbResize()
		{
			int diffX = MousePosition.X - mouseDownPoint.X;
			int diffY = MousePosition.Y - mouseDownPoint.Y;

			mouseDownPoint.X = MousePosition.X;
			mouseDownPoint.Y = MousePosition.Y;

			ResizeThumbnail(diffX + diffY);
			PaintLayeredWindow();
		}

		private void CenterSize(int interval)
		{
			if (interval < -AlternateSizingInterval || interval > AlternateSizingInterval)
				throw new ArgumentOutOfRangeException("interval", interval, SR.ExceptionCenterSizeOutOfRange);

			if (VisibleWidth > interval & VisibleHeight > interval)
			{
				int interval2 = interval*2;
				Width = Width - interval2;
				Left = Left + interval;
				Height = Height - interval2;
				Top = Top + interval;
			}
		}

		private void CycleColors()
		{
			if (colorIndex >= colorTables.Count - 1)
				colorIndex = 0;
			else
				colorIndex ++;
			SetColors();
		}

        private void CycleSizes()
        {
            Size size = Configuration.Current.NextFormSize();
            if(size != Size.Empty)
                VisibleClientSize = size;
        }

		private void SetColors()
		{
			currentColorTable = (CropFormColorTable) colorTables[colorIndex];
			int areaAlpha = (int) (Configuration.Current.UserOpacity*255);

			if (Configuration.Current.UsePerPixelAlpha)
			{
				LayerOpacity = 1.0;
				currentColorTable.MainAlphaChannel = areaAlpha;
			}
			else
			{
				LayerOpacity = Configuration.Current.UserOpacity;
				currentColorTable.MainAlphaChannel = 255;
			}

			tabBrush.Color = currentColorTable.TabColor;
			areaBrush.Color = currentColorTable.FormColor;
			formTextBrush.Color = currentColorTable.FormTextColor;
			tabTextBrush.Color = currentColorTable.TabTextColor;
			outlinePen.Color = currentColorTable.LineColor;
			PaintLayeredWindow();
		}

		private bool IsInResizeArea()
		{
			Point clientCursorPos = PointToClient(MousePosition);

			Rectangle clientVisibleRect = ClientRectangle;
			clientVisibleRect.Inflate(-TransparentMargin, -TransparentMargin);

			Rectangle resizeInnerRect = clientVisibleRect;
			resizeInnerRect.Inflate(-ResizeBorderWidth, -ResizeBorderWidth);

			return (clientVisibleRect.Contains(clientCursorPos) && !resizeInnerRect.Contains(clientCursorPos));
		}

		private bool IsInThumbnailResizeArea()
		{
			Point clientCursorPos = PointToClient(MousePosition);

			Rectangle resizeInnerRect = new Rectangle(thumbnailRectangle.Right - 15,
			                                          thumbnailRectangle.Bottom - 15,
			                                          15, 15);

			return (resizeInnerRect.Contains(clientCursorPos));
		}
        
	    private void ToggleThumbnail(MenuItem mi)
	    {
	        isThumbnailed = mi.Checked = !mi.Checked;
	        PaintLayeredWindow();
	    }

        private void SetResizeCursor(ResizeRegion region)
		{
			switch (region)
			{
				case ResizeRegion.S:
					Cursor = Cursors.SizeNS;
					break;
				case ResizeRegion.E:
					Cursor = Cursors.SizeWE;
					break;
				case ResizeRegion.SE:
					Cursor = Cursors.SizeNWSE;
					break;
				default:
					Cursor = Cursors.Default;
					break;
			}
		}

		private bool IsMouseInRectangle(Rectangle rectangle)
		{
			Point clientCursorPos = PointToClient(MousePosition);
			return (rectangle.Contains(clientCursorPos));
		}

		private Point CalculateNewFormLocation()
		{
			return new Point(MousePosition.X - offset.X, MousePosition.Y - offset.Y);
		}

		#endregion

		#region Screenshot Methods

		private void TakeScreenShot(ScreenShotBounds bounds)
		{
            bool currentlyVisibile = Visible;
			highlight = true;
			PaintLayeredWindow();
			try
			{
                if (Configuration.Current.HideFormDuringCapture)
                    Hide();
				switch (bounds)
				{
					case ScreenShotBounds.ActiveForm:
						imageCapture.CaptureForegroundForm();
						break;
					case ScreenShotBounds.Window:
						imageCapture.CaptureWindowAtPoint(Cursor.Position);
						break;
					case ScreenShotBounds.FullScreen:
						imageCapture.CaptureDesktop();
						break;
					case ScreenShotBounds.Rectangle:
						if (isThumbnailed)
							imageCapture.Capture(VisibleClientRectangle, maxThumbSize);
						else
							imageCapture.Capture(VisibleClientRectangle);
						break;
				}
			}
			catch (InvalidOperationException ex)
			{
				ShowError(ex.Message, "Error Taking Screenshot");
			}
			finally
			{
                if (currentlyVisibile)
                    Show();

                if (Visible && Configuration.Current.HideFormAfterCapture)
                    Hide();

				highlight = false;
				PaintLayeredWindow();
			}
		}

        #endregion

        #region Helper Methods
        
	    private void ApplyCropSize(int index)
	    {
	        CropSize[] predefinedSizes = Configuration.Current.PredefinedSizes;
	        if (predefinedSizes.Length <= index)
	            return;

	        CropSize size = predefinedSizes[index];
	        VisibleClientSize = new Size(size.Width, size.Height);
	    }

        private void CheckForDialogClosing()
		{
			if (IsMouseInRectangle(dialogCloseRectangle))
			{
				DialogClose();
			}
		}

		private void DialogClose()
		{
			VisibleClientSize = userFormSize;
			dialogCloseRectangle.Inflate(-dialogCloseRectangle.Size.Width, -dialogCloseRectangle.Size.Height);
			showAbout = false;
			showHelp = false;
			PaintLayeredWindow();
		}

		private void DialogCloseIfNeeded()
		{
			if (showHelp || showAbout)
				DialogClose();
		}

		private void DialogShow(Action<bool> setTheFlag)
		{
			DialogCloseIfNeeded();
			EnsureMinimumDialogWidth();
			setTheFlag(true);
			PaintLayeredWindow();
			CycleFormVisibility(false);
		}

		private void ApplyConfiguration()
		{
			Settings settings = Configuration.Current;
			userFormSize = settings.UserSize;
			VisibleClientSize = userFormSize;
			colorIndex = settings.ColorIndex;
			isThumbnailed = settings.IsThumbnailed;
			maxThumbSize = settings.MaxThumbnailSize;
			Location = settings.Location;
			TopMost = settings.AlwaysOnTop;

		    if (settings.HotKeySettings != null)
		    {
		        foreach (HotKeySetting hk in settings.HotKeySettings)
		        {
		            if (string.IsNullOrEmpty(hk.Id))
		                continue;

		            HotKeys.UpdateHotKey(hk.Id, (Keys)hk.KeyCode);
		        }
		    }

            if (settings.UserOpacity < 0.1 || settings.UserOpacity > 0.9)
				settings.UserOpacity = 0.4;

		    LayerOpacity = !settings.UsePerPixelAlpha ? settings.UserOpacity : 1.0;

            if (ImageCapture.ImageOutputs[settings.ImageFormat] != null)
			{
				imageCapture.ImageFormat = ImageCapture.ImageOutputs[settings.ImageFormat];
				outputDescription = imageCapture.ImageFormat.Description;
			}
			else
			{
				outputDescription = SR.MessageNoOutputLoaded;
			}
		}

		private void SetUpForm()
		{
			ResourceManager resources = new ResourceManager(typeof (MainCropForm));

			notifyIcon = new NotifyIcon();
			notifyIcon.Icon = ((Icon) (resources.GetObject("NotifyIcon")));
			notifyIcon.Visible = true;
			notifyIcon.MouseUp += HandleNotifyIconMouseUp;
			notifyIcon.Text = "Cropper\nOutput: " + outputDescription;

			Text = "Cropper";
			Icon = ((Icon) (resources.GetObject("Icon")));

			ContextMenu = menu;
			notifyIcon.ContextMenu = menu;
			if (!Configuration.Current.Hidden)
				Show();
		}

		private static void ShowError(string text, string caption)
		{
			ShowMessage(text, caption, MessageBoxIcon.Error);
		}

		private static void ShowMessage(string text, string caption, MessageBoxIcon icon)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, icon);
		}

		#endregion

		#region Painting
		private void PaintUI(Graphics graphics)
		{
			if (currentColorTable != null)
			{
				PaintMainFormArea(graphics, visibleFormArea);
				PaintSizeTabs(graphics, points);
				if (showHelp)
					DrawHelp(graphics);
				else if (showAbout)
					DrawAbout(graphics);
				else
				{
					PaintThumbnailIndicator(graphics, VisibleWidth, VisibleHeight);
					PaintCrosshairs(graphics, VisibleWidth, VisibleHeight);
				}
				Point grabberCorner = new Point(Width - TransparentMargin, Height - TransparentMargin);
				PaintGrabber(graphics, grabberCorner);
				PaintOutputFormat(graphics, VisibleWidth, VisibleHeight);
				PaintWidthString(graphics, VisibleWidth);
				PaintHeightString(graphics, VisibleHeight);
			}
		}

		private void PaintGrabber(Graphics graphics, Point grabberStart)
		{
			int yOffset = grabberStart.Y - 4;
			int xOffset = grabberStart.X - 4;
			graphics.DrawLine(outlinePen, grabberStart.X - 5, yOffset, xOffset, grabberStart.Y - 5);
			graphics.DrawLine(outlinePen, grabberStart.X - 10, yOffset, xOffset, grabberStart.Y - 10);
			graphics.DrawLine(outlinePen, grabberStart.X - 15, yOffset, xOffset, grabberStart.Y - 15);
		}

		private void PaintSizeTabs(Graphics graphics, Point[] tabPoints)
		{
			graphics.FillPolygon(tabBrush, tabPoints);
		}

		private void PaintMainFormArea(Graphics graphics, Rectangle cropArea)
		{
			if (highlight)
				outlinePen.Color = currentColorTable.LineHighlightColor;
			else
				outlinePen.Color = currentColorTable.LineColor;
			graphics.FillRectangle(areaBrush, cropArea);
			graphics.DrawRectangle(outlinePen, cropArea);
		}

		private void PaintThumbnailIndicator(Graphics graphics, int paintWidth, int paintHeight)
		{
			if (isThumbnailed)
			{
				double thumbRatio;
				if (paintHeight > paintWidth)
					thumbRatio = paintHeight/maxThumbSize;
				else
					thumbRatio = paintWidth/maxThumbSize;
				thumbnailSize.Width = Convert.ToInt32(paintWidth/thumbRatio);
				thumbnailSize.Height = Convert.ToInt32(paintHeight/thumbRatio);

				if (paintWidth > (thumbnailSize.Width + 50) && paintHeight > (thumbnailSize.Height + 30))
				{
					string size = thumbnailSize.Width + "x" + thumbnailSize.Height;
					string max = maxThumbSize + " px max";
					SizeF dimensionSize = graphics.MeasureString(size, feedbackFont);
					SizeF maxSize = graphics.MeasureString(max, feedbackFont);

					graphics.DrawString(
						max,
						feedbackFont,
						formTextBrush,
						middle.X - (maxSize.Width/2),
						middle.Y - (thumbnailSize.Height/2) - maxSize.Height);

					graphics.DrawString(
						size,
						feedbackFont,
						formTextBrush,
						middle.X - (dimensionSize.Width/2),
						middle.Y + (thumbnailSize.Height/2));

					thumbnailRectangle = new Rectangle(
						middle.X - (thumbnailSize.Width/2),
						middle.Y - (thumbnailSize.Height/2),
						thumbnailSize.Width,
						thumbnailSize.Height);

					graphics.DrawRectangle(
						outlinePen, thumbnailRectangle);

					if (thumbnailRectangle.Height > 22)
					{
						Point grabberCorner = new Point(thumbnailRectangle.Right, thumbnailRectangle.Bottom);
						PaintGrabber(graphics, grabberCorner);
					}
				}
			}
		}

		private void PaintHeightString(Graphics graphics, int paintHeight)
		{
			graphics.RotateTransform(90);
			graphics.DrawString(
				paintHeight + " px",
				feedbackFont,
				tabTextBrush,
				TransparentMargin,
				-TransparentMargin);
		}

		private void PaintWidthString(Graphics graphics, int paintWidth)
		{
			graphics.DrawString(
				paintWidth + " px",
				feedbackFont,
				tabTextBrush,
				TransparentMargin,
				TransparentMargin - 15);
		}

		private void PaintOutputFormat(Graphics graphics, int paintWidth, int paintHeight)
		{
			SizeF formatSize = graphics.MeasureString(outputDescription, feedbackFont);
			if (formatSize.Width + MinimumPadForFormatDescriptionDraw < paintWidth &&
			    formatSize.Height + MinimumPadForFormatDescriptionDraw < paintHeight)
			{
				graphics.DrawString(
					outputDescription,
					feedbackFont,
					formTextBrush,
					TransparentMargin + FormatDescriptionOffset,
					TransparentMargin + FormatDescriptionOffset);
			}
		}

		private void PaintCrosshairs(Graphics graphics, int paintWidth, int paintHeight)
		{
			if (paintWidth > MinimumSizeForCrosshairDraw & paintHeight > MinimumSizeForCrosshairDraw)
			{
				graphics.DrawLine(
					outlinePen,
					middle.X,
					(middle.Y) + CrosshairLengthFromCenter,
					middle.X,
					(middle.Y) - CrosshairLengthFromCenter);

				graphics.DrawLine(
					outlinePen,
					(middle.X) + CrosshairLengthFromCenter,
					middle.Y,
					(middle.X) - CrosshairLengthFromCenter,
					middle.Y);
			}
		}

		private void DrawAbout(Graphics g)
		{
			DrawDialog(g, "About Cropper v" + Application.ProductVersion, SR.MessageAbout);
		}

		private void DrawHelp(Graphics g)
		{
			DrawDialog(g, "Help", SR.MessageHelp);
		}

		private void DrawDialog(Graphics g, string title, string text)
		{
			StringFormat format = new StringFormat(StringFormatFlags.NoClip);
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;

			Rectangle aboutRectangle = new Rectangle((Width/2) - 90, (Height/2) - 60, MinimumDialogHeight, 120);

			// Box
			//
			g.FillRectangle(Brushes.SteelBlue, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			//Contents
			//
			aboutRectangle.Inflate(-5, -5);
			aboutRectangle.Y = aboutRectangle.Y + 5;

			Font textFont = new Font("Arial", 8f);
			//Draw text
			//
			g.DrawString(text, textFont, Brushes.White, aboutRectangle, format);

			//Title
			//
			aboutRectangle.Inflate(5, -47);
			aboutRectangle.Y = (Height/2) - 60;
			g.FillRectangle(Brushes.Black, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			aboutRectangle.Inflate(-5, 0);
			g.DrawString(title, textFont, Brushes.White, aboutRectangle, format);

			//Close
			//
			aboutRectangle.Inflate(-78, 0);
			aboutRectangle.X = (Width/2) + 76;
			g.FillRectangle(Brushes.Red, aboutRectangle);
			g.DrawRectangle(Pens.Black, aboutRectangle);

			StringFormat closeFormat = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.DirectionVertical);
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;

			Font closeFont = new Font("Verdana", 10.5f, FontStyle.Bold);
			aboutRectangle.Inflate(3, -1);
			g.DrawString("X",
			             closeFont,
			             Brushes.White,
			             aboutRectangle,
			             closeFormat);

			dialogCloseRectangle = aboutRectangle;
			format.Dispose();
			closeFormat.Dispose();
			textFont.Dispose();
			closeFont.Dispose();
		}

		#endregion

		#region Other Event Handling

		/// <summary>
		/// Handles the MouseUp event of the NotifyIcon control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		private void HandleNotifyIconMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				CycleFormVisibility(false);
		}

		#endregion

		#region IDisposable Implementation

		protected override void Dispose(bool disposing)
		{
			isDisposed = true;
			if (disposing)
			{
				if (null != feedbackFont)
					feedbackFont.Dispose();
				if (null != menu)
					menu.Dispose();
				if (null != tabBrush)
					tabBrush.Dispose();
				if (null != areaBrush)
					areaBrush.Dispose();
				if (null != formTextBrush)
					formTextBrush.Dispose();
				if (null != notifyIcon)
					notifyIcon.Dispose();
				if (null != outlinePen)
					outlinePen.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion
	}
}