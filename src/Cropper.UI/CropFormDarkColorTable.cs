#region Using Directives 

using System.Drawing;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
	/// <summary>
	/// Summary description for CropFormDarkColorTable.
	/// </summary>
	public class CropFormDarkColorTable : CropFormColorTable
	{
		public override Color TabColor
		{
			get { return Color.FromArgb(TabAlphaChannel, Color.Firebrick); }
		}

		public override Color TabHighlightColor
		{
			get { return Color.FromArgb(TabAlphaChannel, Color.Firebrick); }
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
			get { return Color.FromArgb(MainAlphaChannel, Color.Black); }
		}

		public override Color FormHighlightColor
		{
			get { return Color.FromArgb(MainAlphaChannel, Color.Black); }
		}

		public override Color FormTextColor
		{
			get { return Color.White; }
		}

		public override Color FormTextHighlightColor
		{
			get { return Color.White; }
		}

		public override Color LineColor
		{
			get { return Color.White; }
		}

		public override Color LineHighlightColor
		{
			get { return Color.Firebrick; }
		}
	}
}