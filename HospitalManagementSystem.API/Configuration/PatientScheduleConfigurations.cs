using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class PatientScheduleConfigurations : IEntityTypeConfiguration<PatientSchedule>
    {
        public void Configure(EntityTypeBuilder<PatientSchedule> builder)
        {
            builder.Property(ps => ps.PatientId)

                .IsRequired();

           builder.Property(ps=> ps.AdmissionTypeId)

                 .IsRequired();

            builder.Property(ps => ps.RoomId)

               .IsRequired();


            builder.Property(ps => ps.EmployeeId)
                .IsRequired();

            builder.Property(ps => ps.Is_Payed)
                .HasDefaultValue(false);



            builder.Property(ps => ps.Is_Dismissed)
                .HasDefaultValue(false);

           builder.Property(ps => ps.Is_Confirmed)
                 .HasDefaultValue(false);



            builder.Property(ps => ps.ScheduleDate)
                 .IsRequired();



            builder.Property(ps => ps.ScheduleTime)

             .IsRequired();






        }
    }
}
