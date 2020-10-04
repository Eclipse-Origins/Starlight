using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight.Models
{
    public class GlobalConstellation : CoreDataModel
    {
        public int Sattelite { get; set; }
        public int Series { get; set; }
        public String Name { get; set; }
        public static GlobalConstellation[] Create() {

            var sun = new List<GlobalConstellation>();
            var sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 0;
            sunny.Name = "Sun";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 1;
            sunny.Name = "January";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 2;
            sunny.Name = "February";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 3;
            sunny.Name = "March";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 4;
            sunny.Name = "April";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 5;
            sunny.Name = "May";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 6;
            sunny.Name = "June";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 7;
            sunny.Name = "July";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 8;
            sunny.Name = "August";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 9;
            sunny.Name = "September";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 10;
            sunny.Name = "October";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 11;
            sunny.Name = "November";
            sun.Add(sunny);
            sunny = new GlobalConstellation();
            sunny.Sattelite = 0;
            sunny.Series = 12;
            sunny.Name = "December";
            sun.Add(sunny);

            var moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 0;
            moony.Name = "Moon";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 1;
            moony.Name = "New Moon";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 2;
            moony.Name = "Waxing Crescent";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 7;
            moony.Name = "First Quarter";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 8;
            moony.Name = "Waxing gibbous";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 14;
            moony.Name = "Full Moon";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 15;
            moony.Name = "Waning gibbous";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 22;
            moony.Name = "Last Quarter";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 23;
            moony.Name = "Waning crescent";
            sun.Add(moony);
            moony = new GlobalConstellation();
            moony.Sattelite = 1;
            moony.Series = 27;
            moony.Name = "Waning crescent";
            sun.Add(moony);

            var bloodmoony = new GlobalConstellation();
            bloodmoony.Sattelite = 2;
            bloodmoony.Series = 0;
            bloodmoony.Name = "Bloodmoon";
            sun.Add(bloodmoony);
            bloodmoony = new GlobalConstellation();
            bloodmoony.Sattelite = 2;
            bloodmoony.Series = 1;
            bloodmoony.Name = "";
            sun.Add(bloodmoony);
            bloodmoony = new GlobalConstellation();
            bloodmoony.Sattelite = 2;
            bloodmoony.Series = 14;
            bloodmoony.Name = "Bloodmoon";
            sun.Add(bloodmoony);
            bloodmoony = new GlobalConstellation();
            bloodmoony.Sattelite = 2;
            bloodmoony.Series = 15;
            bloodmoony.Name = "";
            sun.Add(bloodmoony);
            bloodmoony = new GlobalConstellation();
            bloodmoony.Sattelite = 2;
            bloodmoony.Series = 55;
            bloodmoony.Name = "";
            sun.Add(bloodmoony);

            return sun.ToArray();
        }
    }
}