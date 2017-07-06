#region Using Directives

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    ///     Summary description for CropFormDarkColorTable.
    /// </summary>
    public class CropFormDarkColorTable : CropFormColorTable
    {
        public override Color TabColor => Color.FromArgb(TabAlphaChannel, Color.Firebrick);

        public override Color TabHighlightColor => Color.FromArgb(TabAlphaChannel, Color.Firebrick);

        public override Color TabTextColor => Color.White;

        public override Color TabTextHighlightColor => Color.White;

        public override Color FormColor => Color.FromArgb(MainAlphaChannel, Color.Black);

        public override Color FormHighlightColor => Color.FromArgb(MainAlphaChannel, Color.Black);

        public override Color FormTextColor => Color.White;

        public override Color FormTextHighlightColor => Color.White;

        public override Color LineColor => Color.White;

        public override Color LineHighlightColor => Color.Firebrick;
    }
}