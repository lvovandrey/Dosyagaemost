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
        const string dll = "DosyagDll64.dll";

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double Dosyagaemost([In]int FDtype, [In]int OUtype, [In]bool Spec, [In]double x, [In]double y, [In]double z);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double alpha([In]double x, [In]double y, [In]double z);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double dist([In]double x, [In]double y, [In]double z);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double h([In]double x, [In]double y, [In]double z);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double x([In]double alpha, [In]double dist, [In]double height);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double y([In]double alpha, [In]double dist, [In]double height);

        [return: MarshalAs(UnmanagedType.R8)]
        [DllImport(dll, CallingConvention = CallingConvention.Cdecl)]
        public static extern double z([In]double alpha, [In]double dist, [In]double height);

    }
}
