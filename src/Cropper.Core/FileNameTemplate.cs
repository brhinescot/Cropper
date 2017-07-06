#region Using Directives

using System;
using System.IO;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     Summary description for FileNameTemplate.
    /// </summary>
    public class FileNameTemplate
    {
        public static readonly string DefaultFullImageTemplate = "CropperCapture[{increment}]";
        public static readonly string DefaultThumbImageTemplate = "CropperCapture[{increment}]Thumbnail";

        private string fileExtension;
        private int lastIncrement = 1;

        /// <summary>
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public ImagePairNames Parse(string extension)
        {
            fileExtension = extension;
            string fullImageTemplate = GetFullImageTemplate();
            string thumbImageTemplate = GetThumbImageTemplate();

            ImagePairNames names = new
                ImagePairNames(fullImageTemplate, thumbImageTemplate);

            names = TryAddTemplateDateOrTime(names);
            names = TryAddTemplateExtension(names);
            names = TryAddTemplateUser(names);
            names = TryAddTemplateDomain(names);
            names = TryAddTemplateMachine(names);
            names = SetFileExtension(names);
            names = SetFullPath(names);
            names = TryAddTemplatePrompt(names);
            names = GetNextImagePairNames(names);
            return names;
        }

        public void ResetIncrement()
        {
            lastIncrement = 1;
        }

        private static string GetThumbImageTemplate()
        {
            return !string.IsNullOrEmpty(Configuration.Current.ThumbImageTemplate)
                ? Configuration.Current.ThumbImageTemplate
                : DefaultThumbImageTemplate;
        }

        private static string GetFullImageTemplate()
        {
            return !string.IsNullOrEmpty(Configuration.Current.FullImageTemplate)
                ? Configuration.Current.FullImageTemplate
                : DefaultFullImageTemplate;
        }

        private static ImagePairNames TryAddTemplatePrompt(ImagePairNames startNames)
        {
            if (startNames.FullSize.IndexOf(Templates.Prompt, StringComparison.Ordinal) >= 0 || startNames.Thumbnail.IndexOf(Templates.Prompt, StringComparison.Ordinal) >= 0)
            {
                Prompt prompt = new Prompt
                {
                    TopMost = true,
                    StartPosition = FormStartPosition.CenterParent
                };

                return prompt.ShowDialog(Configuration.Current.ActiveCropWindow) == DialogResult.OK
                    ? new ImagePairNames(startNames.FullSize.Replace(Templates.Prompt, prompt.Value), startNames.Thumbnail.Replace(Templates.Prompt, prompt.Value))
                    : new ImagePairNames(startNames.FullSize.Replace(Templates.Prompt, string.Empty), startNames.Thumbnail.Replace(Templates.Prompt, string.Empty));
            }
            return startNames;
        }

        private ImagePairNames TryAddTemplateExtension(ImagePairNames startNames)
        {
            return new ImagePairNames(startNames.FullSize.Replace(Templates.Extension, fileExtension), startNames.Thumbnail.Replace(Templates.Extension, fileExtension));
        }

        private static ImagePairNames TryAddTemplateUser(ImagePairNames startNames)
        {
            return new ImagePairNames(startNames.FullSize.Replace(Templates.User, Environment.UserName), startNames.Thumbnail.Replace(Templates.User, Environment.UserName));
        }

        private static ImagePairNames TryAddTemplateDomain(ImagePairNames startNames)
        {
            return new ImagePairNames(startNames.FullSize.Replace(Templates.Domain, Environment.UserDomainName), startNames.Thumbnail.Replace(Templates.Domain, Environment.UserDomainName));
        }

        private static ImagePairNames TryAddTemplateMachine(ImagePairNames startNames)
        {
            return new ImagePairNames(startNames.FullSize.Replace(Templates.Machine, Environment.MachineName), startNames.Thumbnail.Replace(Templates.Machine, Environment.MachineName));
        }

        private static ImagePairNames TryAddTemplateDateOrTime(ImagePairNames startNames)
        {
            DateTime now = DateTime.Now;

            string fullSize = startNames.FullSize.Replace(Templates.Date, now.ToString("MM-dd-yyyy"))
                .Replace(Templates.Time, now.ToString("hh-mm-ss tt"))
                .Replace(Templates.Timestamp, now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff"));

            string thumbnail = startNames.Thumbnail.Replace(Templates.Date, now.ToString("MM-dd-yyyy"))
                .Replace(Templates.Time, now.ToString("hh-mm-ss tt"))
                .Replace(Templates.Timestamp, now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff"));

            return new ImagePairNames(fullSize, thumbnail);
        }

        private ImagePairNames SetFileExtension(ImagePairNames names)
        {
            return new ImagePairNames($"{names.FullSize}.{fileExtension}", $"{names.Thumbnail}.{fileExtension}");
        }

        private static ImagePairNames SetFullPath(ImagePairNames names)
        {
            return new ImagePairNames(Path.Combine(Configuration.Current.OutputPath, names.FullSize), Path.Combine(Configuration.Current.OutputPath, names.Thumbnail));
        }

        private ImagePairNames GetNextImagePairNames(ImagePairNames startNames)
        {
            if (!Directory.Exists(Path.GetDirectoryName(startNames.FullSize)))
                Directory.CreateDirectory(Path.GetDirectoryName(startNames.FullSize));

            if (!Directory.Exists(Path.GetDirectoryName(startNames.Thumbnail)))
                Directory.CreateDirectory(Path.GetDirectoryName(startNames.Thumbnail));

            string fullTemplate = startNames.FullSize;
            string thumbTemplate = startNames.Thumbnail;

            string fullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
            string thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());

            if (!File.Exists(fullSize) && !File.Exists(thumbnail))
            {
                ResetIncrement();
                fullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
                thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());
            }

            while (File.Exists(fullSize) || File.Exists(thumbnail))
            {
                lastIncrement++;

                if (fullTemplate.IndexOf(Templates.Increment, StringComparison.Ordinal) < 0)
                    fullTemplate = fullTemplate.Insert(fullTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");
                if (thumbTemplate.IndexOf(Templates.Increment, StringComparison.Ordinal) < 0)
                    thumbTemplate = thumbTemplate.Insert(thumbTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");

                fullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
                thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());
            }

            return new ImagePairNames(fullSize, thumbnail);
        }
    }
}