using GymReservationSystem.Models;
using System.Web.Mvc;
using GymReservationSystem.Data;
using System.Linq;
using GymReservationSystem.DomainModel;

namespace IdentitySample.Controllers
{
    //[Authorize]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        //Get: Clients list
        public ActionResult GetClients()

        {
            var clients = db.Clients.ToList();
            var clientsViewModel = clients.Select(c => new ClientViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Gender = c.Gender,
                BirthDate = c.BirthDate.ToShortDateString(),
                PhoneNumber = c.PhoneNumber,
                RegistrationDate = c.RegistrationDate.ToShortDateString()
            });

            return Json(clientsViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            ClientRequest clientViewModel;
            if (id==0)
            {
                clientViewModel = new ClientRequest();
            }
            else
            {
                var client = db.Clients.FirstOrDefault(i => i.Id == id);
                clientViewModel = new ClientRequest
                {
                    
                    FirstName=client.FirstName,
                    LastName=client.LastName,
                    Gender=client.Gender,
                    BirthDate=client.BirthDate,
                    PhoneNumber=client.PhoneNumber,
                    RegistrationDate=client.RegistrationDate,
                    Id = client.Id
                };
            }
             return View(clientViewModel);
        }

        [HttpPost]
        public ActionResult Save(ClientRequest clientRequest)
        {
            bool status = false;

            if (ModelState.IsValid)
            {
                if (clientRequest.Id > 0)
                {
                    //Edit
                    var client = db.Clients.FirstOrDefault(a => a.Id == clientRequest.Id);
                    
                    if (client!=null)
                    {
                        client.FirstName = clientRequest.FirstName;
                        client.LastName = clientRequest.LastName;
                        client.Gender = clientRequest.Gender;
                        client.BirthDate = clientRequest.BirthDate;
                        client.PhoneNumber = clientRequest.PhoneNumber;
                        client.RegistrationDate = clientRequest.RegistrationDate;
                    }
                }
                else
                {
                    var client = new Client
                    {

                        FirstName = clientRequest.FirstName,
                        LastName = clientRequest.LastName,
                        Gender = clientRequest.Gender,
                        BirthDate = clientRequest.BirthDate,
                        PhoneNumber = clientRequest.PhoneNumber,
                        RegistrationDate = clientRequest.RegistrationDate
                    };
                    //Save
                    db.Clients.Add(client);
                }       
                status = true;
                db.SaveChanges();
            }

            return new JsonResult { Data = new { status = status } };
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var v = db.Clients.FirstOrDefault(a => a.Id == id);
            if (v!=null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteClient(int id)
        {
            bool status = false;
            var v = db.Clients.FirstOrDefault(a => a.Id == id);
            if (v!=null)
            {
                db.Clients.Remove(v);
                db.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
