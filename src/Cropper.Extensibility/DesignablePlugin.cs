#region Using Directives

using System;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Summary description for DesignablePlugin.
    /// </summary>
    public abstract class DesignablePlugin : IPersistableImageFormat
    {
        protected IPersistableOutput output;

        public event ImageFormatClickEventHandler ImageFormatClick;

        public virtual void Connect(IPersistableOutput persistableOutput)
        {
            output = persistableOutput ?? throw new ArgumentNullException(nameof(persistableOutput));
            output.ImageCaptured += ImageCaptured;
        }

        public virtual void Disconnect()
        {
            output.ImageCaptured -= ImageCaptured;
        }

        public abstract string Extension { get; }
        public abstract string Description { get; }

        public virtual MenuItem Menu
        {
            get
            {
                MenuItem menuItem = new MenuItem
                {
                    RadioCheck = true,
                    Text = Description
                };
                menuItem.Click += MenuClick;
                return menuItem;
            }
        }

        protected abstract void ImageCaptured(object sender, ImageCapturedEventArgs e);

        protected virtual void MenuClick(object sender, EventArgs e)
        {
            ImageFormatEventArgs formatEvents = new ImageFormatEventArgs
            {
                ClickedMenuItem = (MenuItem) sender,
                ImageOutputFormat = this
            };
            OnImageFormatClick(sender, formatEvents);
        }

        protected virtual void OnImageFormatClick(object sender, ImageFormatEventArgs e)
        {
            ImageFormatClickEventHandler handler = ImageFormatClick;
            handler?.Invoke(sender, e);
        }
    }
}