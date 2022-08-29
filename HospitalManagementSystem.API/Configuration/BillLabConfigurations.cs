using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class BillLabConfigurations : IEntityTypeConfiguration<BillLab>
    {
        public void Configure(EntityTypeBuilder<BillLab> builder)
        {
            builder.Property(bl => bl.Id)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(bl => bl.LabRequestId)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(bl => bl.Amount)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(bl => bl.Date)
              .IsRequired()
              .HasMaxLength(50);
            builder.Property(bl => bl.Description)
              .HasMaxLength(50);
            builder.Property(bl => bl.EmployeeId)
              .IsRequired()
              .HasMaxLength(50);
        }
    }
}
