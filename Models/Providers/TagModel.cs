using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizCamp.ViewModels;

namespace QuizCamp.Models.Providers
{
    public class TagModel : DatabaseInitializer
    {
        public List<TagViewModel> GetTags()
        {
            var sortedTags = db.Tags.OrderByDescending(x => x.Tasks.Count);
            var tags = new List<TagViewModel>();
            foreach (var tag in sortedTags)
            {
                var newTag = new TagViewModel { Name = tag.Name };
                newTag.CodeTask = new List<CodeTaskGetTag>();
                foreach (var task in tag.Tasks)
                {
                    newTag.CodeTask.Add(new CodeTaskGetTag { Name = task.Name, CodeTaskId = task.CodeTaskId });
                }
                tags.Add(newTag);
            }
            
            return tags;
        }
    }
}