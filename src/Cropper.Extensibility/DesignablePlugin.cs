#region Using Directives

using System;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    /// Summary description for DesignablePlugin.
    /// </summary>
    public abstract class DesignablePlugin : IPersistableImageFormat
    {
        protected IPersistableOutput output;

        public event ImageFormatClickEventHandler ImageFormatClick;

        public virtual void Connect(IPersistableOutput persistableOutput)
        {
            if (persistableOutput == null)
                throw new ArgumentNullException("persistableOutput");

            output = persistableOutput;
            output.ImageCaptured += ImageCaptured;
        }

        public virtual void Disconnect()
        {
            output.ImageCaptured -= ImageCaptured;
        }

        protected abstract void ImageCaptured(object sender, ImageCapturedEventArgs e);
        public abstract string Extension { get; }
        public abstract string Description { get; }

        public virtual MenuItem Menu
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

        protected virtual void MenuClick(object sender, EventArgs e)
        {
            ImageFormatEventArgs formatEvents = new ImageFormatEventArgs();
            formatEvents.ClickedMenuItem = (MenuItem)sender;
            formatEvents.ImageOutputFormat = this;
            OnImageFormatClick(sender, formatEvents);
        }

        protected virtual void OnImageFormatClick(object sender, ImageFormatEventArgs e)
        {
            if (ImageFormatClick != null)
                ImageFormatClick(sender, e);
        }
    }
}