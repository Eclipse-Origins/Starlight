using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Network;
using Starlight.Client.Rendering;
using Starlight.Client.Resources;
using Starlight.Client.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client
{
    public class StarlightGame : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private readonly NetworkDispatch networkDispatch;

        public bool IsRunning { get; private set; }

        public ResourceLocator ResourceLocator { get; }
        public RenderContext RenderContext { get; private set; }
        public Telepathy.Client NetworkClient { get; }

        public IScreen Screen { get; private set; }

        public StarlightGame(string workingDirectory) {
            this.graphics = new GraphicsDeviceManager(this);

            this.ResourceLocator = new ResourceLocator(workingDirectory);
            this.NetworkClient = new Telepathy.Client();

            this.networkDispatch = new NetworkDispatch();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            base.Initialize();

            ChangeScreen<SplashScreen>();
        }

        protected override void LoadContent() {
            base.LoadContent();

            var spriteBatch = new SpriteBatch(GraphicsDevice);
            RenderContext = new RenderContext(GraphicsDevice, spriteBatch);
        }

        public void Connect() {
            NetworkClient.Connect("localhost", 1337);
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);

            while (NetworkClient.GetNextMessage(out var networkMessage)) {
                switch (networkMessage.eventType) {
                    case Telepathy.EventType.Connected:
                        Console.WriteLine("Connected");
                        break;
                    case Telepathy.EventType.Data:
                        networkDispatch.HandleData(networkMessage.connectionId, networkMessage.data);
                        break;
                    case Telepathy.EventType.Disconnected:
                        Console.WriteLine("Disconnected");
                        break;
                }
            }

            if (Screen != null) {
                Screen.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (RenderContext != null) {
                RenderContext.SpriteBatch.Begin();

                if (Screen != null) {
                    Screen.RenderFrame(RenderContext);
                }

                RenderContext.SpriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public void ChangeScreen<TScreen>() {
            var screenContext = new ScreenContext(ResourceLocator);

            var screen = (IScreen)Activator.CreateInstance(typeof(TScreen), screenContext);

            screen.PrepareResources(GraphicsDevice);

            this.Screen = screen;
        }
    }
}
