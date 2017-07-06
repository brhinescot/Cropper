#region Using Directives

using System.Resources;

#endregion

namespace Fusion8.Cropper.Core
{
    internal class SR
    {
        public static string ConfigurationPath => Keys.GetString(Keys.ConfigurationPath);

        public static string ExceptionConfigObjectNull => Keys.GetString(Keys.ExceptionConfigObjectNull);

        public static string ExceptionConfigPathNull => Keys.GetString(Keys.ExceptionConfigPathNull);

        public static string ExceptionImageFormatNull => Keys.GetString(Keys.ExceptionImageFormatNull);

        public static string ExeptionThumbnailSizeOutOfRange => Keys.GetString(Keys.ExeptionThumbnailSizeOutOfRange);

        public static string MessageInvalidTemplateCharacters => Keys.GetString(Keys.MessageInvalidTemplateCharacters);

        private class Keys
        {
            public const string ConfigurationPath = "ConfigurationPath";

            public const string ExceptionConfigObjectNull = "ExceptionConfigObjectNull";

            public const string ExceptionConfigPathNull = "ExceptionConfigPathNull";

            public const string ExceptionImageFormatNull = "ExceptionImageFormatNull";

            public const string ExeptionThumbnailSizeOutOfRange = "ExeptionThumbnailSizeOutOfRange";

            public const string MessageInvalidTemplateCharacters = "MessageInvalidTemplateCharacters";

            private static readonly ResourceManager resourceManager = new ResourceManager("Fusion8.Cropper.Core.Resources.SR", typeof(SR).Assembly);

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