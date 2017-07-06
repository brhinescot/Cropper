#region Using Directives

using System.Drawing.Imaging;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Summary description for PngFormat.
    /// </summary>
    public class PngFormat : DesignablePluginThatUsesFetchOutputStreamAndSave
    {
        public override string Extension
        {
            get { return "png"; }
        }

        public override string Description
        {
            get { return "Png"; }
        }

        protected override ImageFormat Format
        {
            get { return ImageFormat.Png; }
        }
    }
}