using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.State
{
    public class Player : AbstractState<Player>
    {
        public Character Character { get; set; }
    }
}
