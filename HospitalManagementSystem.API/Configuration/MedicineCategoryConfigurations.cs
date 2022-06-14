using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedicineCategoryConfigurations : IEntityTypeConfiguration<MedicineCategory>
    {
        public void Configure(EntityTypeBuilder<MedicineCategory> builder)
        {
            builder.Property(mc => mc.Name)
            .IsRequired()
            .HasMaxLength(20);
            builder.Property(mc => mc.Description)
                .HasMaxLength(225);
        }
    }
}
