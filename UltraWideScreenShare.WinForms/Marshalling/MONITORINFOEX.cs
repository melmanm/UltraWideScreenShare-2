
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.Foundation;
using System.Runtime.InteropServices;
using System;

namespace UltraWideScreenShare.WinForms.Marshalling
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
    internal class MONITORINFOEX
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFOEX));
        public RECT rcMonitor = new RECT();
        public RECT rcWork = new RECT();
        public int dwFlags = 0;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] szDevice = new char[32];

        public string szDeviceNameString()
        {
            int lastIndex = Array.FindLastIndex(szDevice, b => b != 0);

            Array.Resize(ref szDevice, lastIndex + 1);

            return new string(szDevice);
        }
    }
}
