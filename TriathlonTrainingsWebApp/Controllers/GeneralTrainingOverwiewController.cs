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
