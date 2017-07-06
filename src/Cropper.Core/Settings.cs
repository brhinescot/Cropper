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
    ///     Summary description for Settings.
    /// </summary>
    [XmlRoot(XmlRootName, Namespace = RootNamespace, IsNullable = false)]
    public class Settings
    {
        internal const string XmlRootName = "Configuration";
        internal const string RootNamespace = "http://www.fusion8design.com";

        internal static readonly string DefaultOutputPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), OutputFolder);

        internal Settings()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                HideFormDuringCapture = true;
        }

        [XmlIgnore]
        public IWin32Window ActiveCropWindow { get; set; }

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
                if (o.GetType() == settingsType)
                    return o;

            return null;
        }

        private string ResolveOutputDirectory(string directory)
        {
            if (directory != OutputPath)
                if (directory == null || directory.Trim().Length == 0)
                {
                    directory = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                        OutputFolder);

                    Configuration.Current.OutputPath = directory;
                    Configuration.Save();
                }
            return directory;
        }

        #region Member Variables

        private const string OutputFolder = "Cropper Captures";

        private string outputPath = DefaultOutputPath;

        private CircularQueue<CropSize> cropSizeQueue;

        #endregion

        #region Property Accessors

        /// <summary>
        ///     Allow multiple instances per user
        /// </summary>
        [XmlElement("AllowMultipleInstances", typeof(bool))]
        public bool AllowMultipleInstances { get; set; } = true;

        /// <summary>
        ///     The users last used image format.
        /// </summary>
        [XmlElement("ImageFormat", typeof(string))]
        public string ImageFormat { get; set; } = "Bmp";

        /// <summary>
        ///     The users last used output directory.
        /// </summary>
        [XmlElement("OutputDirectory", typeof(string))]
        public string OutputPath
        {
            get => outputPath;
            set => outputPath = ResolveOutputDirectory(value);
        }

        [XmlElement("ColorIndex", typeof(int))]
        public int ColorIndex { get; set; }

        /// <summary>
        ///     The users last used opacity level.
        /// </summary>
        [XmlElement("UserOpacity", typeof(double))]
        public double UserOpacity { get; set; } = 0.40d;

        /// <summary>
        ///     The users last used thumbnail size.
        /// </summary>
        [XmlElement("MaxThumbnailSize", typeof(double))]
        public double MaxThumbnailSize { get; set; } = 80d;

        /// <summary>
        ///     The users last chosen window size.
        /// </summary>
        /// <remarks>
        ///     This property is being expanded to allow the user to save a list of common
        ///     used sizes.
        /// </remarks>
        [XmlElement("UserSize")]
        public Size UserSize { get; set; } = new Size(300, 300);

        /// <summary>
        ///     The last location of the form.
        /// </summary>
        [XmlElement("Location")]
        public Point Location { get; set; } = new Point(100, 100);

        /// <summary>
        ///     The users last used image format.
        /// </summary>
        [XmlElement("FullImageTemplate", typeof(string))]
        public string FullImageTemplate { get; set; } = FileNameTemplate.DefaultFullImageTemplate;

        /// <summary>
        ///     The users last used image format.
        /// </summary>
        [XmlElement("ThumbImageTemplate", typeof(string))]
        public string ThumbImageTemplate { get; set; } = FileNameTemplate.DefaultThumbImageTemplate;

        /// <summary>
        ///     The users last used image format.
        /// </summary>
        [XmlElement("NonFormAreaColorArgb", typeof(int))]
        public int NonFormAreaColorArgb { get; set; } = Color.White.ToArgb();

        [XmlElement("ColorNonFormArea", typeof(bool))]
        public bool ColorNonFormArea { get; set; } = true;

        [XmlElement("AlwaysOnTop", typeof(bool))]
        public bool AlwaysOnTop { get; set; }

        [XmlElement("Hidden", typeof(bool))]
        public bool Hidden { get; set; } = true;

        [XmlElement("ShowOpacityMenu", typeof(bool))]
        public bool ShowOpacityMenu { get; set; }

        [XmlElement("UsePerPixelAlpha", typeof(bool))]
        public bool UsePerPixelAlpha { get; set; } = true;

        [XmlElement("IsThumbnailed", typeof(bool))]
        public bool IsThumbnailed { get; set; }

        [XmlElement("TrapPrintScreen", typeof(bool))]
        public bool TrapPrintScreen { get; set; } = true;

        [XmlElement("LeavePrintScreenOnClipboard", typeof(bool))]
        public bool LeavePrintScreenOnClipboard { get; set; } = true;

        [XmlElement("HideFormDuringCapture", typeof(bool))]
        public bool HideFormDuringCapture { get; set; }

        [XmlElement("HideFormAfterCapture", typeof(bool))]
        public bool HideFormAfterCapture { get; set; }

        [XmlElement("IncludeMouseCursorInCapture", typeof(bool))]
        public bool IncludeMouseCursorInCapture { get; set; }

        [XmlArray("PluginSettings")]
        public object[] PluginSettings { get; set; }

        [XmlArray("PredefinedSizes", IsNullable = true)]
        [XmlArrayItem("Size", typeof(CropSize))]
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

        [XmlArray("HotKeySettings", IsNullable = true)]
        [XmlArrayItem("HotKeySetting", typeof(HotKeySetting))]
        public HotKeySetting[] HotKeySettings { get; set; }

        #endregion
    }
}