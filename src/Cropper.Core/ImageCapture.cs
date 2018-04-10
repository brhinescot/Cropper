#region Using Directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     Represents a class for managing the capturing and saving of screenshots.
    /// </summary>
    public class ImageCapture : Component, IPersistableOutput
    {
        /// <summary>
        ///     Gets a value indicating if a plugin will continue capturing screeshots.
        /// </summary>
        public bool ContinueCapturing { get; private set; }
        
        /// <summary>
        ///     Retrieves another cropped image once a capture has been initialized.
        /// </summary>
        /// <param name="imageHandler">
        ///     An <see cref="ImageHandler" /> delegate containing the
        ///     method to call once the image is retrieved.
        /// </param>
        void IPersistableOutput.FetchCapture(ImageHandler imageHandler)
        {
            using (Image image = NativeMethods.GetDesktopBitmap(captureRectangle))
            {
                imageHandler(image);
            }
        }

        /// <summary>
        ///     Retrieves a stream for saving an image.
        /// </summary>
        /// <param name="streamHandler">
        ///     A <see cref="StreamHandler" />Delegate containg the method to call
        ///     when the stream is retrieved and the image to pass to the callback.
        /// </param>
        /// <param name="fileName">The image's file name.</param>
        /// <param name="image">The image to return to the callback method.</param>
        public void FetchOutputStream(StreamHandler streamHandler, string fileName, Image image)
        {
            if (streamHandler == null)
                throw new ArgumentNullException(nameof(streamHandler));

            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (FileStream stream = File.Open(fileName, FileMode.Create))
            {
                streamHandler(stream, image);
            }
        }

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }

        private static Image CreateThumbnailImage(Image image, double maxSize)
        {
            if (maxSize < 0 || maxSize > int.MaxValue)
                throw new ArgumentOutOfRangeException(
                    nameof(maxSize),
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

        #region Member Fields

        private IPersistableImageFormat imageFormat;
        private Rectangle captureRectangle;
        private readonly FileNameTemplate template = new FileNameTemplate();

        private static ImageOutputCollection imageOutputCollection;

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private Container components;

        #endregion

        #region Property Accessors

        /// <summary>
        ///     The <see cref="IPersistableImageFormat" />object to use when saving an image.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPersistableImageFormat ImageFormat
        {
            get => imageFormat;
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
        ///     A collection of loaded image output plugins.
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
                    if (plugin?.Settings != null)
                    {
                        object settings = Configuration.Current.RetrieveSettingsForPlugin(plugin.Settings.GetType());
                        if (settings != null)
                            plugin.Settings = settings;
                    }
                }
            }
        }

        /// <summary>
        ///     Last image captured
        /// </summary>
        public string LastImageCaptured { get; private set; }

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

        #region Capture Overloads

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(Rectangle captureArea)
        {
            Capture(captureArea.Location, captureArea.Size);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(Point location, Size size)
        {
            Capture(location.X, location.Y, size.Width, size.Height);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(int x, int y, int width, int height)
        {
            Capture(x, y, width, height, 0.0);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <param name="captureArea"></param>
        /// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(Rectangle captureArea, double maxThumbnailSize, bool saveFullImage)
        {
            Capture(captureArea.X, captureArea.Y, captureArea.Width, captureArea.Height, maxThumbnailSize, saveFullImage);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="size"></param>
        /// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(Point location, Size size, double maxThumbnailSize)
        {
            Capture(location.X, location.Y, size.Width, size.Height, maxThumbnailSize);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="maxThumbnailSize">A double representing the maximum thumbnail size.</param>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void Capture(int x, int y, int width, int height, double maxThumbnailSize, bool saveFullImage = true)
        {
            if (ImageFormat == null)
                throw new InvalidOperationException(SR.ExceptionImageFormatNull);

            captureRectangle = new Rectangle(x, y, width, height);
            OnImageCapturing(new ImageCapturingEventArgs());
            using (Image image = NativeMethods.GetDesktopBitmap(x, y, width, height))
            {
                ImageCapturedEventArgs imageCapturedEventArgs = ProcessCapturedImage(image, maxThumbnailSize, saveFullImage);
                OnImageCaptured(imageCapturedEventArgs);
                ContinueCapturing = imageCapturedEventArgs.ContinueCapturing;
            }
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void CaptureDesktop()
        {
            if (ImageFormat == null)
                throw new InvalidOperationException(SR.ExceptionImageFormatNull);
            CaptureByHdc(NativeMethods.FindWindow(null, "Program Manager"), false);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void CaptureForegroundForm()
        {
            if (ImageFormat == null)
                throw new InvalidOperationException(SR.ExceptionImageFormatNull);
            CaptureByHdc(NativeMethods.GetForegroundWindow(), Configuration.Current.ColorNonFormArea);
        }

        /// <summary>
        ///     Captures a screenshot and raises events that notify the loaded plugin.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the <see cref="ImageFormat" />
        ///     has not been properly set.
        /// </exception>
        public void CaptureWindowAtPoint(Point windowLocation)
        {
            if (ImageFormat == null)
                throw new InvalidOperationException(SR.ExceptionImageFormatNull);
            CaptureByHdc(NativeMethods.WindowFromPoint((NativeMethods.POINT) windowLocation), Configuration.Current.ColorNonFormArea);
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

        private ImageCapturedEventArgs ProcessCapturedImage(Image image, double maxThumbnailSize, bool saveFullImage = true)
        {
            ImageCapturedEventArgs imageCapturedEventArgs = new ImageCapturedEventArgs
            {
                ImageNames = template.Parse(ImageFormat.Extension),
                FullSizeImage = image,
                IsThumbnailed = maxThumbnailSize > 0.0,
                SaveFullImage = saveFullImage
                
            };
            if (imageCapturedEventArgs.IsThumbnailed)
                imageCapturedEventArgs.ThumbnailImage = CreateThumbnailImage(image, maxThumbnailSize);
            LastImageCaptured = imageCapturedEventArgs.ImageNames.FullSize;
            return imageCapturedEventArgs;
        }

        #endregion

        #region Event Declarations

        public event ImageCapturingEventHandler ImageCapturing;
        public event ImageCapturedEventHandler ImageCaptured;
        public event ImageCaptureInitializedEventHandler ImageCaptureInitialized;

        #endregion

        #region Events

        protected void OnImageCaptureInitialized(ImageCaptureInitializedEventArgs e)
        {
            ImageCaptureInitializedEventHandler handler = ImageCaptureInitialized;
            handler?.Invoke(this, e);
        }

        protected void OnImageCapturing(ImageCapturingEventArgs e)
        {
            ImageCapturingEventHandler handler = ImageCapturing;
            handler?.Invoke(this, e);
        }

        protected void OnImageCaptured(ImageCapturedEventArgs e)
        {
            ImageCapturedEventHandler handler = ImageCaptured;
            handler?.Invoke(this, e);
        }

        #endregion

        #region Internal Classes

        #endregion
    }
}