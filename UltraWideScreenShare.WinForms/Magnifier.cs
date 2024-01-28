using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Foundation;
using System.Drawing;
using System;

namespace UltraWideScreenShare.WinForms
{
    public class Magnifier
    {
        private HWND _hostWindowHandle;
        private HWND _magnifierWindowHandle;
        public bool IsVisible { get; private set; } = false;
        public Magnifier(IntPtr hostWindowHandle)
        {
            _hostWindowHandle = new HWND(hostWindowHandle);
            _magnifierWindowHandle = CreateMagnifierWindow(_hostWindowHandle);
        }
        unsafe private HWND CreateMagnifierWindow(HWND hostWindowHandle)
        {
            PInvoke.MagInitialize();

            //PInvoke.SetLayeredWindowAttributes(hostWindowHandle, new COLORREF(0), 255, LAYERED_WINDOW_ATTRIBUTES_FLAGS.LWA_ALPHA);
            
            PInvoke.SetWindowsHookEx(WINDOWS_HOOK_ID.WH_MSGFILTER, FilterMessage, new HINSTANCE(hostWindowHandle.Value), 0);

            var result = PInvoke.CreateWindowEx(
                0, 
                "Magnifier", "MagnifierWindow",
                WINDOW_STYLE.WS_CHILD | WINDOW_STYLE.WS_VISIBLE,
                0, 0,
                0, 0,
                hostWindowHandle, null, null, null);

            IsVisible = true;

            return result;
        }

        private LRESULT FilterMessage(int code, WPARAM wParam, LPARAM lParam)
        {

            return new LRESULT();
        }

        public void UpdateMagnifierWindow()
        {
            var magnificationArea = GetMagnificationAreaRECT();
            PInvoke.SetWindowPos(_magnifierWindowHandle, HWND.Null, 0, 0, magnificationArea.Width, magnificationArea.Height, 0);
            PInvoke.MagSetWindowSource(_magnifierWindowHandle, magnificationArea);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
        }

        public void Show()
        {
            PInvoke.ShowWindow(_magnifierWindowHandle, SHOW_WINDOW_CMD.SW_RESTORE);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
            IsVisible = true;
        }

        public void Hide()
        {
            PInvoke.ShowWindow(_magnifierWindowHandle, SHOW_WINDOW_CMD.SW_HIDE);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
            IsVisible = false;
        }

        private RECT GetMagnificationAreaRECT()
        {
            PInvoke.GetWindowRect(_hostWindowHandle, out RECT windowRect);
            PInvoke.GetClientRect(_hostWindowHandle, out RECT clientRect);

            var borderThickness = (windowRect.Width - clientRect.Width) / 2;
            var headerThickness = windowRect.Height - clientRect.Height - borderThickness;

            return new RECT(new Point(windowRect.left + borderThickness, windowRect.top + headerThickness), new Size(clientRect.Width, clientRect.Height));
        }


    }
}