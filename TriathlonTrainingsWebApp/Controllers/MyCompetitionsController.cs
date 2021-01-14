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
    public class MyCompetitionsController : Controller
    {
        private TriathlonContext db = new TriathlonContext();

        // GET: MyCompetitions
        public async Task<ActionResult> Competitions(MyCompetition myCompetition)
        {
            //myCompetition.Date = myCompetition.Date.Date;
            
            return View(await db.MyCompetitions.ToListAsync());
        }
       
        // GET: MyCompetitions/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: MyCompetitions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Date,Distance,Description,DaysLeft")] MyCompetition myCompetition)
        {
            if (ModelState.IsValid)
            {
                db.MyCompetitions.Add(myCompetition);
                await db.SaveChangesAsync();
                return RedirectToAction("Competitions");
            }

            return View(myCompetition);
        }

        // GET: MyCompetitions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCompetition myCompetition = await db.MyCompetitions.FindAsync(id);
            if (myCompetition == null)
            {
                return HttpNotFound();
            }
            return View(myCompetition);
        }

        // POST: MyCompetitions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Date,Distance,Description,Link,DaysLeft")] MyCompetition myCompetition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myCompetition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Competitions");
            }
            return View(myCompetition);
        }

        // GET: MyCompetitions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCompetition myCompetition = await db.MyCompetitions.FindAsync(id);
            if (myCompetition == null)
            {
                return HttpNotFound();
            }
            return View(myCompetition);
        }

        // POST: MyCompetitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyCompetition myCompetition = await db.MyCompetitions.FindAsync(id);
            db.MyCompetitions.Remove(myCompetition);
            await db.SaveChangesAsync();
            return RedirectToAction("Competitions");
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
