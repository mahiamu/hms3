using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class DonorConfigurations : IEntityTypeConfiguration<Donor>
    {
        public void Configure(EntityTypeBuilder<Donor> builder)
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

            builder.Property(d => d.Age)
                .IsRequired()
                .HasMaxLength(3);
            builder.Property(d => d.GenderId)
               .IsRequired();

            builder.Property(d => d.BloodGroupId)
               .IsRequired();
      
            builder.Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastDonated)
             .IsRequired();
            

        }
    }
}
