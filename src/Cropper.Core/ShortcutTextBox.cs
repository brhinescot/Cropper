using System;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core
{
    ///<summary>
    ///</summary>
    public class ShortcutTextBox : TextBox
    {
        /// <summary>
        /// Encapsulates the information needed when creating a control.
        /// </summary>
        /// <value></value>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassName = "msctls_hotkey32";
                return createParams;
            }
        }

        /// <summary>
        /// Gets the key code.
        /// </summary>
        /// <value>The key code.</value>
        public Keys KeyCode
        {
            get
            {
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int keyCode = (message & 0xFF);
                return (Keys) keyCode;
            }
        }

        /// <summary>
        /// Gets the key data.
        /// </summary>
        /// <value>The key data.</value>
        public Keys KeyData
        {
            get
            {
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int keyCode = (message & 0xFF);
                int flags = (message >> 8);

                Keys keyData = (Keys) keyCode;
                if ((flags & NativeMethods.HOTKEYF_ALT) == NativeMethods.HOTKEYF_ALT)
                    keyData |= Keys.Alt | Keys.Menu;
                if ((flags & NativeMethods.HOTKEYF_CONTROL) == NativeMethods.HOTKEYF_CONTROL)
                    keyData |= Keys.Control | Keys.ControlKey;
                if ((flags & NativeMethods.HOTKEYF_SHIFT) == NativeMethods.HOTKEYF_SHIFT)
                    keyData |= Keys.Shift | Keys.ShiftKey;

                return keyData;
            }
        }

        /// <summary>
        /// Gets the modifiers.
        /// </summary>
        /// <value>The modifiers.</value>
        public Keys Modifiers
        {
            get
            {
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int flags = (message >> 8);

                Keys modifiers = Keys.None;
                if ((flags & NativeMethods.HOTKEYF_ALT) == NativeMethods.HOTKEYF_ALT)
                    modifiers |= Keys.Alt;
                if ((flags & NativeMethods.HOTKEYF_CONTROL) == NativeMethods.HOTKEYF_CONTROL)
                    modifiers |= Keys.Control;
                if ((flags & NativeMethods.HOTKEYF_SHIFT) == NativeMethods.HOTKEYF_SHIFT)
                    modifiers |= Keys.Shift;
                return modifiers;
            }
        }

        public override string Text
        {
            get
            {
                Keys modifiers = Modifiers;
                string text = null;
                if ((modifiers & Keys.Shift) == Keys.Shift)
                    text += "Shift + ";
                if ((modifiers & Keys.Control) == Keys.Control)
                    text += "Ctrl + ";
                if ((modifiers & Keys.Alt) == Keys.Alt)
                    text += "Alt + ";

                text += KeyCode;
                return text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}