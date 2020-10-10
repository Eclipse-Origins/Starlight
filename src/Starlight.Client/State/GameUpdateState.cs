using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.State
{
    public class GameUpdateState
    {
        public GameTime GameTime { get; }

        public KeyboardState KeyboardState { get; }
        public MouseState MouseState { get; }

        public GameUpdateState(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState) {
            this.GameTime = gameTime;
            this.KeyboardState = keyboardState;
            this.MouseState = mouseState;
        }
    }
}
