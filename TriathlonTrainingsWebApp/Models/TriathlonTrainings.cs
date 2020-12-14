using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriathlonTrainingsWebApp.Models
{
    public class TriathlonTrainings
    {
        public int Id { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double Speed { get; set; }
        public double Pace { get; set; }
        public DateTime CurrentDate { get; set; }
        public KindOfSports KindOfSports { get; set; }
    }
    public enum KindOfSports
    {
        Running = 1,
        Bicycle = 2,
        Swimming = 3
    }
}