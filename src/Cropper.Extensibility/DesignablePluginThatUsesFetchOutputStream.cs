#region Using Directives

using System.Drawing;
using System.IO;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    public abstract class DesignablePluginThatUsesFetchOutputStream : DesignablePlugin
    {
        protected override void ImageCaptured(object sender, ImageCapturedEventArgs e)
        {
            if (e.SaveFullImage)
                output.FetchOutputStream(SaveImage, e.ImageNames.FullSize, e.FullSizeImage);

            if (e.IsThumbnailed)
                output.FetchOutputStream(SaveImage, e.ImageNames.Thumbnail, e.ThumbnailImage);
        }

        protected abstract void SaveImage(Stream stream, Image image);
    }
}