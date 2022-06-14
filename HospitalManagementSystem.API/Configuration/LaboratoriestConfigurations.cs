using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class LaboratoriestConfigurations : IEntityTypeConfiguration<Laboratoriest>
    {
        public void Configure(EntityTypeBuilder<Laboratoriest> builder)
        {
            builder.Property(l => l.FirstName)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(l => l.MiddleName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(l => l.LastName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(l => l.GenderId)
                .IsRequired();

            builder.Property(l => l.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(l => l.Phone)
                .IsRequired();
         

            builder.Property(l => l.Email)
                .IsRequired()
                .HasMaxLength(50);
         
        }
    }
}
