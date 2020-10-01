using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI.Styles;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using Starlight.Translations;
using System.Linq;
using System.Xml.Linq;
using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens.Core
{
    public abstract class AbstractScreen : IScreen
    {
        public StarlightGrid RootUI { get; }
        public ScreenContext Context { get; }

        public string ScreenName => this.GetType().Name;

        public AbstractScreen(ScreenContext screenContext)
        {
            this.Context = screenContext;

            this.RootUI = new StarlightGrid();
        }

        public void Layout()
        {
            InitializeFromMarkup(this.RootUI);

            foreach (var container in this.RootUI.Widgets.OfType<MyraUI.MultipleItemsContainerBase>())
            {
                VisitUIChildren(container);
            }

            OnLayout(this.RootUI);
        }

        private void VisitUIChildren(MyraUI.MultipleItemsContainerBase container)
        {
            ApplyWidgetProperties(container);

            foreach (var child in container.Widgets)
            {
                if (child is MyraUI.MultipleItemsContainerBase childContainer)
                {
                    VisitUIChildren(childContainer);
                }
                else
                {
                    ApplyWidgetProperties(child);
                }
            }
        }

        private void ApplyWidgetProperties(MyraUI.Widget widget)
        {
            if (widget is MyraUI.Grid grid)
            {
                grid.ShowGridLines = Debugging.UIDebugging;
            }
            if (widget is MyraUI.TextButton textButton)
            {
                if (TranslationManager.Instance.TryTranslate($"{ScreenName}.{textButton.Id}", out var value))
                {
                    textButton.Text = value;
                }
            }
            if (widget is MyraUI.Label label)
            {
                if (TranslationManager.Instance.TryTranslate($"{ScreenName}.{label.Id}", out var value))
                {
                    label.Text = value;
                }
            }
        }

        protected virtual void OnLayout(StarlightGrid rootUI)
        {
        }

        public virtual void PrepareResources(GraphicsDevice graphicsDevice)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public void RenderBackgroundFrame(RenderContext renderContext)
        {
            OnRenderBackgroundFrame(renderContext);
        }

        protected virtual void OnRenderBackgroundFrame(RenderContext renderContext)
        {
        }

        public void RenderForegroundFrame(RenderContext renderContext)
        {
            OnRenderForegroundFrame(renderContext);
        }

        protected virtual void OnRenderForegroundFrame(RenderContext renderContext)
        {
        }

        private void InitializeFromMarkup(StarlightGrid rootUI)
        {
            var resourceStream = typeof(AbstractScreen).Assembly.GetManifestResourceStream($"Starlight.Client.Screens.{ScreenName}.xml");
            if (resourceStream != null)
            {
                using (resourceStream)
                {
                    var document = XDocument.Load(resourceStream);

                    var project = MyraUI.Project.LoadFromXml(document, null, Stylesheet.Current);

                    rootUI.Widgets.Add(project.Root);

                    OnMarkupLoaded(rootUI);
                }
            }
        }

        protected virtual void OnMarkupLoaded(StarlightGrid rootUI)
        {
        }
    }
}
