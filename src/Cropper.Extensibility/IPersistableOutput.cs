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
using System.Drawing;
using System.IO;

#endregion

namespace Fusion8.Cropper.Extensibility
{
	/// <summary>
	/// Summary description for IPersistableOutput
	/// </summary>
	public interface IPersistableOutput
	{
		/// <summary>
		/// Occurs when a plug-in is loaded but before any screen captures take place.
		/// </summary>
		event ImageCaptureInitializedEventHandler ImageCaptureInitialized;

		/// <summary>
		/// Occurs when a screen capture has started but before the image is available.
		/// </summary>
		event ImageCapturingEventHandler ImageCapturing;

		/// <summary>
		/// Occurs once a screen capture is complete.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The full size image capture is available at this point as well 
        /// as the thumbnail if enabled.</para>
        /// <para>
        /// Information about the capture as well as the images is available via the 
        /// <see cref="ImageCapturedEventArgs"/> object.</para>
        /// </remarks>
		event ImageCapturedEventHandler ImageCaptured;

		/// <summary>
		/// Retrieves a stream for saving an image.
		/// </summary>
		/// <param name="streamHandler">A <see cref="StreamHandler"/>Delegate to the 
		/// method to call when the stream is retrieved and the image to pass to the callback.</param>
		/// <param name="fileName">The image's file name.</param>
		/// <param name="image">The image to return to the callback method.</param>
		void FetchOutputStream(StreamHandler streamHandler, string fileName, Image image);

		/// <summary>
		/// Retrieves another screen capture independant of user action.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method is useful if multiple captures need to be taken for an output types such 
		/// as animated gifs or video formats.</para>
		/// <para>
		/// The <paramref name="imageHandler"/> parameter will be called when the screen capture 
        /// completes and should perform the necessary steps to persist the image.</para>
        /// <para>
		/// Thumbnail images are not supported by this method.</para>
		/// </remarks>
		/// <param name="imageHandler">An <see cref="ImageHandler"/> delegate that accepts a single
		/// <see cref="Image"/> parameter.</param>
		void FetchCapture(ImageHandler imageHandler);
	}
}