using System;
using System.ComponentModel.DataAnnotations;

namespace TriathlonTrainingsWebApp.Models
{
    public class TriathlonTraining
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Distance { get; set; }
        [Required]
        [Range(1, 5000)]
        public double Duration { get; set; }
        public double? Speed { get; set; }
        public double? Pace { get; set; }
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