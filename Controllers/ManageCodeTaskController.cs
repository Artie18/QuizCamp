using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizCamp.Controllers
{
    public class ManageCodeTaskController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /CodeTask/

        public ActionResult Index()
        {
            return View(db.CodeTasks.ToList());
        }

        //
        // GET: /CodeTask/Details/5

        public ActionResult Details(Guid id)
        {
            CodeTask codetask = db.CodeTasks.Find(id);
            if (codetask == null)
            {
                return HttpNotFound();
            }
            return View(codetask);
        }

        //
        // GET: /CodeTask/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CodeTask/Create

        [HttpPost]
        public ActionResult Create(CodeTask codetask)
        {
            if (ModelState.IsValid)
            {
                codetask.CodeTaskId = Guid.NewGuid();
                db.CodeTasks.Add(codetask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codetask);
        }

        //
        // GET: /CodeTask/Edit/5

        public ActionResult Edit(Guid id)
        {
            CodeTask codetask = db.CodeTasks.Find(id);
            if (codetask == null)
            {
                return HttpNotFound();
            }
            return View(codetask);
        }

        //
        // POST: /CodeTask/Edit/5

        [HttpPost]
        public ActionResult Edit(CodeTask codetask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codetask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codetask);
        }

        //
        // GET: /CodeTask/Delete/5

        public ActionResult Delete(Guid id)
        {
            CodeTask codetask = db.CodeTasks.Find(id);
            if (codetask == null)
            {
                return HttpNotFound();
            }
            return View(codetask);
        }

        //
        // POST: /CodeTask/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CodeTask codetask = db.CodeTasks.Find(id);
            db.CodeTasks.Remove(codetask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}