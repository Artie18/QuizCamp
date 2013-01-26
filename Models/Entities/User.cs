using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public virtual Guid UserId { get; set; }

        [Required]
        public virtual String Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Write an Email adreess!")]
        public virtual String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "It need to be at least 6 characters long!")]
        public virtual String Password { get; set; }

        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual String Comment { get; set; }

        public virtual Boolean IsApproved { get; set; }
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
        public virtual DateTime? LastPasswordFailureDate { get; set; }
        public virtual DateTime? LastActivityDate { get; set; }
        public virtual DateTime? LastLockoutDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual String ConfirmationToken { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual Boolean IsLockedOut { get; set; }
        public virtual DateTime? LastPasswordChangedDate { get; set; }
        public virtual String PasswordVerificationToken { get; set; }
        public virtual DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public virtual List<CodeTask> Tasks { get; set; } 
        
        public virtual List<Role> Roles { get; set; }

        public virtual List<CodeTask> LikedTasks { get; set; }

        public virtual List<CodeTask> SolvedTasks { get; set; }
 
        public virtual List<Tag> Tags { get; set; }

    }

    