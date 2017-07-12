
using System.Linq;
using System.Web.Mvc;
using GymReservationSystem.DomainModel;
using GymReservationSystem.Models;
using GymReservationSystem.Data;

namespace GymReservationSystem.Controllers
{
    public class HolidayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Holiday
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetHolidays()
        {
            var holidays = db.Holidays.ToList();
            var holidaysViewModel = holidays.Select(h => new HolidayViewModel()
            {
                Id = h.Id,
                Day=h.Day.ToShortDateString(),
                Title=h.Title

            
            });
            return Json(holidaysViewModel, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]  
        public ActionResult GetHolidaysForm(int id)
        {
            HolidayRequest holidayViewModel;
            if (id==0)
            {
                holidayViewModel = new HolidayRequest();
            }
            else
            {
                var holiday = db.Holidays.FirstOrDefault(i => i.Id == id);
                holidayViewModel = new HolidayRequest
                {
                    Id=holiday.Id,
                    Day=holiday.Day,
                    Title=holiday.Title
                };
            }
            return View(holidayViewModel);
        }
        [HttpPost]
        public ActionResult Save(HolidayRequest holidayRequest)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (holidayRequest.Id>0)
                {
                    //Edit
                    var holiday = db.Holidays.FirstOrDefault(h => h.Id == holidayRequest.Id);
                    if (holiday!=null)
                    {
                        holiday.Day = holidayRequest.Day;
                        holiday.Title = holidayRequest.Title;

                    }

                }
                else
                {
                    var holiday = new Holiday
                    {
                        Day = holidayRequest.Day,
                        Title = holidayRequest.Title

                    };
                    //Save
                    db.Holidays.Add(holiday);
                }
                status = true;
                db.SaveChanges();
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}