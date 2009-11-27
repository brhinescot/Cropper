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