using Byway.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Byway.Infrastructure.Persistence
{

    public class BywayDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>

    {
        public BywayDbContext(DbContextOptions<BywayDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );

        }
    }
}
