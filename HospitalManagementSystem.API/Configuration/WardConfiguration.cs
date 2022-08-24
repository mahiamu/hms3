using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.Name)
                .HasMaxLength(255);
            builder.Property(p => p.BuildingNumberId)
               .IsRequired()
               .HasMaxLength(15);
            builder.Property(p => p.FloorNumber)
               .HasMaxLength(255);
            builder.Property(p => p.WardTypeId)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(p => p.Isprivate)
              .HasMaxLength(255);
            builder.Property(p => p.Code)
             .HasMaxLength(255);
        }
    }
}
