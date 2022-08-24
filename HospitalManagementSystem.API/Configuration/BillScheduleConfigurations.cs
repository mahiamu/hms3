using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class BillScheduleConfigurations : IEntityTypeConfiguration<BillSchedule>
    {
    
public void Configure(EntityTypeBuilder<BillSchedule> builder)
        {
            builder.Property(ps => ps.PatientScheduleId)

               .IsRequired();

            builder.Property(ps => ps.EmployeeId)

                  .IsRequired();
            builder.Property(ps => ps.PatientScheduleId)

               .IsRequired();

            builder.Property(ps => ps.Amount)

                  .IsRequired();
        }
    }
}
