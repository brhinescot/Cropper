#region Using Directives

using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    /// <summary>
    ///     Summary description for IPersistableImage.
    /// </summary>
    public interface IPersistableImageFormat
    {
        /// <summary>
        ///     Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        string Extension { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }

        /// <summary>
        ///     Gets the menu.
        /// </summary>
        /// <value>The menu.</value>
        MenuItem Menu { get; }

        /// <summary>
        /// </summary>
        event ImageFormatClickEventHandler ImageFormatClick;

        /// <summary>
        ///     Connects the specified persistable output.
        /// </summary>
        /// <param name="persistableOutput">The persistable output.</param>
        void Connect(IPersistableOutput persistableOutput);

        /// <summary>
        ///     Disconnects this instance.
        /// </summary>
        void Disconnect();
    }
}