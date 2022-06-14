using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class LaboratoryTestCategoryConfigurations : IEntityTypeConfiguration<LaboratoryTestCategory>
    {
        public void Configure(EntityTypeBuilder<LaboratoryTestCategory> builder)
        {
            builder.Property(ltc => ltc.Name)
              .IsRequired()
              .HasMaxLength(15);

            builder.Property(ltc => ltc.Description)
                .HasMaxLength(255);
        }
    }
}
