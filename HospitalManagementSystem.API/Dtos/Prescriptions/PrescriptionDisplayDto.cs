using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Prescriptions
{
    public class PrescriptionDisplayDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string History { get; set; }
        public string Note { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int MedicineId { get; set; }
    }
}
