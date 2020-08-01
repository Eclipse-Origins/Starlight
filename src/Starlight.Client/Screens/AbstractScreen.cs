using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public virtual void PrepareResources(GraphicsDevice graphicsDevice) {
        }

        public virtual void Update(GameTime gameTime) {
        }

        public virtual void RenderFrame(RenderContext renderContext) {
        }
    }
}
