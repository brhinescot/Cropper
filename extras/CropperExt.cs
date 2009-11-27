#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Fusion8Design.Cropper.Extensibility;

#endregion

namespace [NAMESPACE]
{
    /// <summary>
    /// This is a sample class that you can use as a starting point for new Cropper plug-ins.
    /// </summary>
    public class [OUTPUTFORMAT] : IPersistableImageFormat
    {
        // A referance to the host application. Subscribe to its events to be notified
        // when a capture has been started or completed
        private IPersistableOutput output;

        // The event that you raise when a user clicks your format in the output menu.
        // The host then loads your format as the active plugin.
        public event ImageFormatClickEventHandler ImageFormatClick;

        // The extension is used when getting the next available file name and is
        // the extension that the file stream is created with.
        public string Extension
        {
            get { return "Exension"; }
        }

        // The description is displayed on the crop form when your format is chosen.
        // Space may be limited when the form is sized small, so keep it short.
        public string Description
        {
            get { return "My Format"; }
        }

        // Create your outputs menu item here. You may add submenus to your output item if needed.
        // See the source code for the jpg format for an example.
        public MenuItem Menu
        {
            get
            {
                MenuItem menuItem = new MenuItem();
                menuItem.RadioCheck = true;
                menuItem.Text = Description;
                menuItem.Click += MenuClick;
                return menuItem;
            }
        }

        // A sample event handler when your menu item is clicked. Create a new ImageFormatEventArgs
        // and then raise the ImageFormatClick event. The host will respond by loading your plugin.
        private void MenuClick(object sender, EventArgs e)
        {
            ImageFormatEventArgs formatEvents = new ImageFormatEventArgs();
            formatEvents.ClickedMenuItem = (MenuItem)sender;
            formatEvents.ImageOutputFormat = this;
            OnImageFormatClick(sender, formatEvents);
        }

        // Raises the ImageFormatClick event if there is a listener.
        private void OnImageFormatClick(object sender, ImageFormatEventArgs e)
        {
            if (ImageFormatClick != null)
                ImageFormatClick(sender, e);
        }

        // The method called by the host when your plugin is loaded. You should subscribe
        // to any events you need in this method.
        public void Connect(IPersistableOutput persistableOutput)
        {
            if(persistableOutput == null)
                throw new ArgumentNullException("persistableOutput");

            output = persistableOutput;
            output.ImageCaptured += ImageCaptured;
        }

        // The method that is called when your format is unloaded. You should unsubscribe
        // from any events you subscribed to in the Connect method.
        public void Disconnect()
        {
            output.ImageCaptured -= ImageCaptured;
        }

        // A sample event handler that retrieves a stream for the full and thumbnailed images using the
        // stream handler delegate. Using the delegate causes the host to manage the stream and its cleanup,
        // freeing the plugin from that responsibility.
        private void ImageCaptured(object sender, ImageCapturedEventArgs e)
        {
            output.FetchOutputStream(SaveImag), e.ImageNames.FullSize, e.FullSizeImage);

            if(e.IsThumbnailed)
            {
                output.FetchOutputStream(SaveImage, e.ImageNames.Thumbnail, e.ThumbnailImage);
            }

            // If you need to manage the image retrieval yourself, such as adding multiple images to a stream
            // or building an animated gif for instance, you can use the ImageHandler delegate and pass it
            // a callback that takes an image as its only parameter. See the avi plugin source in the
            // Cropper Plugin project.
        }

        // A sample call back method for saving the captured image. This is passed to the 
        // StreamHandler delegate in the ImageCaptured method above.
        private void SaveImage(Stream stream, Image image)
        {
            image.Save(stream, ImageFormat.Bmp);
        }
    }
}