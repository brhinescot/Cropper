#region Using Directives

using System;
using System.Windows.Forms;
using Fusion8.Cropper.Core;

#endregion

namespace Fusion8.Cropper
{
    public class CropForm : LayeredForm
    {
        public event KeyEventHandler HotKeyPressed;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_HOTKEY)
            {
                Keys keyData = HotKeys.GetKeyData(m.WParam);
                if (keyData != Keys.None)
                {
                    KeyEventArgs args = new KeyEventArgs(keyData);
                    OnHotKeyPressed(args);
                }
            }

            base.WndProc(ref m);
        }

        protected virtual void OnHotKeyPressed(KeyEventArgs e)
        {
            KeyEventHandler handler = HotKeyPressed;
            if (handler != null && !e.Handled)
                handler(this, e);
        }
    }
}