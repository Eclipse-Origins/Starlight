using Serilog;
using Starlight.Models;
using Starlight.Server.Data;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Starlight.Server.GameLogic
{
    public class PersistentUniverse
    {
        public static void DoTick(ApplicationDbContext database) {
            var clock = database.Clock.FirstOrDefault();
            uint creationyear = 0;
            uint dayspermonth = 0;
            uint hourperdays = 0;
            uint minutesperhour = 0;
            var maxmonths = 0;
            try {
                creationyear = uint.Parse(database.GlobalData.Where(x => x.Name == "CreationYear").FirstOrDefault().Value);
                dayspermonth = uint.Parse(database.GlobalData.Where(x => x.Name == "DaysPerMonth").FirstOrDefault().Value);
                hourperdays = uint.Parse(database.GlobalData.Where(x => x.Name == "HoursPerDay").FirstOrDefault().Value);
                minutesperhour = uint.Parse(database.GlobalData.Where(x => x.Name == "MinutesPerHour").FirstOrDefault().Value);
                maxmonths = database.GlobalConstellation.Where(x => x.Sattelite == 0).Max(x => x.Series);
            }
            catch (Exception) {
                Log.Fatal("Fault in GlobalData: Timesetting missing!");
                throw new InvalidTimeZoneException();
            }

            //Checks to make sure that everything is good.
            if (creationyear == 0 || dayspermonth == 0 || hourperdays == 0 || maxmonths <= 0) {
                Log.Fatal("Fault in GlobalData: Timesetting missing or incorrect!");
                throw new InvalidTimeZoneException();
            }

            //Clock ticks, do stuff!
            clock.Minute++;
            //Log.Debug("Clock is ticking...");


            if (clock.Year < creationyear) {
                Log.Information("Resetting Clock to the default year...");
                clock.Minute = 0;
                clock.Hour = 0;
                clock.Day = 1;
                clock.Month = 1;
                clock.Year = creationyear;
            }
            //Make sure the clock overflow is correct!
            if (clock.Minute >= minutesperhour) {
                clock.Hour++;
                clock.Minute = 0;
            }
            if (clock.Hour >= hourperdays) {
                clock.Day++;
                clock.Hour = 0;
            }
            if (clock.Day > dayspermonth) {
                clock.Month++;
                clock.Day = 1;
            }
            if (clock.Month > maxmonths) {
                //It's a brand new year!
                clock.Month = 1;
                clock.Year += 1;
            }

            var nameofmonth = database.GlobalConstellation.Where(x => x.Sattelite == 0 && x.Series <= clock.Month).OrderByDescending(x => x.Series).FirstOrDefault();

            Log.Debug("Today is: " + clock.Day + " " + nameofmonth.Name + " " + clock.Year + " " + clock.Hour.ToString("00") + ":" + clock.Minute.ToString("00") + ":00 " + "The moon is: " + GetConstellationName(database,1,clock) + " Sunstrength: "+ GetSunLight(database));
            DoTimedEvents(database, clock);
            database.Clock.Update(clock);
            database.SaveChanges();
        }

        public static float GetSunLight(ApplicationDbContext database) {
            var clock = database.Clock.FirstOrDefault();
            return GetSunLight(database,clock);
        }

        public static float GetSunLight(ApplicationDbContext database, Clock clock) {
            var duskhours = uint.Parse(database.GlobalData.Where(x => x.Name == "DuskHours").FirstOrDefault().Value);
            var hourperdays = uint.Parse(database.GlobalData.Where(x => x.Name == "HoursPerDay").FirstOrDefault().Value);
            var minutesperhour = uint.Parse(database.GlobalData.Where(x => x.Name == "MinutesPerHour").FirstOrDefault().Value);
            var duskTimeStart = (hourperdays / 4) - duskhours / 2;
            var duskTimeEnd = duskTimeStart + duskhours;
            if (duskhours == 0) {
                duskTimeStart = (hourperdays / 4);
                duskTimeEnd = duskTimeStart;
            };
            if (clock.Hour < duskTimeStart)
            {
                return 0;
            }
            else if (clock.Hour < duskTimeEnd)
                {
                var currentDuskTime = clock.Hour * minutesperhour + clock.Minute;
                return (float)currentDuskTime / (float)(duskTimeEnd*minutesperhour);
            }
            else if (clock.Hour >= (hourperdays - duskTimeEnd)) {
                var currentDuskTime = (hourperdays - clock.Hour - duskTimeEnd) * minutesperhour + clock.Minute;
                var currentLightLevel = 1- (float)currentDuskTime / (float)(duskhours * minutesperhour);
                return currentLightLevel;

            } else if (clock.Hour >= duskTimeEnd) {
                return 1;
            }
            else if (clock.Hour >= (hourperdays - duskTimeStart)) {
                return 0;
            }
            return -1;
        }

        public static string GetConstellationName(ApplicationDbContext database, uint moonId) {
            var clock = database.Clock.FirstOrDefault();
            return GetConstellationName(database, moonId, clock);
        }

        public static string GetConstellationName(ApplicationDbContext database, uint moonId, Clock clock) {
            var creationyear = uint.Parse(database.GlobalData.Where(x => x.Name == "CreationYear").FirstOrDefault().Value);
            var dayspermonth = uint.Parse(database.GlobalData.Where(x => x.Name == "DaysPerMonth").FirstOrDefault().Value);
            var hourperdays = uint.Parse(database.GlobalData.Where(x => x.Name == "HoursPerDay").FirstOrDefault().Value);
            var minutesperhour = uint.Parse(database.GlobalData.Where(x => x.Name == "MinutesPerHour").FirstOrDefault().Value);
            var maxmonths = database.GlobalConstellation.Where(x => x.Sattelite == 0).Max(x => x.Series);
            var elapsedDays = ((clock.Year - creationyear)* dayspermonth*maxmonths)+(clock.Month * dayspermonth + clock.Day);

            var maxmoon = database.GlobalConstellation.Where(x => x.Sattelite == moonId).Max(x => x.Series);
            if (maxmoon <= 0)
                {
                return null;
            }
            var test = elapsedDays % maxmoon + 1;
            var moonname = database.GlobalConstellation.Where(x => x.Sattelite == moonId && x.Series <= test).OrderByDescending(x => x.Series).First();
            return moonname.Name;
        }

        internal static void DoTimedEvents(ApplicationDbContext database, Clock clock) {
            var events = database.GlobalTimeEvents.Where(x => x.Active == true && (x.Month == clock.Month || x.Month == null) && (x.Day == clock.Day || x.Day == null) && (x.Hour == clock.Hour || x.Hour == null) && (x.Minute == clock.Minute || x.Minute == null)).ToArray();
            foreach (var evented in events) {
                Log.Debug("Event! " + evented.Name);
                if (evented.Interval != null) {
                    evented.Interval--;
                    if (evented.Interval <= 0) {
                        evented.Active = false;
                        database.GlobalTimeEvents.Update(evented);
                        database.SaveChanges();
                    }
                }
            }
        }
    }
}