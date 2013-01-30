using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizCamp.Models.Membership;

namespace QuizCamp.Models.Providers
{
    public class AccountProvider : DatabaseInitializer
    {

        public bool Register(User user)
        {
            if (db.Users.FirstOrDefault(x => x.Username == user.Username) != null || db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
                return false;
            user.UserId = Guid.NewGuid();
            user.Roles.Add(new Role { RoleName = "user", RoleId = Guid.NewGuid() });
            db.Users.Add(user);
            EmailConfirmationService.SendConfirmationMarkerToEmail( user.UserId.ToString() ,user.Email);
            db.SaveChanges();
            return true;

        }

        public bool Verify(Guid id)
        {
            if (db.Users.Find(id) != null)
            {
                var user = db.Users.Find(id);
                user.IsApproved = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }


        public User GetById(Guid id)
        {
            return db.Users.Find(id);
        }

        public User FindByUserName(string name)
        {
            return db.Users.FirstOrDefault(x => x.Username == name);
        }

        public User GetLogedInUser()
        {
            return db.Users.FirstOrDefault(x => x.Username == WebSecurity.User.Identity.Name);
        }

        public bool SaveChanges()
        {
            db.SaveChanges();
            return true;
        }
}
}