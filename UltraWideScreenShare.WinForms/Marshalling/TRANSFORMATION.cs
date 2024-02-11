using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UltraWideScreenShare.WinForms.Marshalling
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSFORMATION
    {
        public float m00;
        public float m10;
        public float m20;
        public float m01;
        public float m11;
        public float m21;
        public float m02;
        public float m12;
        public float m22;

        public TRANSFORMATION(float magnificationFactor)
            : this()
        {
            m00 = magnificationFactor;
            m11 = magnificationFactor;
            m22 = 1.0f;
        }
    }
}
