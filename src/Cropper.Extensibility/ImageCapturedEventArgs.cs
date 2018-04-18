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

        /// <summary>
        ///     Gets or sets a value indicating whether a full size image need to save with the thumbnail.
        /// </summary>
        public bool SaveFullImage { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating if the plugin will continue capturing multiple screenshots.
        /// </summary>
        public bool ContinueCapturing { get; set; }
    }
}