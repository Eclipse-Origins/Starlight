using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Starlight.Client.Resources;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens.Core
{
    public class ScreenContainer
    {
        private readonly ResourceLocator resourceLocator;
        private readonly StarlightClient networkClient;
        private readonly Desktop desktop;

        GraphicsDevice graphicsDevice;

        public IScreen Screen { get; private set; }

        public bool HasActiveScreen => this.Screen != null;

        public ScreenContainer(ResourceLocator resourceLocator, StarlightClient networkClient, MyraUI.Desktop desktop) {
            this.resourceLocator = resourceLocator;
            this.networkClient = networkClient;
            this.desktop = desktop;
        }

        public void LoadContent(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;

            if (Screen != null) {
                Screen.PrepareResources(graphicsDevice);
            }
        }

        public void ChangeScreen<TScreen>() where TScreen : IScreen {
            var screenContext = new ScreenContext(this, resourceLocator, networkClient);

            var screen = (IScreen)Activator.CreateInstance(typeof(TScreen), screenContext);

            screen.PrepareResources(graphicsDevice);
            screen.Layout();

            desktop.Root = screen.RootUI;

            this.Screen = screen;
        }
    }
}
