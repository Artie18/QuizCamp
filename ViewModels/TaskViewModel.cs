using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizCamp.ViewModels
{
    public class TaskViewModel
    {
        public virtual Guid TaskId { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Content { get; set; }
        
        [Required]
        public virtual string Answer { get; set; }
        
        public virtual string Tags { get; set; }
        
        public virtual Platform Platform { get; set; }
    }
}