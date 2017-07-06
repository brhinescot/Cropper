#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Summary description for JpgFormat.
    /// </summary>
    public class JpgFormat : DesignablePluginThatUsesFetchOutputStream, IConfigurablePlugin
    {
        #region Member Variables

        private long imageQuality = 80L;
        private const string EncoderType = "image/jpeg";
        private const int EncoderParameterCount = 1;
        private MenuItem menuItem;
        private JpegOptions configurationForm;
        private JpegSettings settings;

        #endregion

        #region IPersistableImageFormat Members

        public override string Extension
        {
            get { return PluginSettings.Extension; }
        }

        public override string Description
        {
            get { return "Jpeg"; }
        }

        public override MenuItem Menu
        {
            get
            {
                if (menuItem != null)
                    return menuItem;

                menuItem = new MenuItem();
                menuItem.Text = Description;
                MenuItem subMenu = new MenuItem("Quality");
                subMenu.Enabled = false;
                menuItem.MenuItems.Add(subMenu);
                subMenu = new MenuItem("-");
                menuItem.MenuItems.Add(subMenu);
                for (int j = 10; j <= 100; j += 10)
                    AddImageQualityMenuItem(j.ToString(CultureInfo.InvariantCulture), menuItem);

                return menuItem;
            }
        }

        #endregion

        #region IConfigurablePlugin Members

        /// <summary>
        /// Gets the plug-in's impementation of the <see cref="BaseConfigurationForm"/> used 
        /// for setting plug-in specific options.
        /// </summary>
        public BaseConfigurationForm ConfigurationForm
        {
            get
            {
                if (configurationForm == null)
                {
                    configurationForm = new JpegOptions();
                    configurationForm.Extension = PluginSettings.Extension;
                    configurationForm.OptionsSaved += new EventHandler(HandleConfigurationFormOptionsSaved);
                }
                return configurationForm;
            }
        }

        void HandleConfigurationFormOptionsSaved(object sender, EventArgs e)
        {
            PluginSettings.Extension = configurationForm.Extension;
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="IConfigurablePlugin.ConfigurationForm"/> is to be hosted 
        /// in the options dialog or shown in its own dialog window.
        /// </summary>
        public bool HostInOptions
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets an object containing the plug-in's settings.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property is set during startup with the settings contained in the applications
        /// configuration file.</para>
        /// <para>
        /// The object returned by this property is serialized into the applications configuration
        /// file on shutdown.</para></remarks>
        public object Settings
        {
            get { return PluginSettings; }
            set { PluginSettings = value as JpegSettings; }
        }

        // Helper property for IConfigurablePlugin Implementation
        private JpegSettings PluginSettings
        {
            get
            {
                if (settings == null)
                    settings = new JpegSettings();
                return settings;
            }
            set { settings = value; }
        }

        #endregion

        #region Image Saving

        protected override void SaveImage(Stream stream, Image image)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            myImageCodecInfo = GetEncoderInfo(EncoderType);
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(EncoderParameterCount);
            myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            try
            {
                image.Save(stream, myImageCodecInfo, myEncoderParameters);
            }
            finally
            {
                myEncoderParameters.Dispose();
                myEncoderParameter.Dispose();
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion

        private MenuItem AddImageQualityMenuItem(string text, MenuItem parent)
        {
            MenuItem subMenu = new MenuItem(text);
            subMenu.RadioCheck = true;
            if (text == imageQuality.ToString(CultureInfo.InvariantCulture))
                subMenu.Checked = true;
            subMenu.Click += new EventHandler(ImageQualityMenuHandler);
            parent.MenuItems.Add(subMenu);
            return subMenu;
        }

        #region Event Handling

        private void ImageQualityMenuHandler(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem) sender;
            imageQuality = long.Parse(item.Text, CultureInfo.InvariantCulture);

            ImageFormatEventArgs formatEvents = new ImageFormatEventArgs();
            formatEvents.ClickedMenuItem = item;
            formatEvents.ImageOutputFormat = this;
            OnImageFormatClick(sender, formatEvents);
        }

        #endregion

        public override string ToString()
        {
            return "Jpeg Format [Fusion8] ";
        }
    }
}