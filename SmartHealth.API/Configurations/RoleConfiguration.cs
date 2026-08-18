using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth.API.Entities;

namespace SmartHealth.API.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(r => r.RoleName).IsUnique();

        }
    }
}

