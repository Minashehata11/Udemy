using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Udemy.Core.Entities;
using Udemy.Core.Entities.Identity;

namespace Udemy.Repository.Data
{
    public class UdemyDbContext:IdentityDbContext<AppUser>
    {
        public UdemyDbContext(DbContextOptions<UdemyDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
        }

        public DbSet<trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<CourseTrainee> CourseTrainees { get; set; }

    }
}
