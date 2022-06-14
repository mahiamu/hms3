﻿using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedicalDepartmentConfigurations : IEntityTypeConfiguration<MedicalDepartment>
    {
        public void Configure(EntityTypeBuilder<MedicalDepartment> builder)
        {
            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(at => at.Description)
                .HasMaxLength(255);
           
        }
    }
}
