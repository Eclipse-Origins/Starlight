using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models.Contracts
{
    public interface IAnimationState
    {
        int Frame { get; set; }
        TimeSpan FrameTransitionTime { get; set; }
    }
}
