using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    [Flags]
    public enum Direction
    {
        None = 0,
        Top = 1 << 0,
        Right = 1 << 1,
        Bottom = 1 << 2,
        Left = 1 << 3
    }
}
