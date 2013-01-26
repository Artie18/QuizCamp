using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using QuizCamp.ViewModels;

namespace QuizCamp.Models.Providers
{
    public class TaskModel
    {
        private DataContext db;

        public TaskModel(DataContext db)
        {
            this.db = db;

        }

        public void AddTask(TaskViewModel task)
        {

            var codeTask = new CodeTask
                {
                    User = db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name),
                    CodeTaskId = Guid.NewGuid(),
                    TimeAded = DateTime.Now,
                    Name = task.Name,
                    Content = task.Content,
                    Answer = task.Answer,
                };
            codeTask.Platform = db.Platforms.FirstOrDefault(x => x.Name == task.Platform.Name);
            db.CodeTasks.Add(codeTask);
            AddTags(task.Tags, codeTask.CodeTaskId);
            db.SaveChanges();

        }

        public void AddTags(string tagsString, Guid codeTaskId)
        {
            var tags = tagsString.Split(' ');
            foreach (var tag in tags)
            {
                var existingTag = db.Tags.FirstOrDefault(x => x.Name == tag);
                if (existingTag != null)
                {
                    existingTag.Tasks.Add(db.CodeTasks.Find(codeTaskId));
                    db.SaveChanges();
                }
                else
                {
                    AddNewTag(tag, codeTaskId);
                }
            }
        }

        public void AddNewTag(string tag, Guid codeTaskId)
        {
            var newTag = new Tag { Name = tag, Tasks = new List<CodeTask>(), TagId = Guid.NewGuid() };
            newTag.Tasks.Add(db.CodeTasks.Find(codeTaskId));
            db.Tags.Add(newTag);
        }

        public void IncrementLikes(Guid id)
        {
            var task = db.CodeTasks.Find(id);
            var user = db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name);
            if (task.LikedUsers == null)
            {
                task.LikedUsers = new List<User> { db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name) };
            }
            if (task.LikedUsers.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name) == null)
            {
                task.LikedUsers.Add(db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name));
            }
            db.SaveChanges();
        }

        public CodeTask GetById(Guid id)
        {
            return db.CodeTasks.Find(id);
        }


        public bool CheckForAnwser(Guid id, string value)
        {
            var task = db.CodeTasks.Find(id);
            if (task.Answer != value)
                return false;
            if (task.SolvedUsers == null)
            {
                task.SolvedUsers = new List<User>
                    {
                        db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name)
                    };
                db.SaveChanges();
                return true;
            }
            else
                if (task.SolvedUsers.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name) == null)
                {
                    task.SolvedUsers.Add(db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name));
                    db.SaveChanges();
                    return true;
                }
            return false;
        }

        public List<CodeTask> GetTasks(string page, string tagName)
        {
            const int tasksPage = 5;
            
            if (tagName != null)
                return GetPageList<CodeTask>(tasksPage, Convert.ToInt32(page), GetTasksList(tagName));
            else
                return GetPageList<CodeTask>(tasksPage, Convert.ToInt32(page), GetTasksList());
        }

        public List<CodeTask> GetTasksList(string tagName)
        {
            return db.CodeTasks.OrderByDescending(x => x.LikedUsers.Count()).Where(y => y.Tags.FirstOrDefault(z => z.Name == tagName) != null).ToList();
        }

        public List<CodeTask> GetTasksList()
        {
            return db.CodeTasks.OrderByDescending(x => x.TimeAded).ToList();
        }

        public List<T> GetPageList<T>(int tasksPage, int page, List<T> list)
        {
            var tasksOnPage = tasksPage;

            if (tasksPage * page > list.Count())
                tasksOnPage = list.Count() - tasksPage * (page - 1);
            if (tasksOnPage < 0)
                return new List<T>();
            return list.ToList().GetRange(tasksPage * page - tasksPage, tasksOnPage);

        }

        public void UpdateCodeTask(TaskViewModel taskView)
        {
            var task = db.CodeTasks.Find(taskView.TaskId);
            task.Answer = taskView.Answer;
            task.Content = taskView.Content;
            task.Name = taskView.Name;
            task.Platform = db.Platforms.FirstOrDefault(x => x.Name == taskView.Platform.Name);
            db.SaveChanges();
        }

    }
}
