#region Using Directives

using System;
using System.Drawing;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Provides data for the <see cref="IPersistableOutput.ImageCaptured" /> event.
    /// </summary>
    public class ImageCapturedEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the names for the captured image.
        /// </summary>
        public ImagePairNames ImageNames { get; set; }

        /// <summary>
        ///     Gets or sets the full sized captured image.
        /// </summary>
        public Image FullSizeImage { get; set; }

        /// <summary>
        ///     Gets or sets a thumbnail of the captured image.
        /// </summary>
        public Image ThumbnailImage { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether a thumbnail was captured with the full size image.
        /// </summary>
        public bool IsThumbnailed { get; set; }
    }
}