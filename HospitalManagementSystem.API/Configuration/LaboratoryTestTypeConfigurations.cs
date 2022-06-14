using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class LaboratoryTestTypeConfigurations : IEntityTypeConfiguration<LaboratoryTestType>
    {
        public void Configure(EntityTypeBuilder<LaboratoryTestType> builder)
        {
            builder.Property(ltt => ltt.Name)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(ltt => ltt.Description)
                .HasMaxLength(255);
            builder.Property(ltt => ltt.Price)
                .IsRequired();

            builder.Property(ltt => ltt.LaboratoryTestCategoryId)
                .IsRequired();
        }
    }
}
