#region Using Directives

using System.Resources;

#endregion

namespace Fusion8.Cropper
{
    internal class SR
    {
        public static string ExceptionCenterSizeOutOfRange => Keys.GetString(Keys.ExceptionCenterSizeOutOfRange);

        public static string ExceptionUnhandled => Keys.GetString(Keys.ExceptionUnhandled);

        public static string ExceptionUnhandledCaption => Keys.GetString(Keys.ExceptionUnhandledCaption);

        public static string FolderBrowseText => Keys.GetString(Keys.FolderBrowseText);

        public static string HomepageLinkUrl => Keys.GetString(Keys.HomepageLinkUrl);

        public static string MenuAbout => Keys.GetString(Keys.MenuAbout);

        public static string MenuBrowse => Keys.GetString(Keys.MenuBrowse);

        public static string MenuExit => Keys.GetString(Keys.MenuExit);

        public static string MenuHelp => Keys.GetString(Keys.MenuHelp);

        public static string MenuHelpHowTo => Keys.GetString(Keys.MenuHelpHowTo);

        public static string MenuHelpWeb => Keys.GetString(Keys.MenuHelpWeb);

        public static string MenuHide => Keys.GetString(Keys.MenuHide);

        public static string MenuInvert => Keys.GetString(Keys.MenuInvert);

        public static string MenuOnTop => Keys.GetString(Keys.MenuOnTop);

        public static string MenuOpacity => Keys.GetString(Keys.MenuOpacity);

        public static string MenuOptions => Keys.GetString(Keys.MenuOptions);

        public static string MenuOutput => Keys.GetString(Keys.MenuOutput);

        public static string MenuReset => Keys.GetString(Keys.MenuReset);

        public static string MenuSeperator => Keys.GetString(Keys.MenuSeperator);

        public static string MenuShow => Keys.GetString(Keys.MenuShow);

        public static string MenuSize => Keys.GetString(Keys.MenuSize);

        public static string MenuThumbSize => Keys.GetString(Keys.MenuThumbSize);

        public static string MenuThumbnail => Keys.GetString(Keys.MenuThumbnail);

        public static string MenuUnknownCaption => Keys.GetString(Keys.MenuUnknownCaption);

        public static string MenuUnknownText => Keys.GetString(Keys.MenuUnknownText);

        public static string MessageAbout => Keys.GetString(Keys.MessageAbout);

        public static string MessageHelp => Keys.GetString(Keys.MessageHelp);

        public static string MessageInvalidPathCharacters => Keys.GetString(Keys.MessageInvalidPathCharacters);

        public static string MessageInvalidTemplateCharacters => Keys.GetString(Keys.MessageInvalidTemplateCharacters);

        public static string MessageNoOutputLoaded => Keys.GetString(Keys.MessageNoOutputLoaded);

        public static string OptionFullImageTemplateLabelText => Keys.GetString(Keys.OptionFullImageTemplateLabelText);

        public static string OptionHotKeysDescription => Keys.GetString(Keys.OptionHotKeysDescription);

        public static string OptionNonRectWindowsDescription => Keys.GetString(Keys.OptionNonRectWindowsDescription);

        public static string OptionOutputFolderGroupText => Keys.GetString(Keys.OptionOutputFolderGroupText);

        public static string OptionOutputFolderLabelTemplate => Keys.GetString(Keys.OptionOutputFolderLabelTemplate);

        public static string OptionOutputTemplateGroupText => Keys.GetString(Keys.OptionOutputTemplateGroupText);

        public static string OptionOutputTemplatesDescription => Keys.GetString(Keys.OptionOutputTemplatesDescription);

        public static string OptionThumbImageTemplateLabelText => Keys.GetString(Keys.OptionThumbImageTemplateLabelText);

        public static string OptionVisibility => Keys.GetString(Keys.OptionVisibility);

        private class Keys
        {
            public const string ExceptionCenterSizeOutOfRange = "ExceptionCenterSizeOutOfRange";

            public const string ExceptionUnhandled = "ExceptionUnhandled";

            public const string ExceptionUnhandledCaption = "ExceptionUnhandledCaption";

            public const string FolderBrowseText = "FolderBrowseText";

            public const string HomepageLinkUrl = "HomepageLinkUrl";

            public const string MenuAbout = "MenuAbout";

            public const string MenuBrowse = "MenuBrowse";

            public const string MenuExit = "MenuExit";

            public const string MenuHelp = "MenuHelp";

            public const string MenuHelpHowTo = "MenuHelpHowTo";

            public const string MenuHelpWeb = "MenuHelpWeb";

            public const string MenuHide = "MenuHide";

            public const string MenuInvert = "MenuInvert";

            public const string MenuOnTop = "MenuOnTop";

            public const string MenuOpacity = "MenuOpacity";

            public const string MenuOptions = "MenuOptions";

            public const string MenuOutput = "MenuOutput";

            public const string MenuReset = "MenuReset";

            public const string MenuSeperator = "MenuSeperator";

            public const string MenuShow = "MenuShow";

            public const string MenuSize = "MenuSize";

            public const string MenuThumbSize = "MenuThumbSize";

            public const string MenuThumbnail = "MenuThumbnail";

            public const string MenuUnknownCaption = "MenuUnknownCaption";

            public const string MenuUnknownText = "MenuUnknownText";

            public const string MessageAbout = "MessageAbout";

            public const string MessageHelp = "MessageHelp";

            public const string MessageInvalidPathCharacters = "MessageInvalidPathCharacters";

            public const string MessageInvalidTemplateCharacters = "MessageInvalidTemplateCharacters";

            public const string MessageNoOutputLoaded = "MessageNoOutputLoaded";

            public const string OptionFullImageTemplateLabelText = "OptionFullImageTemplateLabelText";

            public const string OptionHotKeysDescription = "OptionHotKeysDescription";

            public const string OptionNonRectWindowsDescription = "OptionNonRectWindowsDescription";

            public const string OptionOutputFolderGroupText = "OptionOutputFolderGroupText";

            public const string OptionOutputFolderLabelTemplate = "OptionOutputFolderLabelTemplate";

            public const string OptionOutputTemplateGroupText = "OptionOutputTemplateGroupText";

            public const string OptionOutputTemplatesDescription = "OptionOutputTemplatesDescription";

            public const string OptionThumbImageTemplateLabelText = "OptionThumbImageTemplateLabelText";

            public const string OptionVisibility = "OptionVisibility";

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