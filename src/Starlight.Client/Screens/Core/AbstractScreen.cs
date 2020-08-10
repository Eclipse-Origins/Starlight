using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI.Styles;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens.Core
{
    public abstract class AbstractScreen : IScreen
    {
        public StarlightGrid RootUI { get; }
        public ScreenContext Context { get; }

        public AbstractScreen(ScreenContext screenContext) {
            this.Context = screenContext;

            this.RootUI = new StarlightGrid();
        }

        public void Layout() {
            InitializeFromMarkup(this.RootUI);

            foreach (var grid in this.RootUI.Widgets.OfType<MyraUI.Grid>()) {
                ApplyProperties(grid);
            }

            OnLayout(this.RootUI);
        }

        private void ApplyProperties(MyraUI.Grid grid) {
            grid.ShowGridLines = Debugging.UIDebugging;

            foreach (var child in grid.Widgets.OfType<MyraUI.Grid>()) {
                ApplyProperties(child);
            }
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

        private void InitializeFromMarkup(StarlightGrid rootUI) {
            var screenName = this.GetType().Name;

            var resourceStream = typeof(AbstractScreen).Assembly.GetManifestResourceStream($"Starlight.Client.Screens.{screenName}.xml");
            if (resourceStream != null) {
                using (resourceStream) {
                    var document = XDocument.Load(resourceStream);

                    var project = MyraUI.Project.LoadFromXml(document, null, Stylesheet.Current);

                    rootUI.Widgets.Add(project.Root);

                    OnMarkupLoaded(rootUI);
                }
            }
        }

        protected virtual void OnMarkupLoaded(StarlightGrid rootUI) {
        }
    }
}
