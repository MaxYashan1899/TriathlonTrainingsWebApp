using System;
using System.ComponentModel.DataAnnotations;

namespace TriathlonTrainingsWebApp.Models
{
    public class TriathlonTraining
    {
        public int Id { get; set; }
        [Required]
        //[Range((0.5), 1000, ErrorMessage = "Amount should be in range {1} to {2}.")]
        //[RegularExpression(@"\d", ErrorMessage = "Amount is not valid.")]
        public double Distance { get; set; }
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