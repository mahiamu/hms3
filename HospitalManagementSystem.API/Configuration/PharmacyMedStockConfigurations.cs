using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class PharmacyMedStockConfigurations : IEntityTypeConfiguration<PharmacyMedStock>
    {
        public void Configure(EntityTypeBuilder<PharmacyMedStock> builder)
        {
            builder.Property(ps => ps.Name)
               .IsRequired()
               .HasMaxLength(50);
            builder.Property(ps => ps.Description)

               .HasMaxLength(225);
            builder.Property(ps => ps.MedicationId)
                .IsRequired();

            builder.Property(ps => ps.BatchNumber)
                .IsRequired();
            builder.Property(ps => ps.ExpirationDate)
                .IsRequired();

            builder.Property(ps => ps.Price)
                .IsRequired();
            builder.Property(ps => ps.Quantity)
              .IsRequired();
            builder.Property(ps => ps.EmployeeId)
                .IsRequired();
            builder.Property(ps => ps.MedSupplierId)
               .IsRequired();
        }
    }
}
