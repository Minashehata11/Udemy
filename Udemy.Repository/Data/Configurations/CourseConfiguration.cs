using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Repository.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(c => c.AppUser).WithMany().HasForeignKey(c => c.AppUserId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
