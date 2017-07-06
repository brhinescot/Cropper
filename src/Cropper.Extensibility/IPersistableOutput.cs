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