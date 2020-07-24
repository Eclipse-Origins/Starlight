using Starlight.Client.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public abstract class AbstractScreen : IScreen
    {
        public ScreenContext ScreenContext { get; }

        public AbstractScreen(ScreenContext screenContext) {
            this.ScreenContext = screenContext;
        }

        public virtual void PrepareResources(Renderer renderer) {
        }

        public virtual void Update() {
        }

        public virtual void RenderFrame(RenderContext renderContext) {
        }
    }
}
