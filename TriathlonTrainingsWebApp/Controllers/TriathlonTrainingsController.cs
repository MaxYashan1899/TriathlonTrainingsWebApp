using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TriathlonTrainingsWebApp.Models;

namespace TriathlonTrainingsWebApp.Controllers
{
    public class TriathlonTrainingsController : Controller
    {
        private TriathlonContext db = new TriathlonContext();

        // GET: TriathlonTrainings
        public async Task<ActionResult> Index()
        {
            return View(await db.TriathlonActivities.ToListAsync());
        }

        // GET: TriathlonTrainings/Details/5
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

        // GET: TriathlonTrainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TriathlonTrainings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("Index");
            }

            return View(triathlonTraining);
        }
        private double? CountSpeed(TriathlonTraining triathlonTraining)
        {
            triathlonTraining.Speed = Math.Round((triathlonTraining.Distance / (triathlonTraining.Duration / 60)), 2);
            return triathlonTraining.Speed;
        }
        private double? CountPace(TriathlonTraining triathlonTraining)
        {
            triathlonTraining.Pace = Math.Round((60 / (triathlonTraining.Distance / (triathlonTraining.Duration / 60))), 2);
            return triathlonTraining.Pace;
        }

        // GET: TriathlonTrainings1/Edit/5
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

        // POST: TriathlonTrainings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Distance,Duration,Speed,Pace,CurrentDate,KindOfSports")] TriathlonTraining triathlonTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triathlonTraining).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(triathlonTraining);
        }

        // GET: TriathlonTrainings/Delete/5
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

        // POST: TriathlonTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
            db.TriathlonActivities.Remove(triathlonTraining);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
