using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Text;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens
{
    public abstract class AbstractScreen : IScreen
    {
        public StarlightGrid RootUI { get; }
        public ScreenContext ScreenContext { get; }

        public AbstractScreen(ScreenContext screenContext) {
            this.ScreenContext = screenContext;

            this.RootUI = new StarlightGrid()
            {
                ShowGridLines = false
            };
        }

        public void Layout() {
            OnLayout(this.RootUI);
        }

        protected virtual void OnLayout(StarlightGrid rootUI) {
        }

        public virtual void PrepareResources(GraphicsDevice graphicsDevice) {
        }

        public virtual void Update(GameTime gameTime) {
        }

        public void RenderBackgroundFrame(RenderContext renderContext) {
            OnRenderBackgroundFrame(renderContext);
        }

        protected virtual void OnRenderBackgroundFrame(RenderContext renderContext) {
        }

        public void RenderForegroundFrame(RenderContext renderContext) {
            OnRenderForegroundFrame(renderContext);
        }

        protected virtual void OnRenderForegroundFrame(RenderContext renderContext) {
        }
    }
}
