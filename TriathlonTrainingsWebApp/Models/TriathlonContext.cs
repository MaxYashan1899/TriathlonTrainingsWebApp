﻿using System.Data.Entity;

namespace TriathlonTrainingsWebApp.Models
{
    public class TriathlonContext: DbContext
    {
        public DbSet<TriathlonTraining> TriathlonActivities { get; set; }
    }
}