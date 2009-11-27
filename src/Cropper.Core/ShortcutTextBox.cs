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
using System.Text;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    ///<summary>
    ///</summary>
    public class ShortcutTextBox : TextBox
    {
        #region Property Accessors

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
        
        public Keys KeyData
        {
            get { return KeyCode | Modifiers; }
            set { SetKeys(value); }
        }

        /// <summary>
        /// Gets the key code.
        /// </summary>
        /// <value>The key code.</value>
        public Keys KeyCode
        {
            get
            {
                IntPtr message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int keyCode = (message.ToInt32() & 0xff);

                return (Keys)keyCode;
            }
            set { SetKeys(value, Modifiers); }
        }

        /// <summary>
        /// Gets the modifiers.
        /// </summary>
        /// <value>The modifiers.</value>
        public Keys Modifiers
        {
            get
            {
                IntPtr message = NativeMethods.SendMessage(Handle, NativeMethods.HKM_GETHOTKEY, IntPtr.Zero, IntPtr.Zero);
                int flags = (message.ToInt32() >> 8);

                Keys modifiers = Keys.None;
                if ((flags & NativeMethods.HOTKEYF_ALT) == NativeMethods.HOTKEYF_ALT)
                    modifiers |= Keys.Alt;
                if ((flags & NativeMethods.HOTKEYF_CONTROL) == NativeMethods.HOTKEYF_CONTROL)
                    modifiers |= Keys.Control;
                if ((flags & NativeMethods.HOTKEYF_SHIFT) == NativeMethods.HOTKEYF_SHIFT)
                    modifiers |= Keys.Shift;
                return modifiers;
            }
            set { SetKeys(KeyCode, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating if the Alt key is displayed in 
        /// the <see cref="ShortcutTextBox"/> control.
        /// </summary>
        public bool Alt
        {
            get { return (Modifiers & Keys.Alt) == Keys.Alt; }
            set
            {
                if (value)
                    Modifiers |= Keys.Alt;
                else
                    Modifiers &= ~Keys.Alt;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the Shift key is displayed in 
        /// the <see cref="ShortcutTextBox"/> control.
        /// </summary>
        public bool Shift
        {
            get { return (Modifiers & Keys.Shift) == Keys.Shift; }
            set
            {
                if (value)
                    Modifiers |= Keys.Shift;
                else
                    Modifiers &= ~Keys.Shift;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the Control key is displayed in 
        /// the <see cref="ShortcutTextBox"/> control.
        /// </summary>
        public bool Control
        {
            get { return (Modifiers & Keys.Control) == Keys.Control; }
            set
            {
                if (value)
                    Modifiers |= Keys.Control;
                else
                    Modifiers &= ~Keys.Control;
            }
        }

        public bool HasShortcut
        {
            get { return KeyCode != Keys.None; }
        }

        /// <summary>
        /// Gets the current text in the <see cref="ShortcutTextBox"/>.
        /// </summary>
        /// <remarks>This property will throw an exception if the setter is called.</remarks>
        /// <value></value>
        /// <filterPriority>1</filterPriority>
        public override string Text
        {
            get
            {
                Keys modifiers = Modifiers;
                StringBuilder builder = new StringBuilder();

                builder.Append(KeyCode == Keys.None ? Keys.None.ToString() : RetrieveKeyName((uint)KeyCode));

                if ((modifiers & Keys.Alt) == Keys.Alt)
                    builder.Insert(0, RetrieveKeyName((uint)Keys.Menu) + " + ");
                if ((modifiers & Keys.Shift) == Keys.Shift)
                    builder.Insert(0, RetrieveKeyName((uint)Keys.ShiftKey) + " + ");
                if ((modifiers & Keys.Control) == Keys.Control)
                    builder.Insert(0, RetrieveKeyName((uint)Keys.ControlKey) + " + ");

                return builder.ToString();
            }
            set
            {
                try
                {
                    Keys keys = (Keys)Enum.Parse(typeof(Keys), value.Replace('+', ',').Replace("Ctrl", "Control"));
                    SetKeys(keys);
                }
                catch (ArgumentException)
                {
                    SetKeys(Keys.None);
                }
            }
        }

        #endregion

        #region .ctor

        public ShortcutTextBox()
        {
            SetInvalidKeys(Keys.Control, Keys.None, Keys.Shift);
        }

        #endregion

        public void SetInvalidKeys(Keys replacementModifiers, params Keys[] invalidModifiers)
        {
            int hotKeyF = 0;

            foreach (Keys keys in invalidModifiers)
            {
                switch (keys)
                {
                    case Keys.Alt:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_A;
                        break;
                    case Keys.Control:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_C;
                        break;
                    case Keys.Control | Keys.Alt:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_CA;
                        break;
                    case Keys.None:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_NONE;
                        break;
                    case Keys.Shift:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_S;
                        break;
                    case Keys.Shift | Keys.Alt:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_SA;
                        break;
                    case Keys.Shift | Keys.Control:
                        hotKeyF = (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_SC;
                        break;
                    case Keys.Shift | Keys.Control | Keys.Alt:
                        hotKeyF |= (int)NativeMethods.InvalidHotKeyModifiers.HKCOMB_SCA;
                        break;
                    default:
                        break;
                }
            }

            int replacement = 0;
            if ((replacementModifiers & Keys.Alt) == Keys.Alt)
                replacement |= NativeMethods.HOTKEYF_ALT;
            if ((replacementModifiers & Keys.Control) == Keys.Control)
                replacement |= NativeMethods.HOTKEYF_CONTROL;
            if ((replacementModifiers & Keys.Shift) == Keys.Shift)
                replacement |= NativeMethods.HOTKEYF_SHIFT;

            NativeMethods.SendMessage(Handle, NativeMethods.HKM_SETRULES, (IntPtr)hotKeyF, (IntPtr)replacement);
        }

        public void SetKeys(Keys keyCode, Keys modifiers)
        {
            SetKeys(keyCode | modifiers);
        }

        public void SetKeys(Keys keyData)
        {
            Keys keyCode = keyData & (~Keys.Alt & ~Keys.Control & ~Keys.Shift);

            int hotKeyF = 0;
            if ((keyData & Keys.Alt) == Keys.Alt)
                hotKeyF |= NativeMethods.HOTKEYF_ALT;
            if ((keyData & Keys.Control) == Keys.Control)
                hotKeyF |= NativeMethods.HOTKEYF_CONTROL;
            if ((keyData & Keys.Shift) == Keys.Shift)
                hotKeyF |= NativeMethods.HOTKEYF_SHIFT;

            NativeMethods.SendMessage(Handle, NativeMethods.HKM_SETHOTKEY, MakeHotKeyWParam((int)keyCode, hotKeyF), IntPtr.Zero);
        }

        #region Private Helpers

        private static IntPtr MakeHotKeyWParam(int keyCode, int modifiers)
        {
            return (IntPtr)((modifiers << 8) | (keyCode & 0xffff));
        }

        private static string RetrieveKeyName(uint keyCode)
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
                case Keys.Oem1:
                case Keys.Oem102:
                case Keys.Oem2:
                case Keys.Oem3:
                case Keys.Oem4:
                case Keys.Oem5:
                case Keys.Oem6:
                case Keys.Oem7:
                case Keys.Oem8:
                case Keys.OemClear:
                case Keys.Oemcomma:
                case Keys.OemMinus:
                case Keys.OemPeriod:
                case Keys.Oemplus:
                    scanCode += 0x100;
                    break;
            }

            StringBuilder buffer = new StringBuilder(260);
            NativeMethods.GetKeyNameText(scanCode << 16, buffer, buffer.Capacity);
            return buffer.ToString();
        }

        #endregion
    }
}