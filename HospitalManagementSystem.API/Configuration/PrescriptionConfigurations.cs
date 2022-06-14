using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Configuration
{
    public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {

            builder.Property(pr => pr.Date)
            .IsRequired();

            builder.Property(pr => pr.History);

            builder.Property(pr => pr.Note);

            builder.Property(pr => pr.MedicineId)
            .IsRequired();

            builder.Property(pr => pr.PatientId)
            .IsRequired();

            builder.Property(pr => pr.DoctorId)
            .IsRequired();


        }
    }
}
