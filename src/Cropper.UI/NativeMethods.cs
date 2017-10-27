#region Using Directives

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;

#endregion

namespace Fusion8.Cropper
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class NativeMethods
    {
        internal const int WM_SETICON = 0x80;
        internal const int WM_SETTEXT = 0x000c;
        internal const int GW_OWNER = 4;
        internal const int ICON_SMALL = 0;
        internal const int ICON_BIG = 1;
        internal const int WS_EX_LAYERED = 0x80000;
        internal const int WM_HOTKEY = 0x0312;

        internal const int WS_MINIMIZEBOX = 0x20000;

        internal const int CS_DBLCLKS = 0x8;

        internal const byte AC_SRC_OVER = 0x00;
        internal const byte AC_SRC_ALPHA = 0x01;

        internal const int DESKTOPVERTRES = 117;
        internal const int DESKTOPHORZRES = 118;

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vic);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern ushort GlobalAddAtom(string lpString);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern ushort GlobalDeleteAtom(ushort nAtom);

//        [DllImport("user32.dll", EntryPoint = "BeginPaint", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
//        public static extern IntPtr BeginPaint(IntPtr hWnd, PAINTSTRUCT* lpPaint);
        
        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);
        
        [DllImport("gdi32.dll")]
        internal static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = false)]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr GetWindow(IntPtr hwnd, int cmd);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr hObject);

        internal static IntPtr GetTopLevelOwner(IntPtr hWnd)
        {
            IntPtr hwndOwner = hWnd;
            IntPtr hwndCurrent = hWnd;
            while (hwndCurrent != (IntPtr) 0)
            {
                hwndCurrent = GetWindow(hwndCurrent, GW_OWNER);
                if (hwndCurrent != (IntPtr) 0)
                    hwndOwner = hwndCurrent;
            }
            return hwndOwner;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
    }
}