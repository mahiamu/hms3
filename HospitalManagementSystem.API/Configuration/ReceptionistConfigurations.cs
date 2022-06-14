using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class ReceptionistConfigurations : IEntityTypeConfiguration<Receptionist>
    {
        public void Configure(EntityTypeBuilder<Receptionist> builder)
        {
            builder.Property(r => r.FirstName)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(r => r.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(50);

          builder.Property(r => r.GenderId)
               .IsRequired();
             




            builder.Property(r => r.Address)
                .IsRequired()
                .HasMaxLength(225);

            builder.Property(r => r.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(r => r.PhoneNumber)
                .IsRequired();
             



        }
    }
}
