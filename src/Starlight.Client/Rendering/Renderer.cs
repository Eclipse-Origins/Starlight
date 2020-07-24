using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public class Renderer
    {
        public IntPtr Handle { get; }

        public Renderer(IntPtr handle) {
            this.Handle = handle;
        }
    }
}
