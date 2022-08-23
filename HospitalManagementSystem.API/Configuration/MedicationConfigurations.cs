using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedicationConfigurations : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            builder.Property(md => md.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(md => md.Description)
                .HasMaxLength(255);

            builder.Property(md => md.MedicineCategoryId)
               .IsRequired();
              

           
        }
    }
}
