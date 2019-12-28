using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Registration obj)
        {
            var s = (from c in db.Registrations where c.UserId.Equals(obj.UserId) && c.Pass.Equals(obj.Pass) select c).FirstOrDefault();
            if (s != null)
            {
                TempData["uid"] = s.Email;
                TempData.Keep();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {

            }
            {
                ViewBag.data = "Invalid Userid and password";
                return View();
            }
           
        }
    }
}
