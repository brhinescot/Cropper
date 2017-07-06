#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Summary description for ClipboardFormatClipboardFormat.
    /// </summary>
    public class ClipboardFormat : DesignablePlugin, IConfigurablePlugin
    {
        private Options configurationForm;
        private ClipboardOutputSettings settings;
        private const string EncoderType = "image/jpeg";
        private const int EncoderParameterCount = 1;

        public override string Extension
        {
            get { return "Clipboard"; }
        }

        public override string Description
        {
            get { return "Clipboard"; }
        }

        /// <summary>
        /// Gets the plug-ins impementation of the <see cref="BaseConfigurationForm"/> used 
        /// for setting plug-in specific options.
        /// </summary>
        public BaseConfigurationForm ConfigurationForm
        {
            get
            {
                if (configurationForm == null)
                {
                    configurationForm = new Options();
                    configurationForm.OptionsSaved += HandleConfigurationFormOptionsSaved;
                    configurationForm.Format = PluginSettings.Format;
                    configurationForm.ImageQuality = PluginSettings.ImageQuality;
                }
                return configurationForm;
            }
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="ConfigurationForm"/> is to be hosted 
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
            set { PluginSettings = value as ClipboardOutputSettings; }
        }

        // Helper property for IConfigurablePlugin Implementation
        private ClipboardOutputSettings PluginSettings
        {
            get
            {
                if (settings == null)
                    settings = new ClipboardOutputSettings();
                return settings;
            }
            set { settings = value; }
        }

        private void HandleConfigurationFormOptionsSaved(object sender, EventArgs e)
        {
            PluginSettings.Format = configurationForm.Format;
            PluginSettings.ImageQuality = configurationForm.ImageQuality;
        }

        protected override void ImageCaptured(object sender, ImageCapturedEventArgs e)
        {
            try
            {
                switch (PluginSettings.Format)
                {
                    case ClipboardOutputFormat.Bitmap:
                        Clipboard.SetImage(e.FullSizeImage);
                        break;
                    case ClipboardOutputFormat.Jpg:
                        using (MemoryStream stream = new MemoryStream())
                        {
                            SaveJpegImage(stream, e.FullSizeImage);
                            using (Image bitmap = Bitmap.FromStream(stream))
                                Clipboard.SetDataObject(bitmap, true);
                        }
                        break;
                    case ClipboardOutputFormat.Png:
                        using (MemoryStream stream = new MemoryStream())
                        {
                            e.FullSizeImage.Save(stream, ImageFormat.Png);
                            using (Image bitmap = Bitmap.FromStream(stream))
                                Clipboard.SetDataObject(bitmap, true);
                        }
                        break;
                }
            }
            catch (ExternalException ex)
            {
                throw new InvalidOperationException("The image was not saved to the clipboard.", ex);
            }
        }

        private void SaveJpegImage(Stream stream, Image image)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            myImageCodecInfo = GetEncoderInfo(EncoderType);
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(EncoderParameterCount);
            myEncoderParameter = new EncoderParameter(myEncoder, PluginSettings.ImageQuality);
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

        public override string ToString()
        {
            return "Clipboard Format [Fusion8]";
        }
    }
}