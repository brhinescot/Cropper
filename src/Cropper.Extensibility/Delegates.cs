#region Using Directives

using System.Drawing;
using System.IO;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    public delegate void ImageFormatClickEventHandler(object sender, ImageFormatEventArgs e);

    public delegate void ImageCaptureInitializedEventHandler(object sender, ImageCaptureInitializedEventArgs e);

    public delegate void ImageCapturingEventHandler(object sender, ImageCapturingEventArgs e);

    public delegate void ImageCapturedEventHandler(object sender, ImageCapturedEventArgs e);

    public delegate void StreamHandler(Stream stream, Image image);

    public delegate void ImageHandler(Image image);
}