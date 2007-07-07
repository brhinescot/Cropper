using System;
using System.Text;
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
                createParams.ClassName = NativeMethods.HOTKEY_CLASS;
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
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, 0, IntPtr.Zero);
                int keyCode = (message & 0xFF);
                return (Keys)keyCode;
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
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, 0, IntPtr.Zero);
                int keyCode = (message & 0xFF);
                int flags = (message >> 8);

                Keys keyData = (Keys)keyCode;
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
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, 0, IntPtr.Zero);
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

        /// <summary>
        /// Gets the current text in the <see cref="ShortcutTextBox"/>.
        /// </summary>
        /// <value></value>
        /// <filterPriority>1</filterPriority>
        public override string Text
        {
            get
            {
                int message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int keyCode = (message & 0xFF);
                int flags = (message >> 8);

                StringBuilder builder = new StringBuilder();
                builder.Append(GetKeyName((uint)keyCode));

                if ((flags & NativeMethods.HOTKEYF_ALT) == NativeMethods.HOTKEYF_ALT)
                    builder.Insert(0, GetKeyName((uint)Keys.Menu) + " + ");
                if ((flags & NativeMethods.HOTKEYF_SHIFT) == NativeMethods.HOTKEYF_SHIFT)
                    builder.Insert(0, GetKeyName((uint)Keys.ShiftKey) + " + ");
                if ((flags & NativeMethods.HOTKEYF_CONTROL) == NativeMethods.HOTKEYF_CONTROL)
                    builder.Insert(0, GetKeyName((uint)Keys.ControlKey) + " + ");

                return builder.ToString();
            }
            set { throw new NotImplementedException(); }
        }

        private static string GetKeyName(uint keyCode)
        {
            IntPtr hkl = NativeMethods.GetKeyboardLayout(0);
            uint scanCode = NativeMethods.MapVirtualKeyEx(keyCode, NativeMethods.MAPVK_VK_TO_VSC, hkl);

            switch ((Keys)keyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Insert:
                case Keys.Delete:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Home:
                case Keys.End:
                    scanCode += 0x100;
                    break;
            }

            StringBuilder buffer = new StringBuilder(260);
            NativeMethods.GetKeyNameText(scanCode << 16, buffer, buffer.Capacity);
            return buffer.ToString();
        }
    }
}