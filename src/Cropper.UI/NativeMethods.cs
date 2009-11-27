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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Fusion8.Cropper
{
	internal sealed class NativeMethods
	{
		private NativeMethods() {}

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		[return : MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vic);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		[return : MarshalAs(UnmanagedType.Bool)]
		internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		[DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Auto)]
		internal static extern ushort GlobalAddAtom(string lpString);

		[DllImport("kernel32.dll", SetLastError=true, ExactSpelling=true)]
		internal static extern ushort GlobalDeleteAtom(ushort nAtom);

		[DllImport("gdi32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		internal static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		[return : MarshalAs(UnmanagedType.Bool)]
		internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

		[DllImport("gdi32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=false)]
		internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
		
		[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=false)]
		internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

		[DllImport("user32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		internal static extern IntPtr GetWindow(IntPtr hwnd, int cmd);

		[DllImport("gdi32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		[return : MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeleteDC(IntPtr hdc);

		[DllImport("gdi32.dll", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		[return : MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeleteObject(IntPtr hObject);
        

		internal const Int32 WM_SETICON = 0x80;
		internal const Int32 WM_SETTEXT = 0x000c;
		internal const Int32 GW_OWNER = 4;
		internal const Int32 ICON_SMALL = 0;
		internal const Int32 ICON_BIG = 1;
		internal const Int32 WS_EX_LAYERED = 0x80000;
		internal const Int32 WM_HOTKEY = 0x0312;

		internal const Byte AC_SRC_OVER = 0x00;
		internal const Byte AC_SRC_ALPHA = 0x01;

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		internal struct BLENDFUNCTION
		{
			public byte BlendOp;
			public byte BlendFlags;
			public byte SourceConstantAlpha;
			public byte AlphaFormat;
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct POINT
		{
			public int X;
			public int Y;

			public POINT(int x, int y)
			{
				X = x;
				Y = y;
			}

			public static explicit operator POINT(Point pt)
			{
				return new POINT(pt.X, pt.Y);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct SIZE
		{
			public int Width;
			public int Height;

			public SIZE(int w, int h)
			{
				Width = w;
				Height = h;
			}
		}
		
		internal static IntPtr GetTopLevelOwner(IntPtr hWnd)
		{
			IntPtr hwndOwner = hWnd;
			IntPtr hwndCurrent = hWnd;
			while (hwndCurrent != (IntPtr) 0)
			{
				hwndCurrent = GetWindow(hwndCurrent, GW_OWNER);
				if (hwndCurrent != (IntPtr) 0)
				{
					hwndOwner = hwndCurrent;
				}
			}
			return hwndOwner;
		}
	}
}