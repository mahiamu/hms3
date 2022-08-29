using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Admission Admission { get; set; }
        public int AdmissionId { get; set; }
        public String prescriptionSubject { get; set; }
        public DateTime OrderDate { get; set; }
        public String prescriptionDetail { get; set; }
        public bool Is_Cancelled { get; set; }

        public Medication Medication { get; set; }
        public int MedicationId { get; set; }

      
      
      
      





    }
}
