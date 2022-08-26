using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class AdmissionConfigurations : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder.Property(a => a.Id)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.AdmissionTypeId)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.PatientId)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.EmployeeId)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.RoomId)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.WardId)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.AdmissionTime)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.AdmissionDate)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.DischargeDate)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.IsDischarge)
                .IsRequired()
                .HasMaxLength(50);
         }
        }
}
