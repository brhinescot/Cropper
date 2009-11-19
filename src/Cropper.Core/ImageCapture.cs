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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Fusion8.Cropper.Extensibility;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
	/// <summary>
	/// Represents a class for managing the capturing and saving of screenshots.
	/// </summary>
	public class ImageCapture : Component, IPersistableOutput
	{
		#region Member Fields

		private IPersistableImageFormat imageFormat;
		private Rectangle captureRectangle;
		private readonly FileNameTemplate template = new FileNameTemplate();
		private string lastImageCaptured;

		private static ImageOutputCollection imageOutputCollection;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components;

		#endregion

		#region Property Accessors

		/// <summary>
		/// The <see cref="IPersistableImageFormat"/>object to use when saving an image.
		/// </summary>
		[Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IPersistableImageFormat ImageFormat
		{
			get { return imageFormat; }
			set
			{
                if (imageFormat != null)
                {
                    imageFormat.Disconnect();
                    template.ResetIncrement();
                }
				imageFormat = value;
				if (imageFormat != null)
				{
					imageFormat.Connect(this);
					OnImageCaptureInitialized(new ImageCaptureInitializedEventArgs());
				}
			}
		}

		/// <summary>
		/// A collection of loaded image output plugins.
		/// </summary>
		public static ImageOutputCollection ImageOutputs
		{
			get
			{
				EnsureOutputsLoaded();
				return imageOutputCollection;
			}
		}

		private static void EnsureOutputsLoaded()
		{
			if (imageOutputCollection == null)
			{
				imageOutputCollection = Plugins.Load();
				foreach (IPersistableImageFormat format in imageOutputCollection)
				{
					IConfigurablePlugin plugin = format as IConfigurablePlugin;
					if (plugin != null && plugin.Settings != null)
					{
						object settings = Configuration.Current.RetrieveSettingsForPlugin(plugin.Settings.GetType());
						if (settings != null)
							plugin.Settings = settings;
					}
				}
			}
		}

		/// <summary>
		/// Last image captured
		/// </summary>
		public string LastImageCaptured
		{
			get { return lastImageCaptured; }
		}

		#endregion

		#region .ctors

		public ImageCapture(IContainer container)
			: this()
		{
			container.Add(this);
		}

		public ImageCapture()
		{
			InitializeComponent();
		}

		#endregion

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new Container();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Capture Overloads

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(Rectangle captureArea)
		{
			Capture(captureArea.Location, captureArea.Size);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(Point location, Size size)
		{
			Capture(location.X, location.Y, size.Width, size.Height);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(int x, int y, int width, int height)
		{
			Capture(x, y, width, height, 0.0);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <param name="captureArea"></param>
		/// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(Rectangle captureArea, double maxThumbnailSize)
		{
			Capture(captureArea.X, captureArea.Y, captureArea.Width, captureArea.Height, maxThumbnailSize);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <param name="location"></param>
		/// <param name="size"></param>
		/// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(Point location, Size size, double maxThumbnailSize)
		{
			Capture(location.X, location.Y, size.Width, size.Height, maxThumbnailSize);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void Capture(int x, int y, int width, int height, double maxThumbnailSize)
		{
			if (ImageFormat == null)
				throw new InvalidOperationException(SR.ExceptionImageFormatNull);

			captureRectangle = new Rectangle(x, y, width, height);
			OnImageCapturing(new ImageCapturingEventArgs());
			using (Image image = NativeMethods.GetDesktopBitmap(x, y, width, height))
			{
				ImageCapturedEventArgs imageCapturedEventArgs = ProcessCapturedImage(image, maxThumbnailSize);
				OnImageCaptured(imageCapturedEventArgs);
			}
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void CaptureDesktop()
		{
			if (ImageFormat == null)
				throw new InvalidOperationException(SR.ExceptionImageFormatNull);
			CaptureByHdc(NativeMethods.FindWindow(null, "Program Manager"), false);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void CaptureForegroundForm()
		{
			if (ImageFormat == null)
				throw new InvalidOperationException(SR.ExceptionImageFormatNull);
			CaptureByHdc(NativeMethods.GetForegroundWindow(), Configuration.Current.ColorNonFormArea);
		}

		/// <summary>
		/// Captures a screenshot and raises events that notify the loaded plugin.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the <see cref="ImageFormat"/> 
		/// has not been properly set.</exception>
		public void CaptureWindowAtPoint(Point windowLocation)
		{
			if (ImageFormat == null)
				throw new InvalidOperationException(SR.ExceptionImageFormatNull);
			CaptureByHdc(NativeMethods.WindowFromPoint((NativeMethods.POINT)windowLocation), Configuration.Current.ColorNonFormArea);
		}

		private void CaptureByHdc(IntPtr hdc, bool cropAndColor)
		{
			OnImageCapturing(new ImageCapturingEventArgs());
			using (Image image = NativeMethods.GetDesktopBitmap(hdc, cropAndColor, Color.FromArgb(Configuration.Current.NonFormAreaColorArgb)))
			{
				if (Configuration.Current.LeavePrintScreenOnClipboard)
					Clipboard.SetImage(image);

				ImageCapturedEventArgs imageCapturedEventArgs = ProcessCapturedImage(image, 0.0);
				OnImageCaptured(imageCapturedEventArgs);
			}
		}

		private ImageCapturedEventArgs ProcessCapturedImage(Image image, double maxThumbnailSize)
		{
			ImageCapturedEventArgs imageCapturedEventArgs = new ImageCapturedEventArgs();
			imageCapturedEventArgs.ImageNames = template.Parse(ImageFormat.Extension);
			imageCapturedEventArgs.FullSizeImage = image;
			imageCapturedEventArgs.IsThumbnailed = (maxThumbnailSize > 0.0);
			if (imageCapturedEventArgs.IsThumbnailed)
				imageCapturedEventArgs.ThumbnailImage = CreateThumbnailImage(image, maxThumbnailSize);
			lastImageCaptured = imageCapturedEventArgs.ImageNames.FullSize;
			return imageCapturedEventArgs;
		}

		#endregion

		/// <summary>
		/// Retrieves another cropped image once a capture has been initialized.
		/// </summary>
		/// <param name="imageHandler">An <see cref="ImageHandler"/> delegate containing the 
		/// method to call once the image is retrieved.</param>
		void IPersistableOutput.FetchCapture(ImageHandler imageHandler)
		{
			using (Image image = NativeMethods.GetDesktopBitmap(captureRectangle))
				imageHandler(image);
		}

		/// <summary>
		/// Retrieves a stream for saving an image.
		/// </summary>
		/// <param name="streamHandler">A <see cref="StreamHandler"/>Delegate containg the method to call 
		/// when the stream is retrieved and the image to pass to the callback.</param>
		/// <param name="fileName">The image's file name.</param>
		/// <param name="image">The image to return to the callback method.</param>
		public void FetchOutputStream(StreamHandler streamHandler, string fileName, Image image)
		{
			if (streamHandler == null)
				throw new ArgumentNullException("streamHandler");

			if (fileName == null)
				throw new ArgumentNullException("fileName");

			if (image == null)
				throw new ArgumentNullException("image");

			using (FileStream stream = File.Open(fileName, FileMode.Create))
				streamHandler(stream, image);
		}

		private static Image CreateThumbnailImage(Image image, double maxSize)
		{
			if (maxSize < 0 || maxSize > Int32.MaxValue)
				throw new ArgumentOutOfRangeException(
						"maxSize",
						maxSize,
						SR.ExeptionThumbnailSizeOutOfRange);

			double ratio;
			if (image.Height > image.Width)
				ratio = image.Height / maxSize;
			else
				ratio = image.Width / maxSize;

			int newWidth = Convert.ToInt32(image.Width / ratio);
			int newHeight = Convert.ToInt32(image.Height / ratio);

			IntPtr ip = new IntPtr();
			Image.GetThumbnailImageAbort imageAbort = AbortThumb;

			return image.GetThumbnailImage(newWidth, newHeight, imageAbort, ip);
		}

		//Never called in this version of GDI+, but needed.
		//
		private static bool AbortThumb()
		{
			return false;
		}

		#region Event Declarations

		public event ImageCapturingEventHandler ImageCapturing;
		public event ImageCapturedEventHandler ImageCaptured;
		public event ImageCaptureInitializedEventHandler ImageCaptureInitialized;

		#endregion

		#region Events

		protected void OnImageCaptureInitialized(ImageCaptureInitializedEventArgs e)
		{
			ImageCaptureInitializedEventHandler handler = ImageCaptureInitialized;
			if (handler != null)
				handler(this, e);
		}

		protected void OnImageCapturing(ImageCapturingEventArgs e)
		{
			ImageCapturingEventHandler handler = ImageCapturing;
			if (handler != null)
				handler(this, e);
		}

		protected void OnImageCaptured(ImageCapturedEventArgs e)
		{
			ImageCapturedEventHandler handler = ImageCaptured;
			if (handler != null)
				handler(this, e);
		}

		#endregion

		#region Internal Classes

		#endregion
	}
}
