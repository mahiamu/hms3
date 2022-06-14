using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class BedTypeConfigurations : IEntityTypeConfiguration<BedType>
    {
        public void Configure(EntityTypeBuilder<BedType> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(15);
            builder.Property(b => b.Description)
                .HasMaxLength(255);
            builder.Property(b => b.Price)
                .IsRequired();
        }
    }
}
