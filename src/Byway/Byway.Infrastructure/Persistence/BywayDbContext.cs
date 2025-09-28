using Byway.Domain.Entities;
using Byway.Domain.Enums;
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
            builder.Entity<IdentityRole<Guid>>().HasData(
            new IdentityRole<Guid>
            {
                Id = Guid.Parse("cfb238c0-3c51-4119-b324-b1150dd98bf8"), // fixed GUID
                Name = UserRole.Admin.ToString(),
                NormalizedName = UserRole.Admin.ToString().ToUpper()
            },
            new IdentityRole<Guid>
            {
                Id = Guid.Parse("b408abe1-762c-4af3-83ab-a6a0d9f8339c"), // fixed GUID
                Name = UserRole.User.ToString(),
                NormalizedName = UserRole.User.ToString().ToUpper()
            }
        );

            builder.Entity<AppUser>()
            .HasIndex(u => u.Email)
            .IsUnique();

            builder.Entity<AppUser>()
            .HasIndex(u => u.UserName)
            .IsUnique();


        }
    }
}
