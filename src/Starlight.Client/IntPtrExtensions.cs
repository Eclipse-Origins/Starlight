using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Starlight.Client
{
    public static class IntPtrExtensions
    {
        public static T AsStruct<T>(this IntPtr pointer) {
            return (T)Marshal.PtrToStructure(pointer, typeof(T));
        }
    }
}
