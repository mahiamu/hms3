using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class RelationshipConfigurations : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            builder.Property(at => at.Name)
                 .IsRequired()
                 .HasMaxLength(30);

            builder.Property(at => at.Description)
                .HasMaxLength(255);
        }
    }
}
