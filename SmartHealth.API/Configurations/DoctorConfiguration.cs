using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth.API.Entities;

namespace SmartHealth.API.Configurations
{
    public class DoctorConfiguration
        : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(
            EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.LicenseNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Specialization)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.HospitalName)
                .HasMaxLength(200);

            builder.HasIndex(d => d.LicenseNumber)
                .IsUnique();

            builder.HasIndex(d => d.UserId)
                .IsUnique();

            builder.HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}