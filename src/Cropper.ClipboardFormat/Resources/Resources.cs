#region Using Directives

using System.Globalization;

#endregion

namespace Fusion8.Cropper
{
    /// <devdoc>
    ///     Used for the culture in SR
    /// </devdoc>
    internal sealed class Resources
    {
        private Resources() { }

        public static CultureInfo CultureInfo => CultureInfo.CurrentUICulture;
    }
}