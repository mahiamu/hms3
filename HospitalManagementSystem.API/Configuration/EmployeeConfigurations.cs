using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(e => e.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Age)
                .IsRequired();
               

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Phone)
                .IsRequired();

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.GenderId)
                .IsRequired();

            builder.Property(e => e.MaritalStatusId)
                .IsRequired();

            builder.Property(e => e.LanguageId)
                .IsRequired();

            builder.Property(e => e.EducationLevelId)
                .IsRequired();

            builder.Property(e => e.EmployeeRoleId)
                .IsRequired();

            builder.Property(e => e.MedicalDepartmentId)
                .IsRequired();

            builder.Property(e => e.CityId)
                .IsRequired();

            builder.Property(e => e.CountryId)
                .IsRequired();


        }
    }
}
