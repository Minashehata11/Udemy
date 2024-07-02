using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.Core.Entities.Identity;

namespace Udemy.Repository.Data.Configurations
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
           // builder.HasOne(t=>t.AppUser).WithOne(t=>t.Trainer).HasForeignKey<Trainer>(t=>t.AppUserId);
        }
    }
}
