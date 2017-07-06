#region Using Directives

using System;
using System.IO;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
	/// <summary>
	/// Summary description for FileNameTemplate.
	/// </summary>
	public class FileNameTemplate
	{
		#region Member Fields

		private string fileExtension;
		private int lastIncrement = 1;

		public static readonly string DefaultFullImageTemplate = "CropperCapture[{increment}]";
		public static readonly string DefaultThumbImageTemplate = "CropperCapture[{increment}]Thumbnail";

		#endregion 
		
		/// <summary>
		/// 
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
			    
			    if (prompt.ShowDialog(Configuration.Current.ActiveCropWindow) == DialogResult.OK)
				{
					startNames.FullSize = startNames.FullSize.Replace(Templates.Prompt, prompt.Value);
					startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Prompt, prompt.Value);
				}
				else
				{
					startNames.FullSize = startNames.FullSize.Replace(Templates.Prompt, string.Empty);
					startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Prompt, String.Empty);
				}
			}
			return startNames;
		}

		private ImagePairNames TryAddTemplateExtension(ImagePairNames startNames)
		{
			startNames.FullSize = startNames.FullSize.Replace(Templates.Extension, fileExtension);
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Extension, fileExtension);
			return startNames;
		}

		private static ImagePairNames TryAddTemplateUser(ImagePairNames startNames)
		{
			startNames.FullSize = startNames.FullSize.Replace(Templates.User, Environment.UserName);
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.User, Environment.UserName);
			return startNames;
		}

		private static ImagePairNames TryAddTemplateDomain(ImagePairNames startNames)
		{
			startNames.FullSize = startNames.FullSize.Replace(Templates.Domain, Environment.UserDomainName);
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Domain, Environment.UserDomainName);
			return startNames;
		}

		private static ImagePairNames TryAddTemplateMachine(ImagePairNames startNames)
		{
			startNames.FullSize = startNames.FullSize.Replace(Templates.Machine, Environment.MachineName);
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Machine, Environment.MachineName);
			return startNames;
		}

		private static ImagePairNames TryAddTemplateDateOrTime(ImagePairNames startNames)
		{
			DateTime now = DateTime.Now;

			startNames.FullSize = startNames.FullSize.Replace(Templates.Date, now.ToString("MM-dd-yyyy"));
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Date, now.ToString("MM-dd-yyyy"));

			startNames.FullSize = startNames.FullSize.Replace(Templates.Time, now.ToString("hh-mm-ss tt"));
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Time, now.ToString("hh-mm-ss tt"));

			startNames.FullSize = startNames.FullSize.Replace(Templates.Timestamp, now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff"));
			startNames.Thumbnail = startNames.Thumbnail.Replace(Templates.Timestamp, now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff"));

			return startNames;
		}

		private ImagePairNames SetFileExtension(ImagePairNames names)
		{
			names.FullSize = $"{names.FullSize}.{fileExtension}";
			names.Thumbnail = $"{names.Thumbnail}.{fileExtension}";
			return names;
		}

		private static ImagePairNames SetFullPath(ImagePairNames names)
		{
			names.FullSize = Path.Combine(Configuration.Current.OutputPath, names.FullSize);
			names.Thumbnail = Path.Combine(Configuration.Current.OutputPath, names.Thumbnail);
			return names;
		}

		private ImagePairNames GetNextImagePairNames(ImagePairNames startNames)
		{
			if (!Directory.Exists(Path.GetDirectoryName(startNames.FullSize)))
				Directory.CreateDirectory(Path.GetDirectoryName(startNames.FullSize));

			if (!Directory.Exists(Path.GetDirectoryName(startNames.Thumbnail)))
				Directory.CreateDirectory(
					Path.GetDirectoryName(startNames.Thumbnail));

			string fullTemplate = startNames.FullSize;
			string thumbTemplate = startNames.Thumbnail;

			startNames.FullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
			startNames.Thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());

			if (!File.Exists(startNames.FullSize) && !File.Exists(startNames.Thumbnail))
			{
				ResetIncrement();
				startNames.FullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
				startNames.Thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());
			}

			while (File.Exists(startNames.FullSize) || File.Exists(startNames.Thumbnail))
			{
				lastIncrement++;

				if (fullTemplate.IndexOf(Templates.Increment, StringComparison.Ordinal) < 0)
					fullTemplate = fullTemplate.Insert(fullTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");
				if (thumbTemplate.IndexOf(Templates.Increment, StringComparison.Ordinal) < 0)
					thumbTemplate = thumbTemplate.Insert(thumbTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");

				startNames.FullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
				startNames.Thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());
			}

			return startNames;
		}
	}
}
