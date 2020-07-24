using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public class RenderContext
    {
        public Renderer Renderer { get; private set; }

        public void UpdateRenderer(Renderer renderer) {
            this.Renderer = renderer;
        }
    }
}
