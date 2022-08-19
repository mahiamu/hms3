using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class RecommendationConfigurations : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.Property(r => r.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.EmployeeId)
                .IsRequired();
            builder.Property(r => r.PatientId)
                .IsRequired();
        }
    }
}
