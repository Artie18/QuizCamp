using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using QuizCamp.Models.Search;
using QuizCamp.ViewModels;

namespace QuizCamp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult SetLocale(string locale)
        {

            var localization = new HttpCookie("Localization");
            localization["lang"] = locale;
            localization["uiLang"] = locale;
            Response.Cookies.Add(localization);

            return RedirectToAction("Index", "Home");
        }

        public void Localization()
        {
            if (Request.Cookies["Localization"] != null)
            {
                var lang = Request.Cookies["Localization"]["lang"];
                Thread.CurrentThread.CurrentCulture =  CultureInfo.CreateSpecificCulture(Request.Cookies["Localization"]["lang"]);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(Request.Cookies["Localization"]["uiLang"]);
            }
            else if (Request.Cookies["Localization"] == null)
            {
               Thread.CurrentThread.CurrentCulture =  CultureInfo.CreateSpecificCulture("en");
               Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
               var localization = new HttpCookie("Localization");
               localization["lang"] = "en";
               localization["uiLang"] = "en";
               Response.Cookies.Add(localization);
            }
        }

        public JsonResult Search(string search)
        {
            var SearchResult = SearchEngine.Search(search);
            var Result = new List<TaskViewModel>();
            for (var i = 0; i < 5; i++ )
            {
                 Result.Add( new TaskViewModel
                     {
                         Name = SearchResult.ElementAt(i).Name
                     });
            }
                return Json(Result);
        }

    }
}
