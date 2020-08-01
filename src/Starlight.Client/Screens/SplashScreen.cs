using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
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

        public override void PrepareResources(GraphicsDevice graphicsDevice) {
            base.PrepareResources(graphicsDevice);

            surface = Texture2D.FromFile(graphicsDevice, ScreenContext.ResourceLocator.LocateAssetPath("graphics", "items", "1.png"));
        }

        public override void RenderFrame(RenderContext renderContext) {
            base.RenderFrame(renderContext);

            renderContext.SpriteBatch.Draw(surface, new Microsoft.Xna.Framework.Vector2(300, y), Color.White);
        }

        public override void RenderUIFrame(RenderContext renderContext) {
            base.RenderUIFrame(renderContext);

            ImGui.Text("Hello, world!");

            var testButton = ImGui.Button("Move it down", new System.Numerics.Vector2(200, 50));
            if (testButton) {
                y += 50;
            }
        }
    }
}
