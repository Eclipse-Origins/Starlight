using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class SplashScreen : AbstractScreen
    {
        Texture2D surface;

        int y = 0;

        public SplashScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            base.OnLayout(rootUI);

            var mainMenuButton = (TextButton)rootUI.FindWidgetById("mainMenuButton");
            mainMenuButton.Click += MainMenuButton_Click;
        }

        private void MainMenuButton_Click(object sender, EventArgs e) {
            Context.ScreenContainer.ChangeScreen<MainMenuScreen>();
        }

        public override void PrepareResources(GraphicsDevice graphicsDevice) {
            base.PrepareResources(graphicsDevice);

            surface = Texture2D.FromFile(graphicsDevice, Context.ResourceLocator.LocateAssetPath("graphics", "items", "1.png"));
        }

        protected override void OnRenderForegroundFrame(Rendering.RenderContext renderContext) {
            renderContext.SpriteBatch.Draw(surface, new Microsoft.Xna.Framework.Vector2(300, y), Color.White);
        }
    }
}
