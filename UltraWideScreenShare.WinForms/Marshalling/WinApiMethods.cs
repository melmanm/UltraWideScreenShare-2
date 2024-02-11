using System.Runtime.InteropServices;
using Windows.Win32.Graphics.Gdi;
namespace UltraWideScreenShare.WinForms.Marshalling
{
    internal static class WinApiMethods
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(HMONITOR hmonitor, [In, Out] MONITORINFOEX info);
        
        [DllImport("Magnification.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagSetWindowTransform(IntPtr hwnd, ref TRANSFORMATION pTransform);
    }
}
