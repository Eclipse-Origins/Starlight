using Serilog;
using Starlight.Models;
using Starlight.Server.Data;
using System;
using System.Linq;

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

            Log.Debug("Today is: " + clock.Day + " " + nameofmonth.Name + " " + clock.Year + " " + clock.Hour.ToString("00") + ":" + clock.Minute.ToString("00") + ":00 ");
            DoTimedEvents(database, clock);
            database.Clock.Update(clock);
            database.SaveChanges();
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