using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class HolidayConfigurations : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.Property(h => h.StartDate)
                .IsRequired();
            builder.Property(h => h.EndDate)
                .IsRequired();
            builder.Property(h => h.EmployeeId)
               .IsRequired();
        }
    }
}
