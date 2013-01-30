using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizCamp.Models.Providers;
using QuizCamp.ViewModels;

namespace QuizCamp.Controllers
{
    public class TagController : Controller
    {
        private static DataContext db = new DataContext();
        private TagProvider tagModel = new TagProvider();
        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TagCloud()
        {
            return View(tagModel.GetTags());
        }

}
}
