#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

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
            this.lastIncrement = 1;
        }

		private static string GetThumbImageTemplate()
		{
			string thumbImageTemplate;
			if (Configuration.Current.ThumbImageTemplate != null && Configuration.Current.ThumbImageTemplate.Length > 0)
                thumbImageTemplate = Configuration.Current.ThumbImageTemplate;
			else
                thumbImageTemplate = DefaultThumbImageTemplate;
			return thumbImageTemplate;
		}

		private static string GetFullImageTemplate()
		{
			string fullImageTemplate;
			if (Configuration.Current.FullImageTemplate != null && Configuration.Current.FullImageTemplate.Length > 0)
				fullImageTemplate = Configuration.Current.FullImageTemplate;
			else
				fullImageTemplate = DefaultFullImageTemplate;
			return fullImageTemplate;
		}

		private static ImagePairNames TryAddTemplatePrompt(ImagePairNames startNames)
		{
			if (startNames.FullSize.IndexOf(Templates.Prompt) >= 0 || startNames.Thumbnail.IndexOf(Templates.Prompt) >= 0)
			{
				Prompt prompt = new Prompt();
				prompt.TopMost = true;
				prompt.StartPosition = FormStartPosition.CenterParent;
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
			var now = DateTime.Now;

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
			names.FullSize = String.Format("{0}.{1}", names.FullSize, fileExtension);
			names.Thumbnail = String.Format("{0}.{1}", names.Thumbnail, fileExtension);
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

				if (fullTemplate.IndexOf(Templates.Increment) < 0)
					fullTemplate = fullTemplate.Insert(fullTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");
				if (thumbTemplate.IndexOf(Templates.Increment) < 0)
					thumbTemplate = thumbTemplate.Insert(thumbTemplate.LastIndexOf('.'), " [" + Templates.Increment + "]");

				startNames.FullSize = fullTemplate.Replace(Templates.Increment, lastIncrement.ToString());
				startNames.Thumbnail = thumbTemplate.Replace(Templates.Increment, lastIncrement.ToString());
			}

			return startNames;
		}
	}
}
