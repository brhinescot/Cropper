#region Using Directives

using System.Drawing;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Summary description for CropFormColorTable.
    /// </summary>
    public abstract class CropFormColorTable
    {
        protected CropFormColorTable()
        {
            TabAlphaChannel = 200;
        }

        public virtual bool SupportsPerPixelAlpha => true;

        public virtual int MainAlphaChannel { get; set; }

        public int TabAlphaChannel { get; set; }

        public abstract Color TabColor { get; }
        public abstract Color TabHighlightColor { get; }
        public abstract Color TabTextColor { get; }
        public abstract Color TabTextHighlightColor { get; }
        public abstract Color FormColor { get; }
        public abstract Color FormHighlightColor { get; }
        public abstract Color FormTextColor { get; }
        public abstract Color FormTextHighlightColor { get; }
        public abstract Color LineColor { get; }
        public abstract Color LineHighlightColor { get; }
    }
}