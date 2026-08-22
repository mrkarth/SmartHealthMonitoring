using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth.API.Entities;

namespace SmartHealth.API.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BloodGroup)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.EmergencyContactName)
                .HasMaxLength(100);

            builder.Property(p => p.EmergencyContactPhone)
                .HasMaxLength(20);

            builder.Property(p => p.Address)
                .HasMaxLength(500);

            builder.HasIndex(p => p.UserId)
                .IsUnique();

            builder.HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
