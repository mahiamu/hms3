using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class BuildingConfigurations : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.Property(b => b.Id)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(b => b.Name)
                .HasMaxLength(255);
            builder.Property(b => b.Code)
                .IsRequired()
               .HasMaxLength(255);
            builder.Property(b => b.Description)
              .HasMaxLength(255);
        }
    }
}
