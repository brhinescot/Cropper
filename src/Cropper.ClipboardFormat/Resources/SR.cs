#region Using Directives

using System.Resources;

#endregion

namespace Fusion8.Cropper
{
    internal class SR
    {
        public static string BitmapDescription => Keys.GetString(Keys.BitmapDescription);

        public static string JpgDescription => Keys.GetString(Keys.JpgDescription);

        public static string PngDescription => Keys.GetString(Keys.PngDescription);

        public static string ImageQuality(object @int)
        {
            return Keys.GetString(Keys.ImageQuality, new[]
            {
                @int
            });
        }

        private class Keys
        {
            public const string BitmapDescription = "BitmapDescription";

            public const string ImageQuality = "ImageQuality";

            public const string JpgDescription = "JpgDescription";

            public const string PngDescription = "PngDescription";

            private static readonly ResourceManager resourceManager = new ResourceManager("Fusion8.Cropper.Resources.SR", typeof(SR).Assembly);

            public static string GetString(string key)
            {
                return resourceManager.GetString(key, Resources.CultureInfo);
            }

            public static string GetString(string key, object[] args)
            {
                string msg = resourceManager.GetString(key, Resources.CultureInfo);
                msg = string.Format(msg, args);
                return msg;
            }
        }
    }
}