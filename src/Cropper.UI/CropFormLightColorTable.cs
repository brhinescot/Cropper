#region Using Directives

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
	/// <summary>
	/// Summary description for CropFormDarkColorTable.
	/// </summary>
	public class CropFormLightColorTable : CropFormColorTable
	{
		public override Color TabColor
		{
			get { return Color.FromArgb(TabAlphaChannel, Color.SteelBlue); }
		}

		public override Color TabHighlightColor
		{
			get { return Color.FromArgb(TabAlphaChannel, Color.SteelBlue); }
		}

		public override Color TabTextColor
		{
			get { return Color.White; }
		}

		public override Color TabTextHighlightColor
		{
			get { return Color.White; }
		}

		public override Color FormColor
		{
			get { return Color.FromArgb(MainAlphaChannel, Color.White); }
		}

		public override Color FormHighlightColor
		{
			get { return Color.FromArgb(MainAlphaChannel, Color.White); }
		}

		public override Color FormTextColor
		{
			get { return Color.Black; }
		}

		public override Color FormTextHighlightColor
		{
			get { return Color.Black; }
		}

		public override Color LineColor
		{
			get { return Color.Black; }
		}

		public override Color LineHighlightColor
		{
			get { return Color.Firebrick; }
		}
	}
}