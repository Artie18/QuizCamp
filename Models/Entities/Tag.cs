using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class Tag
{
    public virtual Guid TagId { get; set; }

    [Required]
    public virtual string Name { get; set; }

    public virtual List<CodeTask> Tasks { get; set; }

}