using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class PatientFileConfigurations : IEntityTypeConfiguration<PatientFile>
    {
        public void Configure(EntityTypeBuilder<PatientFile> builder)
        {
            builder.Property(pf => pf.PatientId)
                 .IsRequired();


            builder.Property(pf => pf.FileURL)
                 .IsRequired();

        }
    }
}
