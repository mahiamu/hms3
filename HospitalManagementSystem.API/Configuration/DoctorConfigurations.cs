using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.Phone)
                .IsRequired();

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.ImageUrl);

            builder.Property(d => d.GenderId)
                .IsRequired();
            builder.Property(d => d.MedicalDepartmentId)
                .IsRequired();
           
        }
    }
}
