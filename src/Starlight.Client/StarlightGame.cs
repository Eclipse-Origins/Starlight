﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra;
using Myra.Graphics2D.UI;
using Starlight.Client.Network;
using Starlight.Client.Rendering;
using Starlight.Client.Resources;
using Starlight.Client.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace Starlight.Client
{
    public class StarlightGame : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private readonly NetworkDispatch networkDispatch;
        private readonly Myra.Graphics2D.UI.Desktop desktop;

        public bool IsRunning { get; private set; }

        public ResourceLocator ResourceLocator { get; }
        public Rendering.RenderContext RenderContext { get; private set; }
        public Telepathy.Client NetworkClient { get; }

        public IScreen Screen { get; private set; }

        public StarlightGame(string workingDirectory) {
            this.graphics = new GraphicsDeviceManager(this);

            this.ResourceLocator = new ResourceLocator(workingDirectory);
            this.NetworkClient = new Telepathy.Client();

            this.networkDispatch = new NetworkDispatch();

            this.desktop = new Desktop();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Debugging.UIDebugging = false;
        }

        protected override void Initialize() {
            base.Initialize();

            ChangeScreen<SplashScreen>();
        }

        protected override void LoadContent() {
            base.LoadContent();

            var spriteBatch = new SpriteBatch(GraphicsDevice);
            RenderContext = new Rendering.RenderContext(GraphicsDevice, spriteBatch);

            MyraEnvironment.Game = this;
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
            if (RenderContext == null) {
                return;
            }

            GraphicsDevice.Clear(Color.Black);

            if (Screen != null) {
                RenderContext.SpriteBatch.Begin();
                Screen.RenderBackgroundFrame(RenderContext);
                RenderContext.SpriteBatch.End();

                desktop.Render();

                RenderContext.SpriteBatch.Begin();
                Screen.RenderForegroundFrame(RenderContext);
                RenderContext.SpriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public void ChangeScreen<TScreen>() where TScreen : IScreen {
            var screenContext = new ScreenContext(this, ResourceLocator);

            var screen = (IScreen)Activator.CreateInstance(typeof(TScreen), screenContext);

            screen.PrepareResources(GraphicsDevice);
            screen.Layout();

            desktop.Root = screen.RootUI;

            this.Screen = screen;
        }
    }
}
