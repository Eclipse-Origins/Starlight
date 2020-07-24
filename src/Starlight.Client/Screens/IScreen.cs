using Starlight.Client.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public interface IScreen
    {
        void PrepareResources(Renderer renderer);

        void Update();
        void RenderFrame(RenderContext renderContext);
    }
}
