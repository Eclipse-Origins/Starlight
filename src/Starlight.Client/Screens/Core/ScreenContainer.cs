using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Starlight.Client.Resources;
using Starlight.Network;
using System;
using System.Collections.Generic;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens.Core
{
    public class ScreenContainer
    {
        private readonly ResourceLocator resourceLocator;
        private readonly StarlightClient networkClient;
        private readonly Desktop desktop;

        private readonly Stack<IScreen> screenStack;

        GraphicsDevice graphicsDevice;

        public IScreen Screen { get; private set; }

        public bool HasActiveScreen => this.Screen != null;

        public ScreenContainer(ResourceLocator resourceLocator, StarlightClient networkClient, MyraUI.Desktop desktop)
        {
            this.resourceLocator = resourceLocator;
            this.networkClient = networkClient;
            this.desktop = desktop;

            this.screenStack = new Stack<IScreen>();
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;

            if (Screen != null)
            {
                Screen.PrepareResources(graphicsDevice);
            }
        }

        public TScreen PushScreen<TScreen>() where TScreen : IScreen
        {
            var screen = BuildScreen<TScreen>();

            this.screenStack.Push(screen);

            SetScreen(screen);

            return screen;
        }

        public void PopScreen()
        {
            if (this.screenStack.Count > 0)
            {
                screenStack.Pop();

                if (screenStack.TryPeek(out var screen))
                {
                    SetScreen(screen);
                }
            }
        }

        public TScreen ChangeScreen<TScreen>() where TScreen : IScreen
        {
            this.screenStack.Clear();

            return PushScreen<TScreen>();
        }

        private TScreen BuildScreen<TScreen>() where TScreen : IScreen
        {
            var screenContext = new ScreenContext(this, resourceLocator, networkClient);

            var screen = (TScreen)Activator.CreateInstance(typeof(TScreen), screenContext);

            screen.PrepareResources(graphicsDevice);
            screen.Layout();

            return screen;
        }

        private void SetScreen(IScreen screen)
        {
            desktop.Root = screen.RootUI;

            this.Screen = screen;
        }
    }
}
