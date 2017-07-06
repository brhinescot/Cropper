#region Using Directives

using System;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Provides data for the <see cref="IPersistableImageFormat.ImageFormatClick" /> event.
    /// </summary>
    public class ImageFormatEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the clicked <see cref="MenuItem" />.
        /// </summary>
        public MenuItem ClickedMenuItem { get; set; }

        /// <summary>
        ///     Gets or sets the image output format.
        /// </summary>
        public IPersistableImageFormat ImageOutputFormat { get; set; }
    }
}