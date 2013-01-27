using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuizCamp.Models.Providers;
using QuizCamp.ViewModels;

namespace QuizCamp.Controllers
{
    public class TaskController : Controller
    {
        private static DataContext db = new DataContext();
        private TaskModel taskProvider = new TaskModel(db);
        //
        // GET: /CodeTask/

        public ActionResult Index()
        {
            return View(db.CodeTasks.ToList());
        }


        //
        // GET: /AddTask/

        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(TaskViewModel codeTask)
        {

            taskProvider.AddTask(codeTask);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Details(Guid id)
        {
            CodeTask task = db.CodeTasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ContentResult Like(string id)
        {

            Guid taskId;
            if (Guid.TryParse(id, out taskId))
            {
                taskProvider.IncrementLikes(taskId);
                return Content(taskProvider.GetById(taskId).LikedUsers.Count().ToString());
            }

            return null;
        }

        [HttpGet]
        public ContentResult GetLikes(string id)
        {

            Guid taskId;
            if (Guid.TryParse(id, out taskId))
            {
                var task = db.CodeTasks.Find(taskId);
                return Content(task.LikedUsers == null ? "0" : taskProvider.GetById(taskId).LikedUsers.Count().ToString());
            }
            return null;
        }

        public ActionResult Edit(string id)
        {
            Guid taskId;
            if (Guid.TryParse(id, out taskId))
            {
                var task = taskProvider.GetById(taskId);
                return View(new TaskViewModel
                {
                    Name = task.Name,
                    Content = task.Content,
                    Answer = task.Answer,
                    Platform = task.Platform,
                    TaskId = task.CodeTaskId,
                });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(TaskViewModel taskView)
        {
            taskProvider.UpdateCodeTask(taskView);
            return RedirectToAction("MyTasks");
            
        }



        [HttpGet]
        public ContentResult LoadPlatforms()
        {
            var s = db.Platforms.ToList().Aggregate("", (current, platform) => current + platform.Name + "|");

            return Content(s);
        }

        [HttpGet]
        public ContentResult Answer(string id, string value)
        {
            Guid taskId;
            return Guid.TryParse(id, out taskId) ? Content(taskProvider.CheckForAnwser(taskId, value).ToString()) : null;
        }

        [HttpGet]
        public ContentResult GetAnswerCount(string id)
        {
            Guid taskId;
            return Guid.TryParse(id, out taskId) ? Content(db.CodeTasks.Find(taskId).SolvedUsers.Count().ToString()) : null;
        }

        public ActionResult Tasks(string page, string tagName)
        {
            return View(taskProvider.GetTasks(page, tagName));
        }

        public ActionResult MyTasks()
        {
            return View(db.CodeTasks.ToList());
        }
    }
}
