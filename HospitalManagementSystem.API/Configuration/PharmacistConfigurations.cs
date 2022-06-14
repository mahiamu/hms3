using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class PharmacistConfigurations : IEntityTypeConfiguration<Pharmacist>
    {
        public void Configure(EntityTypeBuilder<Pharmacist> builder)
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

            builder.Property( p=> p.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Phone)
                .IsRequired();

            builder.Property(p => p.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.MedicalDepartmentId);

            builder.Property(e => e.GenderId)
                .IsRequired();

        }
    }
}
