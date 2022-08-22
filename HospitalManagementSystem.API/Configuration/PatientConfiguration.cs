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
             
                .HasMaxLength(50);

            builder.Property(p => p.MiddleName)
               
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
               
                .HasMaxLength(50);

            builder.Property(p => p.Age);
                
            builder.Property(p => p.Address)
                
                .HasMaxLength(255);

            builder.Property(p => p.Phone)
                .IsRequired();

            builder.Property(p => p.Email)
                
                .HasMaxLength(50);


            builder.Property(p => p.GenderId);


            builder.Property(p => p.MaritalStatusId);


            builder.Property(p => p.LanguageId);


            builder.Property(p => p.EducationLevelId);

            builder.Property(p => p.CityId);


            builder.Property(p => p.CountryId);



            builder.Property(p => p.is_decessed);
        }
    }
}
