using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class MedicineStockHospital: BaseModel
    {
        public Medication Medication { get; set; }
        public int MedicationId { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public MedSupplier MedSupplier { get; set; }
        public int MedSupplierId { get; set; }



      
      

    }
}
