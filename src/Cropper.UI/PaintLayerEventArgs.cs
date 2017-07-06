#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Text;

#endregion

namespace Fusion8.Cropper
{
    public class PaintLayerEventArgs : EventArgs, IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PaintLayerEventArgs" /> class.
        /// </summary>
        public PaintLayerEventArgs() { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaintLayerEventArgs" /> class.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        internal PaintLayerEventArgs(Bitmap bitmap)
        {
            Image = bitmap;
            Graphics = Graphics.FromImage(Image);
            Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            Size = new Size(bitmap.Width, bitmap.Height);
        }

        /// <summary>
        ///     Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            if (Graphics != null)
                Graphics.Dispose();
            if (Image != null)
                Image.Dispose();
        }

        #region Member Fields 

        #endregion

        #region Property Accessors 

        /// <summary>
        ///     Gets the bounds.
        /// </summary>
        /// <value>The bounds.</value>
        public Rectangle Bounds => new Rectangle(Point.Empty, Size);

        /// <summary>
        ///     Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size { get; }

        /// <summary>
        ///     Gets the graphics.
        /// </summary>
        /// <value>The graphics.</value>
        public Graphics Graphics { get; }

        /// <summary>
        ///     Gets the image.
        /// </summary>
        /// <value>The image.</value>
        internal Bitmap Image { get; }

        #endregion
    }
}