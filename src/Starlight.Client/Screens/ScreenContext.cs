using Starlight.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class ScreenContext
    {
        public ResourceLocator ResourceLocator { get; }

        public ScreenContext(ResourceLocator resourceLocator) {
            this.ResourceLocator = resourceLocator;
        }
    }
}
