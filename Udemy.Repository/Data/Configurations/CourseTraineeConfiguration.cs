using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities;

namespace Udemy.Repository.Data.Configurations
{
    public class CourseTraineeConfiguration : IEntityTypeConfiguration<CourseTrainee>
    {
        public void Configure(EntityTypeBuilder<CourseTrainee> builder)
        {
            builder.HasOne(ct => ct.Trainee).WithMany();
            builder.HasOne(ct=>ct.Course).WithMany();
            builder.HasKey(cl => new { cl.TraineeId, cl.CourseId });
        }
    }
}
