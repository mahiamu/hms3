using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Age)
                .IsRequired();

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Phone)
                .IsRequired();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(p => p.GenderId)
                .IsRequired();

            builder.Property(p => p.MaritalStatusId)
                .IsRequired();

            builder.Property(p => p.LanguageId)
                .IsRequired();

            builder.Property(p => p.EducationLevelId)
                .IsRequired();

            builder.Property(p => p.CityId)
                .IsRequired();

            builder.Property(p => p.CountryId)
                .IsRequired();
        }
    }
}
