#region Using Directives

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    public abstract class DesignablePluginThatUsesFetchOutputStreamAndSave : DesignablePluginThatUsesFetchOutputStream
    {
        protected abstract ImageFormat Format { get; }

        protected override void SaveImage(Stream stream, Image image)
        {
            image.Save(stream, Format);
        }
    }
}