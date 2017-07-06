#region Using Directives

using System.Drawing.Imaging;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Summary description for BmpFormat.
    /// </summary>
    public class BmpFormat : DesignablePluginThatUsesFetchOutputStreamAndSave
    {
        public override string Extension
        {
            get { return "bmp"; }
        }

        public override string Description
        {
            get { return "Bmp"; }
        }

        protected override ImageFormat Format
        {
            get { return ImageFormat.Bmp; }
        }
    }
}