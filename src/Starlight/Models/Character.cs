using Starlight.Models;
using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;

namespace Starlight.Models
{
    public class Character : CoreDataModel, IDynamicStateModel<Character.DynamicState>
    {
        public class DynamicState
        {
            public Vector2 Offset { get; set; }
        }

        [IgnoreDataMember]
        public DynamicState State { get; set; }

        public int Slot { get; set; }
        public string Name { get; set; }

        public int Sprite { get; set; }

        public Character() {
            this.State = new DynamicState();
        }
    }
}
