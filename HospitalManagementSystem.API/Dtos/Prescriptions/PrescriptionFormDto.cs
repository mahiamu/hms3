using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Prescriptions
{
    public class PrescriptionFormDto
    {
        [Required]
        public DateTime Date { get; set; }

        public string History { get; set; }

        public string Note { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int MedicineId { get; set; }

    }
}
