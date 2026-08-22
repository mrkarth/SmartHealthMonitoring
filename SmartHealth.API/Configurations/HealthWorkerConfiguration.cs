using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth.API.Entities;

namespace SmartHealth.API.Configurations
{
    public class HealthWorkerConfiguration
        : IEntityTypeConfiguration<HealthWorker>
    {
        public void Configure(
            EntityTypeBuilder<HealthWorker> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.EmployeeId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.Department)
                .HasMaxLength(100);

            builder.Property(h => h.FacilityName)
                .HasMaxLength(200);

            builder.HasIndex(h => h.EmployeeId)
                .IsUnique();

            builder.HasIndex(h => h.UserId)
                .IsUnique();

            builder.HasOne(h => h.User)
                .WithOne(u => u.HealthWorker)
                .HasForeignKey<HealthWorker>(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}