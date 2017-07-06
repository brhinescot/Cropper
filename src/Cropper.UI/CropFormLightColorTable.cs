#region Using Directives

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    ///     Summary description for CropFormDarkColorTable.
    /// </summary>
    public class CropFormLightColorTable : CropFormColorTable
    {
        public override Color TabColor => Color.FromArgb(TabAlphaChannel, Color.SteelBlue);

        public override Color TabHighlightColor => Color.FromArgb(TabAlphaChannel, Color.SteelBlue);

        public override Color TabTextColor => Color.White;

        public override Color TabTextHighlightColor => Color.White;

        public override Color FormColor => Color.FromArgb(MainAlphaChannel, Color.White);

        public override Color FormHighlightColor => Color.FromArgb(MainAlphaChannel, Color.White);

        public override Color FormTextColor => Color.Black;

        public override Color FormTextHighlightColor => Color.Black;

        public override Color LineColor => Color.Black;

        public override Color LineHighlightColor => Color.Firebrick;
    }
}