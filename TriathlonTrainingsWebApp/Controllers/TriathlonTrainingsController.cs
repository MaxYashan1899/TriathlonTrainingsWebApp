using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using TriathlonTrainingsWebApp.Models;
using System.Linq;

namespace TriathlonTrainingsWebApp.Controllers
{
    [Authorize]
    public class TriathlonTrainingsController : Controller
    {
        private TriathlonContext db = new TriathlonContext();

     
        public async Task<ActionResult> AllTrainingsList()
        {
            return View(await db.TriathlonActivities.ToListAsync());
        }
        public async Task<ActionResult> KindOfSport(int? distance)
        {
            if (distance == null)
            {
                return HttpNotFound();
            }
            TriathlonTraining kindOfActivity = await db.TriathlonActivities.FirstOrDefaultAsync(n => n.Distance < distance);

            if (kindOfActivity == null)
            {
                return HttpNotFound();
            }
            return View(kindOfActivity);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
            if (triathlonTraining == null)
            {
                return HttpNotFound();
            }
            return View(triathlonTraining);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Distance,Duration,Speed,Pace,CurrentDate,KindOfSports")] TriathlonTraining triathlonTraining)
        {
            if (ModelState.IsValid)
            {
                triathlonTraining.CurrentDate = DateTime.Now;
                CountSpeed(triathlonTraining);
                CountPace(triathlonTraining);
                db.TriathlonActivities.Add(triathlonTraining);
                await db.SaveChangesAsync();
                return RedirectToAction("TrainingOverwiew", "GeneralTrainingOverwiew");
            }

            return View(triathlonTraining);
        }
        private double? CountSpeed(TriathlonTraining triathlonTraining)
        {
            triathlonTraining.Speed = Math.Round(((double)(triathlonTraining.Distance / (triathlonTraining.Duration / 60))), 2);
            return triathlonTraining.Speed;
        }
        private double? CountPace(TriathlonTraining triathlonTraining)
        {
            triathlonTraining.Pace = Math.Round(((double)(60 / (triathlonTraining.Distance / (triathlonTraining.Duration / 60)))), 2);
            return triathlonTraining.Pace;
        }

     
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
            if (triathlonTraining == null)
            {
                return HttpNotFound();
            }
            return View(triathlonTraining);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Distance,Duration,Speed,Pace,CurrentDate,KindOfSports")] TriathlonTraining triathlonTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triathlonTraining).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AllTrainingsList");
            }
            return View(triathlonTraining);
        }

      
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
            if (triathlonTraining == null)
            {
                return HttpNotFound();
            }
            return View(triathlonTraining);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
            db.TriathlonActivities.Remove(triathlonTraining);
            await db.SaveChangesAsync();
            return RedirectToAction("AllTrainingsList");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
