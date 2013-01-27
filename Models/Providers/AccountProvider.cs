using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizCamp.Models.Providers
{
    public class AccountProvider : DatabaseInitializer
    {
        public void Register(User user)
        {
            user.IsApproved = true;
            user.UserId = Guid.NewGuid();
            db.Users.Add(user);

            db.SaveChanges();
            /*  MailMessage email = new MailMessage("art@gart.com", "artyomvirusnyak@gmail.com", "working", "cool");
              SmtpClient eClient = new SmtpClient();
              eClient.Send(email);*/
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