using System.Linq;
using System.Web.Mvc;
using GymReservationSystem.Data;
using GymReservationSystem.DomainModel;
using GymReservationSystem.Models;

namespace GymReservationSystem.Controllers
{
    public class WorkingTimeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: WorkingTime
        public ActionResult Index()
        {
            return View();
        }
      
        //Get: Working time list
        public ActionResult GetWorkingTime()
        { 
            var workingTimes = db.WorkingTimes.ToList();
            var workingTimeViewModel = workingTimes.Select(w => new WorkingTimeViewModel()
            {
                Id = w.Id,
                StartTime = w.StartTime.ToString(),
                EndTime = w.EndTime.ToString(),
                DayOfWeek = w.DayOfWeek.ToString()
                
            });
            return Json(workingTimeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            WorkingTimeRequest workingTimeViewModel;

            if(id == 0)
            {
                workingTimeViewModel = new WorkingTimeRequest();
            }
            else
            {
                var workingTime = db.WorkingTimes.FirstOrDefault(i => i.Id == id);
                workingTimeViewModel = new WorkingTimeRequest
                {
                    DayOfWeek = workingTime.DayOfWeek,
                    EndTime = workingTime.EndTime,
                    StartTime = workingTime.StartTime,
                    Id = workingTime.Id
                };
            }

            return View(workingTimeViewModel);
        }

        [HttpPost]
        public ActionResult Save(WorkingTimeRequest workingTimeRequest)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                if (workingTimeRequest.Id > 0)
                {
                    //Edit
                    var workingTime = db.WorkingTimes.FirstOrDefault(a => a.Id == workingTimeRequest.Id);
                  
                    if (workingTime != null)
                    {
                        workingTime.DayOfWeek =workingTimeRequest.DayOfWeek;
                        workingTime.StartTime = workingTimeRequest.StartTime;
                        workingTime.EndTime = workingTimeRequest.EndTime;
                    }
                }
                else
                {
                    var workingTime = new WorkingTime
                    {
                        StartTime = workingTimeRequest.StartTime,
                        EndTime = workingTimeRequest.EndTime,
                        DayOfWeek = workingTimeRequest.DayOfWeek
                    };
                    //Save
                    db.WorkingTimes.Add(workingTime);
                }

                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
      
    }
}