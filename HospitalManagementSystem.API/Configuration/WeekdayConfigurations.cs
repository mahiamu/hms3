using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class WeekdayConfigurations : IEntityTypeConfiguration<Weekday>
    {
        public void Configure(EntityTypeBuilder<Weekday> builder)
        {
            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(w => w.Description)
                .HasMaxLength(255);
        }
    }
}