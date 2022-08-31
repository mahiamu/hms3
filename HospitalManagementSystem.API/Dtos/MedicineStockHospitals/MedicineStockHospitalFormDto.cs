using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.MedicineStockHospitals
{
    public class MedicineStockHospitalFormDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(225)]

        public String Description{ get; set; }
        [Required]
        public int MedicationId { get; set; }
        [Required]
        public string BatchNumber { get; set; }
        [Required]
        public int Quantity { get; set; }

      

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int MedSupplierId { get; set; }
        public DateTime TimeSatamp { get; set; }


    }
}
