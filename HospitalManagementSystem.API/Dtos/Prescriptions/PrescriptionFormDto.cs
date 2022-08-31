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
        public int PatientId { get; set; }
      
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int AdmissionId { get; set; }
        public String prescriptionSubject { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public String prescriptionDetail { get; set; }
       
        public bool Is_Cancelled { get; set; }

        [Required]
        public int MedicationId { get; set; }

    }
}
