using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using QuizCamp.ViewModels;

namespace QuizCamp.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Account/

        public ActionResult Index(Guid id)
        {
                return View(db.Users.Find(id));
        }

        public ActionResult MyProfile()
        {
            return View("Index", db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name));
        }

        public ActionResult MyTasks()
        {
            return View(db.CodeTasks.ToList());
        }

        
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsApproved = true;
                user.UserId = Guid.NewGuid();
                db.Users.Add(user);

                db.SaveChanges();
                /*  MailMessage email = new MailMessage("art@gart.com", "artyomvirusnyak@gmail.com", "working", "cool");
                  SmtpClient eClient = new SmtpClient();
                  eClient.Send(email);*/
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
            return View(db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            User dbUser = db.Users.Find(db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name).UserId);
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Comment = user.Comment;

            if (dbUser.Username != user.Username)
            {
                WebSecurity.Logout();
                dbUser.Username = user.Username;
                db.SaveChanges();
                return RedirectToAction("Changed", "Account", "Username");
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Changed(String message)
        {
            return View(message);
        }
    }
}
