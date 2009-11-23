using System.Drawing;

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    /// Summary description for CropFormColorTable.
    /// </summary>
    public abstract class CropFormColorTable
    {
        private int mainAlphaChannel;
        private int tabAlphaChannel = 200;

        public virtual bool SupportsPerPixelAlpha
        {
            get { return true; }
        }

        public virtual int MainAlphaChannel
        {
            get { return mainAlphaChannel; }
            set { mainAlphaChannel = value; }
        }

        public int TabAlphaChannel
        {
            get { return tabAlphaChannel; }
            set { tabAlphaChannel = value; }
        }

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