using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string History { get; set; }
        public string Note { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
      //  public MedicineStockHospital Medicine { get; set; }
        //public int MedicineId { get; set; }




    }
}
