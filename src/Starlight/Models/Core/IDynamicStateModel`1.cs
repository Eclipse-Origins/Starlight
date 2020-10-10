using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Starlight.Models.Core
{
    public interface IDynamicStateModel<TState>
    {
        TState State { get; set; }
    }
}
