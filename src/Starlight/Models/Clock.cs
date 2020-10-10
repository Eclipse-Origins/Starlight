using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class Clock : CoreDataModel
    {
        public uint Year { get; set; }
        public uint Month { get; set; }
        public uint Day { get; set; }
        public uint Hour { get; set; }
        public uint Minute { get; set; }


        public static Clock Create() {
            var clock = new Clock();
            clock.Year = 0;
            clock.Month = 1;
            clock.Day = 1;
            clock.Hour = 0;
            clock.Minute = 0;
            return clock;
        }
    }

}
