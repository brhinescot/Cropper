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
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper
{
	public class CropForm : LayeredForm
	{
		public event KeyEventHandler HotKeyPress;

		#region Member Fields

		private ushort printScreenId;
		private ushort altPrintScreenId;
		private ushort altCtrlPrintScreenId;
		private ushort f12Id;
		private bool trapPrintScreen = true;
		private bool hotKeysRegistered;

		#endregion

		public bool TrapPrintScreen
		{
			get { return trapPrintScreen; }
			set
			{
				if(trapPrintScreen != value)
				{
					trapPrintScreen = value;
					if(trapPrintScreen && !hotKeysRegistered)
						RegisterHotKeys();
					else if(hotKeysRegistered)
						UnregisterHotKeys();
				}
			}
		}

		private void RegisterHotKeys()
		{
			printScreenId = NativeMethods.GlobalAddAtom("CropperPrintScreen" + DateTime.Now.Ticks);
			altPrintScreenId = NativeMethods.GlobalAddAtom("CropperAltPrintScreen" + DateTime.Now.Ticks);
			altCtrlPrintScreenId = NativeMethods.GlobalAddAtom("CropperAltCtrlPrintScreen" + DateTime.Now.Ticks);
            f12Id = NativeMethods.GlobalAddAtom("Cropperf12Id" + DateTime.Now.Ticks);

			NativeMethods.RegisterHotKey(Handle, printScreenId, 0, (int) Keys.PrintScreen);
			NativeMethods.RegisterHotKey(Handle, altPrintScreenId, 1, (int) Keys.PrintScreen);
            NativeMethods.RegisterHotKey(Handle, altCtrlPrintScreenId, 3, (int)Keys.PrintScreen);
            NativeMethods.RegisterHotKey(Handle, f12Id, 0, (int)Keys.F8);
			
			hotKeysRegistered = true;
		}
		
		private void UnregisterHotKeys() 
		{
			NativeMethods.GlobalDeleteAtom(printScreenId) ;
            NativeMethods.GlobalDeleteAtom(altPrintScreenId);
            NativeMethods.GlobalDeleteAtom(altCtrlPrintScreenId);
            NativeMethods.GlobalDeleteAtom(f12Id);

			NativeMethods.UnregisterHotKey(Handle, printScreenId);
            NativeMethods.UnregisterHotKey(Handle, altPrintScreenId);
            NativeMethods.UnregisterHotKey(Handle, altCtrlPrintScreenId);
            NativeMethods.UnregisterHotKey(Handle, f12Id);
			
			hotKeysRegistered = false;
		}
		
		protected CropForm()
		{
			if(trapPrintScreen)
				RegisterHotKeys();
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == NativeMethods.WM_HOTKEY)
			{
				if(m.WParam == (IntPtr)printScreenId)
				{
					KeyEventArgs args = new KeyEventArgs(Keys.PrintScreen);
					OnHotKeyPress(args);
				}
				else if(m.WParam == (IntPtr)altPrintScreenId)
				{
					KeyEventArgs args = new KeyEventArgs(Keys.PrintScreen | Keys.Alt);
					OnHotKeyPress(args);
				}
				else if(m.WParam == (IntPtr)altCtrlPrintScreenId)
				{
					KeyEventArgs args = new KeyEventArgs(Keys.PrintScreen | Keys.Alt | Keys.Control);
					OnHotKeyPress(args);
				}
                else if (m.WParam == (IntPtr)f12Id)
                {
                    KeyEventArgs args = new KeyEventArgs(Keys.F8);
                    OnHotKeyPress(args);
                }
				return;
			}
			
			base.WndProc(ref m);
		}
		
		protected virtual void OnHotKeyPress(KeyEventArgs e)
		{
			KeyEventHandler handler = HotKeyPress;
			if(handler != null && !e.Handled)
				HotKeyPress(this, e);
		}
		
		protected override void OnClosed(EventArgs e)
		{
			UnregisterHotKeys();
			base.OnClosed (e);
		}
	}
}