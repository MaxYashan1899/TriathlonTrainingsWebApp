using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using TriathlonTrainingsWebApp.Models;

namespace TriathlonTrainingsWebApp.Controllers
{
    [Authorize]
    public class GeneralTrainingOverwiewController : Controller
    {
        private TriathlonContext db = new TriathlonContext();

       
        public async Task<ActionResult> TrainingOverwiew(TriathlonTraining triathlonTraining)
        {
          
            return View(await db.TriathlonActivities.ToListAsync());
        }
        public async Task<ActionResult> TrainingOverwiew7Days(TriathlonTraining triathlonTraining)
        {

            return View(await db.TriathlonActivities.ToListAsync());
        }
        public async Task<ActionResult> TrainingOverwiew30Days(TriathlonTraining triathlonTraining)
        {

            return View(await db.TriathlonActivities.ToListAsync());
        }
        // GET: GeneralTrainingOverwiew
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.TriathlonActivities.ToListAsync());
        //}

        //// GET: GeneralTrainingOverwiew/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
        //    if (triathlonTraining == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(triathlonTraining);
        //}

        //// GET: GeneralTrainingOverwiew/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: GeneralTrainingOverwiew/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        //// Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Distance,Duration,Speed,Pace,CurrentDate,KindOfSports")] TriathlonTraining triathlonTraining)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TriathlonActivities.Add(triathlonTraining);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(triathlonTraining);
        //}

        //// GET: GeneralTrainingOverwiew/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
        //    if (triathlonTraining == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(triathlonTraining);
        //}

        //// POST: GeneralTrainingOverwiew/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        //// Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Distance,Duration,Speed,Pace,CurrentDate,KindOfSports")] TriathlonTraining triathlonTraining)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(triathlonTraining).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(triathlonTraining);
        //}

        //// GET: GeneralTrainingOverwiew/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
        //    if (triathlonTraining == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(triathlonTraining);
        //}

        //// POST: GeneralTrainingOverwiew/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    TriathlonTraining triathlonTraining = await db.TriathlonActivities.FindAsync(id);
        //    db.TriathlonActivities.Remove(triathlonTraining);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
