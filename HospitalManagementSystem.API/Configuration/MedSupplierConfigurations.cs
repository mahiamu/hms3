using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalManagementSystem.API.Configuration
{
    public class MedSupplierConfigurations : IEntityTypeConfiguration<MedSupplier>
    {
        public void Configure(EntityTypeBuilder<MedSupplier> builder)
        {

            builder.Property(ms => ms.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(ms => ms.Description)

               .HasMaxLength(225);
            builder.Property(ms => ms.Address)
                .IsRequired();

            builder.Property(ms => ms.PhoneNumber)
                .IsRequired();
           
        }
    }
}
