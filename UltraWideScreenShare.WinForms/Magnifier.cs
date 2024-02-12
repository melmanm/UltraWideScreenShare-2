﻿using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using System.Runtime.InteropServices;
using UltraWideScreenShare.WinForms.Marshalling;
using Windows.Win32.UI.Magnification;

namespace UltraWideScreenShare.WinForms
{
    public class Magnifier
    {
        private HWND _magnifierWindowHandle;
        private HWND _hostWindowHandle;
        public Magnifier(IntPtr hostWindowHandle)
        {
            _hostWindowHandle = new HWND(hostWindowHandle);
            _magnifierWindowHandle = CreateMagnifierWindow(_hostWindowHandle);
        }
        unsafe private HWND CreateMagnifierWindow(HWND hostWindowHandle)
        {
            PInvoke.MagInitialize();

            PInvoke.SetLayeredWindowAttributes(hostWindowHandle, new COLORREF(0), 255, LAYERED_WINDOW_ATTRIBUTES_FLAGS.LWA_ALPHA);
            
            PInvoke.SetWindowsHookEx(WINDOWS_HOOK_ID.WH_MSGFILTER, FilterMessage, new HINSTANCE(hostWindowHandle.Value), 0);

            var window = PInvoke.CreateWindowEx(
                0, 
                "Magnifier", "MagnifierWindow",
                WINDOW_STYLE.WS_CHILD | WINDOW_STYLE.WS_VISIBLE,
                0, 0,
                0, 0,
                hostWindowHandle, null, null, null);

            return window;
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
            //var transformation = new TRANSFORMATION(1);
            //WinApiMethods.MagSetWindowTransform(_magnifierWindowHandle, ref transformation);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
        }

        public void ShowMagnifier()
        {
            PInvoke.ShowWindow(_magnifierWindowHandle, SHOW_WINDOW_CMD.SW_RESTORE);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
        }

        public void HideMagnifier()
        {
            PInvoke.ShowWindow(_magnifierWindowHandle, SHOW_WINDOW_CMD.SW_HIDE);
            PInvoke.InvalidateRect(_magnifierWindowHandle, (RECT?)null, new BOOL(1));
        }

        public unsafe double CalculateMonitorRatio()
        {
            var monitor = PInvoke.MonitorFromWindow(_magnifierWindowHandle, MONITOR_FROM_FLAGS.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFOEX monitorInfoEx = new MONITORINFOEX();

            WinApiMethods.GetMonitorInfo(monitor, monitorInfoEx);
            var horizontalRatioLogical = (monitorInfoEx.rcMonitor.right - monitorInfoEx.rcMonitor.left);
            //var verticalRatioLogical = (monitorInfoEx.rcMonitor.bottom - monitorInfoEx.rcMonitor.top);

            DEVMODEW devmodev = new DEVMODEW();
            if (PInvoke.EnumDisplaySettings(monitorInfoEx.szDeviceNameString(), ENUM_DISPLAY_SETTINGS_MODE.ENUM_CURRENT_SETTINGS, ref devmodev).Value == 1)
            {
                var horizontalRatioPhysical = devmodev.dmPelsWidth;
                var verticalRatioPhysical = devmodev.dmPelsHeight;

                return ((double)horizontalRatioPhysical / (double)horizontalRatioLogical);
                //_verticalRatio = ((double)verticalRatioPhysical / (double)verticalRatioLogical);
            }

            return 1;
        }

        unsafe private RECT GetMagnificationAreaRECT()
        {
            PInvoke.GetWindowRect(_hostWindowHandle, out RECT windowRect);
            PInvoke.GetClientRect(_hostWindowHandle, out RECT clientRect);

            return new RECT(new Point((int)(windowRect.left), (int)(windowRect.top)), 
                new Size((int)(clientRect.Width), (int)(clientRect.Height)));
        }


    }
}