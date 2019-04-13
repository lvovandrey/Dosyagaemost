using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DosyagWpf
{
    class CppLib
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [DllImport("DosyagDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SomeFunc([In]int a);
    }
}
