using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizCamp.Models.Providers;

namespace QuizCamp.Controllers
{
    public class PlatformController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Platform/

        public ActionResult Index()
        {
            return View(db.Platforms.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Platform platform)
        {
            var platformProvider = new PlatformProvider();
            platformProvider.Add(platform);
            return RedirectToAction("Index", "Home");
        }
    }
}
