using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
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

            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));

            var helloWorld = new Label
            {
                Id = "label",
                Text = "Hello, World!"
            };
            rootUI.Widgets.Add(helloWorld);

            var button = new TextButton
            {
                GridColumn = 0,
                GridRow = 1,
                Text = "Button",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            rootUI.Widgets.Add(button);

            var secondButton = new TextButton()
            {
                GridColumn = 1,
                GridRow = 0,
                Text = "Main Menu",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            rootUI.Widgets.Add(secondButton);

            secondButton.Click += SecondButton_Click;

            button.Click += Button_Click;
        }

        private void SecondButton_Click(object sender, EventArgs e) {
            ScreenContext.ChangeScreen<MainMenuScreen>();
        }

        private void Button_Click(object sender, EventArgs e) {
            y += 10;
        }

        public override void PrepareResources(GraphicsDevice graphicsDevice) {
            base.PrepareResources(graphicsDevice);

            surface = Texture2D.FromFile(graphicsDevice, ScreenContext.ResourceLocator.LocateAssetPath("graphics", "items", "1.png"));
        }

        protected override void OnRenderForegroundFrame(Rendering.RenderContext renderContext) {
            renderContext.SpriteBatch.Draw(surface, new Microsoft.Xna.Framework.Vector2(300, y), Color.White);
        }
    }
}
