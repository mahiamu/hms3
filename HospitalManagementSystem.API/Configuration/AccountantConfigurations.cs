using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class AccountantConfigurations : IEntityTypeConfiguration<Accountant>
    {
        public void Configure(EntityTypeBuilder<Accountant> builder)
        {
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(a => a.Phone)
                .IsRequired();
            builder.Property(a => a.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.ImageUrl)
                 .IsRequired();
            builder.Property(a => a.GenderId)
                .IsRequired();
       
            

        }
    }
}
