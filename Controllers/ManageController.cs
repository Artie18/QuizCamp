using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizCamp.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Block(string id)
        {
            Guid userId;
            if(Guid.TryParse(id, out userId))
            {
                db.Users.Find(userId).IsLockedOut = true;
            }
            return RedirectToAction("Index", "Manage");
        }

        public ActionResult AddAdmin(string id)
        {
            Guid userId;
            if (Guid.TryParse(id, out userId))
            {
                db.Users.Find(userId).Roles.Add(db.Roles.FirstOrDefault(x => x.RoleName == "admin"));
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Manage");
        }

        public ActionResult RemoveFromAdmin(string id)
        {
            Guid userId;
            if (Guid.TryParse(id, out userId))
            {
                db.Users.Find(userId).Roles.Remove(db.Roles.FirstOrDefault(x => x.RoleName == "admin"));
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Manage");
        }
    }
}
