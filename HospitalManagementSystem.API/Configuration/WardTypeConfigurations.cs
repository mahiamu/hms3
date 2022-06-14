using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class WardTypeConfigurations : IEntityTypeConfiguration<WardType>
    {
        public void Configure(EntityTypeBuilder<WardType> builder)
        {
            builder.Property(wt => wt.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(wt => wt.Description)
                .HasMaxLength(255);

            builder.Property(wt => wt.Price)
                .IsRequired();
        }
    }
}
