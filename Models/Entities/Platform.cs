using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class Platform 
{
    [Key]
    public virtual Guid PlatformId { get; set; }

    [Required]
    [MaxLength(20, ErrorMessage = "Make it smaller")]
    public virtual string Name { get; set; }

    public virtual List<CodeTask> CodeTasks { get; set; }
    
}
