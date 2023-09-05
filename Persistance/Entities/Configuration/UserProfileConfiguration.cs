using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Entities.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(a => a.Age).HasDefaultValue(18);
            builder.ToTable(t => t.HasCheckConstraint("Age", "Age > 0 AND Age < 100"));
            builder.Property(p => p.Phone).HasDefaultValue("Нет");
        }
    }
}
