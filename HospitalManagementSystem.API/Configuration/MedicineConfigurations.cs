using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedicineConfigurations : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(m => m.PurchasePrice)
                .IsRequired();
            builder.Property(m => m.GenericName)
                .HasMaxLength(50);
            builder.Property(m => m.Effects)
                .IsRequired();
            builder.Property(m => m.ExpirationDate)
                .IsRequired();

            builder.Property(m => m.MedicineCategoryId)
                .IsRequired();
            builder.Property(m => m.CountryId)
                .IsRequired();
        }
    }
}
