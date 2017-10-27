#region Using Directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper
{
    public class LayeredForm : Form
    {
        #region .ctor

        protected LayeredForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            
        }

        #endregion

        #region Windows Message Handling

        protected override CreateParams CreateParams
        {
            get
            {
                if (DesignMode)
                    return base.CreateParams;

                CreateParams cp = base.CreateParams;
                cp.ExStyle |= NativeMethods.WS_EX_LAYERED;
                cp.Style |= NativeMethods.WS_MINIMIZEBOX;
                cp.ClassStyle |= NativeMethods.CS_DBLCLKS;
                return cp;
            }
        }

        #endregion

        [Category("Appearance")]
        [Description("Occurs when the layered form needs repainting.")]
        protected event EventHandler<PaintLayerEventArgs> PaintLayer;

        #region Method Overrides

        protected override void OnResize(EventArgs e)
        {
            if (freezePainting) return;
            PaintLayeredWindow();
            base.OnResize(e);
        }

        #endregion

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (DesignMode)
                base.OnPaintBackground(pevent);

            // Eat event to prevent rendering error when WM_PAINT message is sent.
        }

        #region Member Fields

        private bool freezePainting;
        private double layerOpacity = 1.0;

        #endregion

        #region Property Accessors

        public double LayerOpacity
        {
            get => layerOpacity;
            set
            {
                if (value > 1)
                    value = 1;
                else if (value < 0)
                    value = 0;

                layerOpacity = value;
                PaintLayeredWindow();
            }
        }

        private byte OpacityAsByte => (byte) (layerOpacity * 255);

        protected bool FreezePainting
        {
            get => freezePainting;
            set
            {
                if (freezePainting && value == false)
                    PaintLayeredWindow();
                freezePainting = value;
            }
        }

        #endregion

        #region Painting Methods

        /// <summary>
        ///     Raises the <see cref="PaintLayer" /> event.
        /// </summary>
        /// <param name="e">
        ///     A <see cref="PaintLayerEventArgs" /> object containing the
        ///     event data.
        /// </param>
        protected virtual void OnPaintLayer(PaintLayerEventArgs e)
        {
            PaintLayer?.Invoke(this, e);
        }

        protected void PaintLayeredWindow()
        {
            if (Bounds.Size == Size.Empty && (ClientRectangle.Width != 0 || ClientRectangle.Height != 0)) 
                return;
            
            using (Bitmap surface = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb))
            {
                PaintLayeredWindow(surface, layerOpacity);
            }
        }

        private void PaintLayeredWindow(Bitmap bitmap, double opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ArgumentException("The bitmap must be 32bpp with an alpha-channel.", nameof(bitmap));

            layerOpacity = opacity;

            using (PaintLayerEventArgs args = new PaintLayerEventArgs(bitmap))
            {
                OnPaintLayer(args);
                PaintNative(bitmap, OpacityAsByte);
            }
        }

        private void PaintNative(Bitmap bitmap, byte opacity)
        {
            IntPtr hdcDestination = NativeMethods.GetDC(IntPtr.Zero);
            IntPtr hdcSource = NativeMethods.CreateCompatibleDC(hdcDestination);
            IntPtr hdcBitmap = IntPtr.Zero;
            IntPtr previousBitmap = IntPtr.Zero;
            try
            {
                hdcBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                previousBitmap = NativeMethods.SelectObject(hdcSource, hdcBitmap);

                NativeMethods.SIZE size = new NativeMethods.SIZE(bitmap.Width, bitmap.Height);
                NativeMethods.POINT source = new NativeMethods.POINT(0, 0);
                NativeMethods.POINT destination = new NativeMethods.POINT(Left, Top);
                NativeMethods.BLENDFUNCTION blend = new NativeMethods.BLENDFUNCTION();

                blend.BlendOp = NativeMethods.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = NativeMethods.AC_SRC_ALPHA;

                NativeMethods.UpdateLayeredWindow(
                    Handle,
                    hdcDestination,
                    ref destination,
                    ref size,
                    hdcSource,
                    ref source,
                    0,
                    ref blend,
                    2);
            }
            catch (Exception) { }
            finally
            {
                NativeMethods.ReleaseDC(IntPtr.Zero, hdcDestination);
                if (hdcBitmap != IntPtr.Zero)
                {
                    NativeMethods.SelectObject(hdcSource, previousBitmap);
                    NativeMethods.DeleteObject(hdcBitmap);
                }
                NativeMethods.DeleteDC(hdcSource);
            }
        }

        #endregion
    }
}