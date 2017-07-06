using System.Globalization;

namespace Fusion8.Cropper.Core
{
	/// <devdoc>
	/// Used for the culture in SR
	/// </devdoc>
	internal sealed class Resources
	{
		private Resources() {}

		public static CultureInfo CultureInfo
		{
			get { return CultureInfo.CurrentUICulture; }
		}
	}
}