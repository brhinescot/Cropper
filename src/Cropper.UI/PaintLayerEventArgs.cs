#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Text;

#endregion

namespace Fusion8.Cropper
{
	public class PaintLayerEventArgs : EventArgs, IDisposable
	{
		#region Member Fields 

		private readonly Graphics graphics;
		private readonly Bitmap surface;
		private readonly Size size;

		#endregion

		#region Property Accessors 

		/// <summary>
		/// Gets the bounds.
		/// </summary>
		/// <value>The bounds.</value>
		public Rectangle Bounds
		{
			get { return new Rectangle(Point.Empty, Size); }
		}

		/// <summary>
		/// Gets the size.
		/// </summary>
		/// <value>The size.</value>
		public Size Size
		{
			get { return size; }
		}

		/// <summary>
		/// Gets the graphics.
		/// </summary>
		/// <value>The graphics.</value>
		public Graphics Graphics
		{
			get { return graphics; }
		}

		/// <summary>
		/// Gets the image.
		/// </summary>
		/// <value>The image.</value>
		internal Bitmap Image
		{
			get { return surface; }
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="PaintLayerEventArgs"/> class.
		/// </summary>
		public PaintLayerEventArgs() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="PaintLayerEventArgs"/> class.
		/// </summary>
		/// <param name="bitmap">The bitmap.</param>
		internal PaintLayerEventArgs(Bitmap bitmap)
		{
			surface = bitmap;
			graphics = Graphics.FromImage(surface);
			graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
			size = new Size(bitmap.Width, bitmap.Height);
		}

		/// <summary>
		/// Disposes this instance.
		/// </summary>
		public void Dispose()
		{
			if (graphics != null)
				graphics.Dispose();
			if (surface != null)
				surface.Dispose();
		}
	}
}