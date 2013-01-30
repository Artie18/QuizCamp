namespace QuizCamp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            context.Tags.AddOrUpdate( new Tag{ Name = "super", TagId = new Guid()});
            /*
	  
            context.Users.FirstOrDefault(x => x.Username == "qwerty").Roles.Add(context.Roles.FirstOrDefault(y => y.RoleName == "admin"));

	
*/
            /*
	      foreach (var user in context.Users.ToList())
            {
                user.Roles.Add(new Role { RoleName = "user", RoleId = Guid.NewGuid() });
            }
	
*/
            context.Roles.Add(new Role { RoleName = "admin", RoleId = Guid.NewGuid() });
            context.Roles.Add(new Role { RoleName = "user", RoleId = Guid.NewGuid() });
            context.SaveChanges();
            
        }
    }
}
