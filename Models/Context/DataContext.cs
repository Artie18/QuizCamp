using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class DataContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<CodeTask> CodeTasks { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Tag> Tags { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CodeTask>()
                    .HasRequired(x => x.User)
                    .WithMany(y => y.Tasks)
                    .HasForeignKey(x => x.UserId)
                    .WillCascadeOnDelete(false);

        modelBuilder.Entity<CodeTask>()
                    .HasMany(x => x.LikedUsers)
                    .WithMany(x => x.LikedTasks)
                    .Map(
                        x =>
                            {
                                x.MapLeftKey("CodeTaskId");
                                x.MapRightKey("UserId");
                                x.ToTable("Likes");
                            });
                        

        modelBuilder.Entity<User>()
                    .HasMany(x => x.SolvedTasks)
                    .WithMany(x => x.SolvedUsers)
                    .Map(
                    x =>
                    {
                        x.ToTable("Solved");
                        x.MapLeftKey("CodeTaskId");
                        x.MapRightKey("UserId");
                    });
        
    }
}