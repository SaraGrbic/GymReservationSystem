using System;
using System.Web;
using System.Web.Mvc;
using GymReservationSystem.Data;
using GymReservationSystem.DomainModel;
using GymReservationSystem.Models;
using System.Linq;

namespace GymReservationSystem.Controllers
{
    public class ClosedTimeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClosedTime
        public ActionResult Index()
        {
            return View();
        }
        //GET:ClosedTime list
        public ActionResult GetClosedTime()
        {
            var closedTime = db.ClosedTimes.ToList();
            var closedTimeViewModel = closedTime.Select(c => new ClosedTimeViewModel()
            {
                Id = c.Id,
                StartTime=c.StartTime.ToString(),
                EndTime=c.EndTime.ToString(),
                DayOfWeek=c.DayOfWeek.ToString(),
                Reason=c.Reason
            });
            return Json(closedTimeViewModel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetClosedTimeForm(int id)
        {
            ClosedTimeRequest closedTimeViewModel;
            if (id==0)
            {
                closedTimeViewModel = new ClosedTimeRequest();
            }
            else
            {
                var closedTime = db.ClosedTimes.FirstOrDefault(i => i.Id == id);
                closedTimeViewModel = new ClosedTimeRequest
                {
                    Id=closedTime.Id,
                    StartTime=closedTime.StartTime,
                    EndTime=closedTime.EndTime,
                    DayOfWeek=closedTime.DayOfWeek,
                    Reason=closedTime.Reason
                };
            }
            return View(closedTimeViewModel);
        }
        [HttpPost]
        public ActionResult Save(ClosedTimeRequest closeTimeRequest)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (closeTimeRequest.Id>0)
                {
                    //Edit
                    var closedTime = db.ClosedTimes.FirstOrDefault(i => i.Id == closeTimeRequest.Id);
                    if (closedTime !=null)
                    {
                        closedTime.StartTime = closeTimeRequest.StartTime;
                        closedTime.EndTime = closeTimeRequest.EndTime;
                        closedTime.DayOfWeek = closeTimeRequest.DayOfWeek;
                        closedTime.Reason = closeTimeRequest.Reason;

                    }
                }
                else
                {
                    var closedTime = new ClosedTime()
                    {
                        StartTime = closeTimeRequest.StartTime,
                        EndTime=closeTimeRequest.EndTime,
                        DayOfWeek=closeTimeRequest.DayOfWeek,
                        Reason=closeTimeRequest.Reason

                    };
                    //Save
                    db.ClosedTimes.Add(closedTime);
                }
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}