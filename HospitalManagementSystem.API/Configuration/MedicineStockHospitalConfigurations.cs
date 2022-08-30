using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedicineStockHospitalConfigurations : IEntityTypeConfiguration<MedicineStockHospital>
    {
        public void Configure(EntityTypeBuilder<MedicineStockHospital> builder)
        {

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(m => m.Description)

               .HasMaxLength(225);
            builder.Property(m => m.MedicationId)
                .IsRequired();

            builder.Property(m => m.BatchNumber)
                .IsRequired();
            builder.Property(m => m.ExpirationDate)
                .IsRequired();

            builder.Property(m => m.Quantity)
                .IsRequired();
            builder.Property(m => m.EmployeeId)
                .IsRequired();
            builder.Property(m => m.MedSupplierId)
               .IsRequired();
        }
    }
}
