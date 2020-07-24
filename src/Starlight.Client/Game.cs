using Microsoft.VisualBasic;
using Starlight.Client.Network;
using Starlight.Client.Rendering;
using Starlight.Client.Resources;
using Starlight.Client.Screens;
using System;
using System.Collections.Generic;
using System.Text;

using static SDL2.SDL;
using static SDL2.SDL_image;

namespace Starlight.Client
{
    public class Game
    {
        private static int ImageFlags = (int)(IMG_InitFlags.IMG_INIT_PNG | IMG_InitFlags.IMG_INIT_JPG);

        private readonly NetworkDispatch networkDispatch;

        public bool IsRunning { get; private set; }

        public ResourceLocator ResourceLocator { get; }
        public RenderContext RenderContext { get; }
        public Telepathy.Client NetworkClient { get; }

        public IScreen Screen { get; private set; }

        public Game(string workingDirectory) {
            this.ResourceLocator = new ResourceLocator(workingDirectory);
            this.RenderContext = new RenderContext();
            this.NetworkClient = new Telepathy.Client();

            this.networkDispatch = new NetworkDispatch();
        }

        public void Connect() {
            NetworkClient.Connect("localhost", 1337);
        }

        public void Run() {
            this.IsRunning = true;

            Initialize();

            while (IsRunning) {
                Update();
                RenderFrame(RenderContext);
            }

            Shutdown();
        }

        private void Initialize() {
            if (SDL_Init(SDL_INIT_VIDEO) < 0) {
                throw new Exception($"SDL could not initialize! SDL_Error: {SDL_GetError()}");
            }

            var result = IMG_Init((IMG_InitFlags)ImageFlags);
            if ((result & ImageFlags) != ImageFlags) {
                throw new Exception(SDL_GetError());
            }

            var window = SDL_CreateWindow("Test", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 1024, 768, SDL_WindowFlags.SDL_WINDOW_SHOWN);
            if (window == IntPtr.Zero) {
                throw new Exception($"Window could not be created! SDL_Error: {SDL_GetError()}");
            }

            var rendererHandle = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            var renderer = new Renderer(rendererHandle);

            RenderContext.UpdateRenderer(renderer);

            OnInitialize();
        }

        protected virtual void OnInitialize() {
        }

        private void Shutdown() {
            IMG_Quit();
            SDL_Quit();
        }

        private void Update() {
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

            while (SDL_PollEvent(out var e) != 0) {
                switch (e.type) {
                    case SDL_EventType.SDL_QUIT:
                        IsRunning = false;
                        break;
                }
            }

            if (Screen != null) {
                Screen.Update();
            }
        }

        private void RenderFrame(RenderContext renderContext) {
            SDL_SetRenderDrawColor(renderContext.Renderer.Handle, 0, 0, 0, 0);
            SDL_RenderClear(renderContext.Renderer.Handle);

            if (Screen != null) {
                Screen.RenderFrame(renderContext);
            }

            SDL_RenderPresent(renderContext.Renderer.Handle);
        }

        public void ChangeScreen<TScreen>() {
            var screenContext = new ScreenContext(ResourceLocator);

            var screen = (IScreen)Activator.CreateInstance(typeof(TScreen), screenContext);

            screen.PrepareResources(RenderContext.Renderer);

            this.Screen = screen;
        }
    }
}
