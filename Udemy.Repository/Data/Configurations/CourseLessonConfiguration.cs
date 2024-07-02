using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Repository.Data.Configurations
{
    public class CourseLessonConfiguration : IEntityTypeConfiguration<CourseLesson>
    {
        public void Configure(EntityTypeBuilder<CourseLesson> builder)
        {
            builder.HasOne(c=>c.Course).WithMany().HasForeignKey(c=>c.CourseId);    
        }
    }
}
