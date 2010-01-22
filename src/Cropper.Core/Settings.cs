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
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    /// Summary description for Settings.
    /// </summary>
    [XmlRoot(XmlRootName, Namespace = RootNamespace, IsNullable = false)]
    public class Settings
    {
        internal const string XmlRootName = "Configuration";
        internal const string RootNamespace = "http://www.fusion8design.com";

        internal static string DefaultOutputPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), OutputFolder);

        #region Member Variables

        private const string OutputFolder = "Cropper Captures";

        private string imageFormat = "Bmp";
        private double userOpacity = 0.40d;
        private double maxThumbnailSize = 80d;
        private Size userSize = new Size(300, 300);
        private Point location = new Point(100, 100);
        private int nonFormAreaColorArgb = Color.White.ToArgb();
        private bool colorNonFormArea = true;
        private bool alwaysOnTop;
        private bool hidden = true;
        private bool showOpacityMenu;
        private bool trapPrintScreen = true;
        private bool leavePrintScreenOnClipboard = true;
        private bool usePerPixelAlpha = true;
        private bool isThumbnailed;
        private int colorIndex;
        private bool hideFormDuringCapture;
        private bool hideFormAfterCapture;
        private string outputPath = DefaultOutputPath;
        private bool allowMultipleInstances = true;
        private bool includeMouseCursorInCapture;

        private string fileNameTemplate = FileNameTemplate.DefaultFullImageTemplate;
        private string fileNameThumbTemplate = FileNameTemplate.DefaultThumbImageTemplate;

        private object[] pluginSettings;
        private HotKeySetting[] hotKeySettings;
        private CircularQueue<CropSize> cropSizeQueue;

        private IWin32Window activeCropWindow;

        #endregion

        [XmlIgnore]
        public IWin32Window ActiveCropWindow
        {
            get { return activeCropWindow; }
            set { activeCropWindow = value; }
        }

        #region Property Accessors

        /// <summary>
        /// Allow multiple instances per user
        /// </summary>
        [XmlElement("AllowMultipleInstances", typeof (bool))]
        public bool AllowMultipleInstances
        {
            get { return allowMultipleInstances; }
            set { allowMultipleInstances = value; }
        }

        /// <summary>
        /// The users last used image format.
        /// </summary>
        [XmlElement("ImageFormat", typeof (String))]
        public string ImageFormat
        {
            get { return imageFormat; }
            set { imageFormat = value; }
        }

        /// <summary>
        /// The users last used image format.
        /// </summary>
        [XmlElement("OutputDirectory", typeof (String))]
        public string OutputPath
        {
            get { return outputPath; }
            set { outputPath = ResolveOutputDirectory(value); }
        }

        [XmlElement("ColorIndex", typeof (int))]
        public int ColorIndex
        {
            get { return colorIndex; }
            set { colorIndex = value; }
        }

        /// <summary>
        /// The users last used opacity level.
        /// </summary>
        [XmlElement("UserOpacity", typeof (Double))]
        public double UserOpacity
        {
            get { return userOpacity; }
            set { userOpacity = value; }
        }

        /// <summary>
        /// The users last used thumbnail size.
        /// </summary>
        [XmlElement("MaxThumbnailSize", typeof (Double))]
        public double MaxThumbnailSize
        {
            get { return maxThumbnailSize; }
            set { maxThumbnailSize = value; }
        }

        /// <summary>
        /// The users last chosen window size.
        /// </summary>
        /// <remarks>This property is being expanded to allow the user to save a list of common
        /// used sizes. </remarks>
        [XmlElement("UserSize")]
        public Size UserSize
        {
            get { return userSize; }
            set { userSize = value; }
        }

        /// <summary>
        /// The last location of the form.
        /// </summary>
        [XmlElement("Location")]
        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        /// <summary>
        /// The users last used image format.
        /// </summary>
        [XmlElement("FullImageTemplate", typeof (String))]
        public string FullImageTemplate
        {
            get { return fileNameTemplate; }
            set { fileNameTemplate = value; }
        }

        /// <summary>
        /// The users last used image format.
        /// </summary>
        [XmlElement("ThumbImageTemplate", typeof (String))]
        public string ThumbImageTemplate
        {
            get { return fileNameThumbTemplate; }
            set { fileNameThumbTemplate = value; }
        }

        /// <summary>
        /// The users last used image format.
        /// </summary>
        [XmlElement("NonFormAreaColorArgb", typeof (int))]
        public int NonFormAreaColorArgb
        {
            get { return nonFormAreaColorArgb; }
            set { nonFormAreaColorArgb = value; }
        }

        [XmlElement("ColorNonFormArea", typeof (bool))]
        public bool ColorNonFormArea
        {
            get { return colorNonFormArea; }
            set { colorNonFormArea = value; }
        }

        [XmlElement("AlwaysOnTop", typeof (bool))]
        public bool AlwaysOnTop
        {
            get { return alwaysOnTop; }
            set { alwaysOnTop = value; }
        }

        [XmlElement("Hidden", typeof (bool))]
        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        [XmlElement("ShowOpacityMenu", typeof (bool))]
        public bool ShowOpacityMenu
        {
            get { return showOpacityMenu; }
            set { showOpacityMenu = value; }
        }

        [XmlElement("UsePerPixelAlpha", typeof (bool))]
        public bool UsePerPixelAlpha
        {
            get { return usePerPixelAlpha; }
            set { usePerPixelAlpha = value; }
        }

        [XmlElement("IsThumbnailed", typeof (bool))]
        public bool IsThumbnailed
        {
            get { return isThumbnailed; }
            set { isThumbnailed = value; }
        }

        [XmlElement("TrapPrintScreen", typeof (bool))]
        public bool TrapPrintScreen
        {
            get { return trapPrintScreen; }
            set { trapPrintScreen = value; }
        }

        [XmlElement("LeavePrintScreenOnClipboard", typeof(bool))]
        public bool LeavePrintScreenOnClipboard
        {
            get { return leavePrintScreenOnClipboard; }
            set { leavePrintScreenOnClipboard = value; }
        }

        [XmlElement("HideFormDuringCapture", typeof(bool))]
        public bool HideFormDuringCapture
        {
            get { return hideFormDuringCapture; }
            set { hideFormDuringCapture = value; }
        }

        [XmlElement("HideFormAfterCapture", typeof(bool))]
        public bool HideFormAfterCapture
        {
            get { return hideFormAfterCapture; }
            set { hideFormAfterCapture = value; }
        }

        [XmlElement("IncludeMouseCursorInCapture", typeof(bool))]
        public bool IncludeMouseCursorInCapture
        {
            get { return includeMouseCursorInCapture; }
            set { includeMouseCursorInCapture = value; }
        }

        [XmlArray("PluginSettings")]
        public object[] PluginSettings
        {
            get { return pluginSettings; }
            set { pluginSettings = value; }
        }

        [XmlArray("PredefinedSizes", IsNullable = true), 
            XmlArrayItem("Size", typeof(CropSize))]
        public CropSize[] PredefinedSizes
        {
            get
            {
                if (cropSizeQueue == null)
                    cropSizeQueue = new CircularQueue<CropSize>();

                return cropSizeQueue.ToArray();
            }
            set
            {
                cropSizeQueue = new CircularQueue<CropSize>();
                foreach (CropSize size in value)
                    cropSizeQueue.Enqueue(size);
            }
        }

        [XmlArray("HotKeySettings", IsNullable = true), 
         XmlArrayItem("HotKeySetting", typeof(HotKeySetting))]
        public HotKeySetting[] HotKeySettings
        {
            get { return hotKeySettings; }
            set { hotKeySettings = value; }
        }

        #endregion

        internal Settings()
        {
            if(Environment.OSVersion.Version.Major >= 6)
                hideFormDuringCapture = true;
        }

        public Size NextFormSize()
        {
            if (cropSizeQueue == null)
                return Size.Empty;

            if (cropSizeQueue.Count == 0)
                return Size.Empty;

            CropSize size = cropSizeQueue.Next();
            return new Size(size.Width, size.Height);
        }

        internal object RetrieveSettingsForPlugin(Type settingsType)
        {
            if (PluginSettings == null)
                return null;

            foreach (object o in PluginSettings)
            {
                if (o.GetType() == settingsType)
                    return o;
            }

            return null;
        }

        private string ResolveOutputDirectory(string directory)
        {
            if (directory != OutputPath)
            {
                if (directory == null || directory.Trim().Length == 0)
                {
                    directory = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                        OutputFolder);

                    Configuration.Current.OutputPath = directory;
                    Configuration.Save();
                }
            }
            return directory;
        }
    }
}