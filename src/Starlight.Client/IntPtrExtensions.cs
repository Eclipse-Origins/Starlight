using System;
using System.Runtime.InteropServices;

namespace Starlight.Client
{
    public static class IntPtrExtensions
    {
        public static T AsStruct<T>(this IntPtr pointer)
        {
            return (T)Marshal.PtrToStructure(pointer, typeof(T));
        }
    }
}
