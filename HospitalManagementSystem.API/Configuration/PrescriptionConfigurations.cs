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

            builder.Property(pr => pr.OrderDate)
            .IsRequired();


            builder.Property(pr => pr.AdmissionId)
            .IsRequired();



            builder.Property(pr => pr.MedicationId)
            .IsRequired();

            builder.Property(pr => pr.PatientId)
            .IsRequired();

            builder.Property(pr => pr.EmployeeId)
            .IsRequired();


            builder.Property(pr => pr.Is_Cancelled)
            .HasDefaultValue(false);


        }
    }
}
