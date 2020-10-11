using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public interface IRenderContext
    {
        GraphicsDevice GraphicsDevice { get; }
        SpriteBatch SpriteBatch { get; }
    }
}
