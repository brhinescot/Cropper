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
        #region Member Variables

        private const string EXTENSION = "Exension";
        private const string DESCRIPTION = "My Format";

        //A referance to the host application.  Subscribe to its events to be notified 
        //when a capture has been started or completed
        private IPersistableOutput _output;

        #endregion

        #region Property Accessors

        //Allows an easy way for the host to obtain a referance to this plugin.
        //
        public IPersistableImageFormat Format
        {
            get { return this; }
        }

        //The extension is used when getting the next available file name and is 
        //the extension that the file stream is created with.
        //
        public string Extension
        {
            get { return EXTENSION; }
        }

        //The description is displayed on the crop form when your format is chosen.
        //Space may be limited when the form is sized small, so keep it short.
        //
        public string Description
        {
            get { return DESCRIPTION; }
        }

        //Create your outputs menu item here. You may add submenus to your output item if needed.
        //See the source code for the jpg format for an example.
        //
        public MenuItem Menu
        {
            get
            {
                MenuItem menuItem = new MenuItem();
                menuItem.RadioCheck = true;
                menuItem.Text = EXTENSION;
                menuItem.Click += new EventHandler(menuItem_Click);
                return menuItem;
            }
        }

        #endregion

        #region .ctor

        public [OUTPUTFORMAT]()
        {}

        #endregion

        //The event that you fire when a user clicks your format in the output menu.  The host then loads 
        //your format as the active plugin.
        //
        public event ImageFormatClickEventHandler ImageFormatClick;

        //The method called by the host when your plugin is loaded.  You should subscribe to any events 
        // you need in this method.
        //
        public void Connect(IPersistableOutput persistableOutput)
        {
            if(persistableOutput == null)
                throw new ArgumentNullException("persistableOutput");

            _output = persistableOutput;
            _output.ImageCaptured += new ImageCapturedEventHandler(persistableOutput_ImageCaptured);
        }

        //The method that is called when your format is unloaded.  You should unsubscribe from any events
        //you subscribed to in the Connect method.
        //
        public void Disconnect()
        {
            _output.ImageCaptured -= new ImageCapturedEventHandler(persistableOutput_ImageCaptured);
        }

        #region Event Handling

        //A sample event handler that retrieves a stream for the full and thumbnailed images using the
        //stream handler delegate.  Using the delegate causes the host to manage the stream and its cleanup,
        //freeing the plugin from that responsibility.
        //
        private void persistableOutput_ImageCaptured(object sender, ImageCapturedEventArgs e)
        {
            _output.FetchOutputStream(new StreamHandler(SaveImage), e.ImageNames.FullSize, e.FullSizeImage);
            if(e.IsThumbnailed)
                _output.FetchOutputStream(new StreamHandler(SaveImage), e.ImageNames.Thumbnail, e.ThumbnailImage);

            //If you need to manage the image retrieval yourself, such as adding multiple images to a stream
            //or building an animated gif for instance, you can use the ImageHandler delegate and pass it 
            //a callback that takes an image as its only parameter.  See the sample avi plugin source
            //for more.
            //
            //_output.FetchCapture(new ImageHandler(AddImageToAvi));
        }

        //A sample event handler for your menuitem click.  Create a new ImageFormatEventArgs and then
        //fire the ImageFormatClick event.  The host will respond by loading your plugin.
        //
        private void menuItem_Click(object sender, EventArgs e)
        {
            ImageFormatEventArgs formatEvents = new ImageFormatEventArgs();
            formatEvents.ClickedMenuItem = (MenuItem) sender;
            formatEvents.ImageOutputFormat = this;
            ImageFormatClick(sender, formatEvents);
        }

        #endregion

        //A sample call back method for saving the captured image.  This is passed to the 
        //StreamHandler delegate in persistableOutput_ImageCaptured method above.
        //
        private void SaveImage(Stream stream, Image image)
        {
            image.Save(stream, ImageFormat.Bmp);
            image.Dispose();
        }
    }
}