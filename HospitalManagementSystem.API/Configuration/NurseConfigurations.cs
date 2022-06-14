using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class NurseConfigurations : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.Property(n => n.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(n => n.MiddleName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(n => n.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(n => n.Address)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(n => n.PhoneNumber)
                .IsRequired();
            builder.Property(n => n.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(n => n.ImageUrl)
                .IsRequired();
            builder.Property(n => n.GenderId)
                .IsRequired();
            builder.Property(n => n.MedicalDepartmentId)
                .IsRequired();
                
        }
    }
}
