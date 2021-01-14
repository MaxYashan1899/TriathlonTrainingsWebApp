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
        public string Link { get; set; }
        public int? DaysLeft
        {
            set
            {
                if ((int)(Date - DateTime.Now).TotalDays >0)
                    daysLeft = (int)(Date - DateTime.Now).TotalDays;
                else
                    daysLeft = 0;
            }
            get => daysLeft;
        }
    }
}