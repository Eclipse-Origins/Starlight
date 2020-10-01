using DarkUI.Forms;

namespace Starlight.Editors
{
    public class StarlightForm : DarkForm
    {
        public StarlightContext Context { get; }

        public StarlightForm()
        {
        }

        public StarlightForm(StarlightContext context)
        {
            this.Context = context;
        }
    }
}
