using System;

namespace TriathlonTrainingsWebApp.Models
{
    public class MyCompetition
    {
        private int daysLeft;
        private DateTime date;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date
        {
            set => date = value;
            get => date.Date;
        }
        public int? Distance { get; set; }
        public string Description { get; set; }
        public int? DaysLeft
        {
            set => daysLeft = (int)(Date - DateTime.Now).TotalDays;
            get => daysLeft;
        }
    }
}