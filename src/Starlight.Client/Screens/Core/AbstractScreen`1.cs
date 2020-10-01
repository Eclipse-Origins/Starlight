using Starlight.Client.UI;

namespace Starlight.Client.Screens.Core
{
    public class AbstractScreen<TControls> : AbstractScreen where TControls : new()
    {
        public TControls UI { get; }

        public AbstractScreen(ScreenContext screenContext) : base(screenContext)
        {
            this.UI = new TControls();
        }

        protected override void OnMarkupLoaded(StarlightGrid rootUI)
        {
            base.OnMarkupLoaded(rootUI);

            foreach (var property in UI.GetType().GetProperties())
            {
                var widget = rootUI.FindWidgetById(property.Name);

                if (widget != null)
                {
                    property.SetValue(UI, widget);
                }
            }
        }
    }
}
