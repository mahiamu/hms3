using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class ScheduleConfigurations : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(s => s.StartingTime)
                .IsRequired();
            builder.Property(s => s.FinishingTime)
                .IsRequired();

            builder.Property(s => s.DoctorId)
                .IsRequired();
            builder.Property(s => s.WeekdayId)
                .IsRequired();
            builder.Property(s => s.AppointmentDurationId)
                .IsRequired();
        }
    }
}
