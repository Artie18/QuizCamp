using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class CodeTask
{
    [Key]
    public virtual Guid CodeTaskId { get; set; }

    [Required]
    public virtual string Name { get; set; }

    [Required]
    public virtual string Content { get; set; }

    [Required]
    public virtual User User { get; set; }

    [Required]
    public virtual DateTime TimeAded { get; set; }

    [Required]
    public virtual string Answer { get; set; }

    public virtual string HardLevel { get; set; }

    public virtual int Attempts { get; set; }

    public virtual int Rating { get; set; }

    public virtual List<Tag> Tags { get; set; }

    public virtual List<User> LikedUsers { get; set; }

    public Guid UserId { get; set; }

    public virtual List<User> SolvedUsers { get; set; } 

    public virtual Platform Platform { get; set; }
}
