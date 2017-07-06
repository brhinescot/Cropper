#region Using Directives

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
	/// <summary>
	/// Summary description for CropFormDarkColorTable.
	/// </summary>
	public class CropFormBlueColorTable : CropFormColorTable
	{
		public override Color TabColor
		{
			get { return Color.FromArgb(TabAlphaChannel, SystemColors.Highlight); }
		}

		public override Color TabHighlightColor
		{
			get { return Color.FromArgb(TabAlphaChannel, SystemColors.Highlight); }
		}

		public override Color TabTextColor
		{
			get { return SystemColors.HighlightText; }
		}

		public override Color TabTextHighlightColor
		{
			get { return SystemColors.HighlightText; }
		}

		public override Color FormColor
		{
			get { return Color.FromArgb(MainAlphaChannel, 194, 207, 229); }
		}

		public override Color FormHighlightColor
		{
			get { return Color.FromArgb(MainAlphaChannel, 194, 207, 229); }
		}

		public override Color FormTextColor
		{
			get { return SystemColors.Highlight; }
		}

		public override Color FormTextHighlightColor
		{
			get { return SystemColors.Highlight; }
		}

		public override Color LineColor
		{
			get { return SystemColors.Highlight; }
		}

		public override Color LineHighlightColor
		{
			get { return Color.Firebrick; }
		}
	}
}