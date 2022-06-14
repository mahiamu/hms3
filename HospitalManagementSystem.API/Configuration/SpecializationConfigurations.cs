using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class SpecializationConfigurations : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Specialization> builder)
        {
            builder.Property(s => s.Name)
              .IsRequired()
              .HasMaxLength(30);
            builder.Property(s => s.Description)
                .HasMaxLength(225);
        }
    }
}
