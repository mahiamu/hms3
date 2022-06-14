using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class EmployeeRoleConfigurations : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(at => at.Description)
                .HasMaxLength(255);
        }
    }
}
