using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class ResponsiblePersonConfigurations : IEntityTypeConfiguration<ResponsiblePerson>
    {
        public void Configure(EntityTypeBuilder<ResponsiblePerson> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.CountryId)
                .IsRequired();

            builder.Property(p => p.CityId)
                .IsRequired();

            builder.Property(p => p.RelationshipId)
                .IsRequired();

            builder.Property(p => p.PatientId)
                .IsRequired();
        }
    }
}