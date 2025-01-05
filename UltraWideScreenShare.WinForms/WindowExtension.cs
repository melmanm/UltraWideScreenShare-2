using System.Reflection.Metadata;
using UltraWideScreenShare.WinForms.Properties;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace UltraWideScreenShare.WinForms
{
    public static class WindowExtension
    {
        const int WS_SIZEBOX = 0x40000;
        const int WS_MINIMIZEBOX = 0x20000;
        public static void InitializeMainWindowStyle(this Form window)
        {
            var hwnd = new HWND(window.Handle);
            var style = PInvoke.GetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_STYLE);
            PInvoke.SetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_STYLE, style |= WS_SIZEBOX | WS_MINIMIZEBOX);
        }


        const int WS_EX_LAYERED = 0x80000;
        const int WS_EX_TRANSPARENT = 0x20;
        public static void SetTransparency(this Form window, bool transparent)
        {
            var hwnd = new HWND(window.Handle);
            if (transparent)
            {
                var extendedStyle = PInvoke.GetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE);
                PInvoke.SetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            }
            else
            {
                var extendedStyle = PInvoke.GetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE);
                PInvoke.SetWindowLong(hwnd, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
            }
        }
        const uint WM_NCLBUTTONDOWN = 0xA1;
        const uint HT_CAPTION = 0x2;
        public static void Drag(this Form window)
        {
            PInvoke.ReleaseCapture();
            PInvoke.SendMessage(new HWND(window.Handle), WM_NCLBUTTONDOWN, new WPARAM(HT_CAPTION), new LPARAM());
        }


        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 16;
        const int HTBOTTOMRIGHT = 17;

        static Rectangle Top(int borderWidth, Form window) => new Rectangle(0, 0, window.ClientSize.Width, borderWidth);
        static Rectangle Left(int borderWidth, Form window) => new Rectangle(0, 0, borderWidth, window.ClientSize.Height);
        static Rectangle Bottom(int borderWidth, Form window) => new Rectangle(0, window.ClientSize.Height - borderWidth, window.ClientSize.Width, borderWidth);
        static Rectangle Right(int borderWidth, Form window) => new Rectangle(window.ClientSize.Width - borderWidth, 0, borderWidth, window.ClientSize.Height);
        static Rectangle TopLeft(int borderWidth, Form window) => new Rectangle(0, 0, borderWidth, borderWidth);
        static Rectangle TopRight(int borderWidth, Form window) => new Rectangle(window.ClientSize.Width - borderWidth, 0, borderWidth, borderWidth);
        static Rectangle BottomLeft(int borderWidth, Form window) => new Rectangle(0, window.ClientSize.Height - borderWidth, borderWidth, borderWidth);
        static Rectangle BottomRight(int borderWidth, Form window) => new Rectangle(window.ClientSize.Width - borderWidth, window.ClientSize.Height - borderWidth, borderWidth, borderWidth);

        public static void TryResize(this Form window, ref Message message, int borderWidth)
        {
            var cursor = window.PointToClient(Cursor.Position);

            if (TopLeft(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
            else if (TopRight(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
            else if (BottomLeft(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
            else if (BottomRight(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

            else if (Top(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTTOP;
            else if (Left(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTLEFT;
            else if (Right(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
            else if (Bottom(borderWidth, window).Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
        }

        public static void RestoreWindowPosition(this Form window)
        {
            if (Settings.Default.WindowsSettingsSaved)
            {
                window.WindowState = (FormWindowState)Settings.Default.WindowState;
                window.Location = Settings.Default.Location;
                window.Size = Settings.Default.Size;
            }
        }

        public static void SaveWindowPosition(this Form window)
        {
            Settings.Default.WindowState = (uint)window.WindowState;

            if (window.WindowState == FormWindowState.Normal)
            {
                Settings.Default.Location = window.Location;
                Settings.Default.Size = window.Size;
            }
            else
            {
                Settings.Default.Location = window.RestoreBounds.Location;
                Settings.Default.Size = window.RestoreBounds.Size;
            }

            Settings.Default.WindowsSettingsSaved = true;

            Settings.Default.Save();
        }
    }
}
