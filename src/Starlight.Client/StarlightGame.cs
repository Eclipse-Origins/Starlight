using Starlight.Client.Screens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client
{
    public class StarlightGame : Game
    {
        public StarlightGame(string workingDirectory) : base(workingDirectory) {
        }

        protected override void OnInitialize() {
            base.OnInitialize();

            this.ChangeScreen<SplashScreen>();
        }
    }
}
