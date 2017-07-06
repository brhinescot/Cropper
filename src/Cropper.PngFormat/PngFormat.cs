#region Using Directives

using System.Drawing.Imaging;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    ///     Summary description for PngFormat.
    /// </summary>
    public class PngFormat : DesignablePluginThatUsesFetchOutputStreamAndSave
    {
        public override string Extension => "png";

        public override string Description => "Png";

        protected override ImageFormat Format => ImageFormat.Png;
    }
}