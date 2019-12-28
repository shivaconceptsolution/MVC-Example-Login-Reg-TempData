using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using System.Data;
namespace MvcApplication2.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        Database1Entities db = new Database1Entities();
       
        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["uid"] == null)
            {
                Response.Redirect("/Login/Index");
            }
            var s = db.Registrations.ToList();
            return View(s);
        }
        public ActionResult EditReg(string id)
        {
            var s = db.Registrations.Find(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult EditReg(Registration obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReg(string id)
        {
            var s = db.Registrations.Find(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult DeleteReg(Registration obj)
        {
            var d = db.Registrations.Find(obj.UserId);
            db.Registrations.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            TempData["uid"] = null;

            return RedirectToAction("Index","Login");
        }
    }
}
