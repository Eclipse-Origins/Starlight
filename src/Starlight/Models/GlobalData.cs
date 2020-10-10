using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Starlight.Models
{
    public class GlobalData : CoreDataModel
    {
        public String Name { get; set; }
        public string Value { get; set; }

        public static GlobalData[] Create() {
            var globaldata = new List<GlobalData>();
            var data = new GlobalData();
            data.Name = "CreationYear";
            data.Value = "1000";
            globaldata.Add(data);
            data = new GlobalData();
            data.Name = "DaysPerMonth";
            data.Value = "30";
            globaldata.Add(data);
            data = new GlobalData();
            data.Name = "HoursPerDay";
            data.Value = "24";
            globaldata.Add(data);
            data = new GlobalData();
            data.Name = "MinutesPerHour";
            data.Value = "60";
            globaldata.Add(data);
            data = new GlobalData();
            data.Name = "SecondsPerMinute";
            data.Value = "60";
            globaldata.Add(data);
            data = new GlobalData();
            data.Name = "DuskHours";
            data.Value = "2";
            globaldata.Add(data);
            return globaldata.ToArray();
        }
    }
}
