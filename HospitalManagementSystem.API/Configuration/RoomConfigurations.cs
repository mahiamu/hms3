using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class WardConfigurations : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.Id)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.BuildingId)
                .IsRequired();
                
            builder.Property(r => r.FloorNumber)
               .IsRequired()
               .HasMaxLength(30);
            builder.Property(r => r.Code)
               .IsRequired()
               .HasMaxLength(30);
            builder.Property(r => r.Description)
               .IsRequired()
               .HasMaxLength(30);
             }

        }
    }
