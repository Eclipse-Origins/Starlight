using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class GlobalTimeEvents : CoreDataModel
    {
        public Nullable<int> Month { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<int> Hour { get; set; }
        public Nullable<int> Minute { get; set; }
        public String Name { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Interval { get; set; }

        public static GlobalTimeEvents Create() {
            GlobalTimeEvents globalTimeEvent = new GlobalTimeEvents();
            globalTimeEvent.Month = 1;
            globalTimeEvent.Day = 1;
            globalTimeEvent.Hour = 0;
            globalTimeEvent.Minute = 0;
            globalTimeEvent.Name = "Happy New Year!";
            globalTimeEvent.Active = true;
            globalTimeEvent.Interval = null;

            return globalTimeEvent;
        }
    }
}
