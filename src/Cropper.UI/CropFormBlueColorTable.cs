#region Using Directives

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    ///     Summary description for CropFormDarkColorTable.
    /// </summary>
    public class CropFormBlueColorTable : CropFormColorTable
    {
        public override Color TabColor => Color.FromArgb(TabAlphaChannel, SystemColors.Highlight);

        public override Color TabHighlightColor => Color.FromArgb(TabAlphaChannel, SystemColors.Highlight);

        public override Color TabTextColor => SystemColors.HighlightText;

        public override Color TabTextHighlightColor => SystemColors.HighlightText;

        public override Color FormColor => Color.FromArgb(MainAlphaChannel, 194, 207, 229);

        public override Color FormHighlightColor => Color.FromArgb(MainAlphaChannel, 194, 207, 229);

        public override Color FormTextColor => SystemColors.Highlight;

        public override Color FormTextHighlightColor => SystemColors.Highlight;

        public override Color LineColor => SystemColors.Highlight;

        public override Color LineHighlightColor => Color.Firebrick;
    }
}