using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class LabRequestConfiguration : IEntityTypeConfiguration<LabRequest>
    {
        public void Configure(EntityTypeBuilder<LabRequest> builder)
        {
            builder.Property(lr => lr.Id)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(lr => lr.AdmissionId)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(lr => lr.OrderedDate)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(lr => lr.LaboratoryTestTypeId)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(lr => lr.Result)
              
              .HasMaxLength(50);
            builder.Property(lr => lr.Remark)
              
              .HasMaxLength(50);
            builder.Property(lr => lr.Priority)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(lr => lr.IsCancelled)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(lr => lr.IsPaid)
                .HasDefaultValue(false);
            builder.Property(lr => lr.EmployeeId)
              .IsRequired()
              .HasMaxLength(50);
        }
    }
}
