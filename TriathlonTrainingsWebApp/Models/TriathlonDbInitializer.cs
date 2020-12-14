﻿using System;
using System.Data.Entity;

namespace TriathlonTrainingsWebApp.Models
{
    public class TriathlonDbInitializer : DropCreateDatabaseAlways<TriathlonContext>
    {
        protected override void Seed(TriathlonContext db)
        {
            db.TriathlonActivities.Add(new TriathlonTraining { Distance = 12, Duration = 62, CurrentDate = DateTime.Now, KindOfSports = KindOfSports.Running });
            db.TriathlonActivities.Add(new TriathlonTraining { Distance = 35, Duration = 70, CurrentDate = DateTime.Now, KindOfSports = KindOfSports.Bicycle });  ;
            db.TriathlonActivities.Add(new TriathlonTraining { Distance = 2, Duration = 58, CurrentDate = DateTime.Now, KindOfSports = KindOfSports.Swimming });

            base.Seed(db);
        }
    }
}