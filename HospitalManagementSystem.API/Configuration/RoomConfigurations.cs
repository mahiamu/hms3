using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class RoomConfigurations : IEntityTypeConfiguration<Room>
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
               
               .HasMaxLength(30);
            builder.Property(r => r.Code)
               
               .HasMaxLength(30);
            builder.Property(r => r.Description)
               
               .HasMaxLength(30);
             }

        }
    }
