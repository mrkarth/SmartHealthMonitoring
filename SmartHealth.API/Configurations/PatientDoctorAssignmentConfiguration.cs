using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHealth.API.Entities;

namespace SmartHealth.API.Configurations
{
    public class PatientDoctorAssignmentConfiguration
        : IEntityTypeConfiguration<PatientDoctorAssignment>
    {
        public void Configure(
            EntityTypeBuilder<PatientDoctorAssignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.DoctorAssignments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.PatientAssignments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new
            {
                a.PatientId,
                a.DoctorId,
                a.AssignedAt
            });
        }
    }
}