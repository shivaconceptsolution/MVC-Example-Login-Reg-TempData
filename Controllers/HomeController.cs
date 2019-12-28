using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Database1Entities db = new Database1Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Registration obj)
        {
            db.Registrations.Add(obj);
            db.SaveChanges();
            ViewBag.data = "Data Inserted Successfully";
            obj.Email = obj.Fullname=obj.Pass=obj.UserId= "";
            return View();
        }
    }
}
