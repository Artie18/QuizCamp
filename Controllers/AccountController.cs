using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using QuizCamp.Models.Providers;
using QuizCamp.ViewModels;

namespace QuizCamp.Controllers
{
    public class AccountController : Controller
    {
        AccountProvider account = new AccountProvider();
        //
        // GET: /Account/

        public ActionResult Index(Guid id)
        {
                return View(account.GetById(id));
        }

        public ActionResult MyProfile()
        {
            return View("Index", account.GetLogedInUser());
        }

  
        
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                account.Register(user);
                return RedirectToAction("RegistartionComplite", "Account");
            }
            return View(User);

        }

        public ActionResult RegistartionComplite()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            model.RememberMe = false;
            if (ModelState.IsValid && WebSecurity.Login(model.Username, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit()
        {
            return View(account.GetLogedInUser());
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dbUser = account.GetLogedInUser();
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Comment = user.Comment;

            if (dbUser.Username != user.Username)
            {
                WebSecurity.Logout();
                dbUser.Username = user.Username;
                account.SaveChanges();
                return RedirectToAction("Changed", "Account", "Username");
            }
            account.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Changed(String message)
        {
            return View(message);
        }
    }
}
