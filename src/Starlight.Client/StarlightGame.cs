﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Serilog;
using Starlight.Client.Network;
using Starlight.Client.Rendering;
using Starlight.Client.Resources;
using Starlight.Client.Screens;
using Starlight.Client.Screens.Core;
using Starlight.Client.State;
using Starlight.Network;
using Starlight.Translations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client
{
    public class StarlightGame : Game
    {
        private readonly GraphicsDeviceManager graphics;

        private readonly NetworkDispatch networkDispatch;
        private readonly MyraUI.Desktop desktop;

        public bool IsRunning { get; private set; }

        public ResourceCache ResourceCache { get; }
        public ResourceLocator ResourceLocator { get; }
        public RenderContext RenderContext { get; private set; }
        public StarlightClient NetworkClient { get; }

        public ScreenContainer ScreenContainer { get; }

        public string Server { get; private set; }
        public int Port { get; private set; }
        public string Language { get; set; }

        public StarlightGame(string workingDirectory) {
            this.graphics = new GraphicsDeviceManager(this);

            this.desktop = new MyraUI.Desktop();

            this.ResourceLocator = new ResourceLocator(workingDirectory);
            this.ResourceCache = new ResourceCache();
            this.NetworkClient = new StarlightClient(new Telepathy.Client());

            this.ScreenContainer = new ScreenContainer(this, ResourceCache, ResourceLocator, NetworkClient, desktop);

            this.networkDispatch = new NetworkDispatch(this.NetworkClient, this.ScreenContainer);
            this.networkDispatch.ResolveHandlers();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            base.Initialize();

            this.ScreenContainer.ChangeScreen<SplashScreen>();
        }

        protected override void LoadContent() {
            base.LoadContent();

            TranslationManager.Instance.ImportFromDocument(this.ResourceLocator.LocateContentPath("Languages", Language + ".json"));

            var spriteBatch = new SpriteBatch(GraphicsDevice);
            RenderContext = new RenderContext(GraphicsDevice, spriteBatch);
            this.ResourceCache.UpdateGraphcisDevice(GraphicsDevice);

            MyraEnvironment.Game = this;

            this.ScreenContainer.LoadContent(GraphicsDevice);
        }

        public void Connect() {
            Log.Debug("Connecting to " + Server + ":" + Port);
            NetworkClient.Client.Connect(Server,Port);
        }
        
        public void Connect(string address, int port) {
            this.Port = port;
            this.Server = address;
            this.Connect();
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);

            while (NetworkClient.Client.GetNextMessage(out var networkMessage)) {
                switch (networkMessage.eventType) {
                    case Telepathy.EventType.Connected:
                        Log.Verbose("Connected");
                        break;
                    case Telepathy.EventType.Data:
                        networkDispatch.HandleData(networkMessage.connectionId, networkMessage.data);
                        break;
                    case Telepathy.EventType.Disconnected:
                        Log.Verbose("Disconnected");
                        break;
                }
            }

            if (!NetworkClient.Client.Connected && !NetworkClient.Client.Connecting) {
                Connect();
            }

            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            var gameUpdateState = new GameUpdateState(gameTime, keyboardState, mouseState);

            if (ScreenContainer.HasActiveScreen) {
                ScreenContainer.Screen.Update(gameUpdateState);
            }
        }

        protected override void Draw(GameTime gameTime) {
            if (RenderContext == null) {
                return;
            }

            GraphicsDevice.Clear(Color.Black);

            if (ScreenContainer.HasActiveScreen) {
                RenderContext.SpriteBatch.Begin();
                ScreenContainer.Screen.RenderBackgroundFrame(RenderContext);
                RenderContext.SpriteBatch.End();

                desktop.Render();

                RenderContext.SpriteBatch.Begin();
                ScreenContainer.Screen.RenderForegroundFrame(RenderContext);
                RenderContext.SpriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
