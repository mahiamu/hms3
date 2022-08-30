using HospitalManagementSystem.API.Models.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Medication :BaseModel
    {
       
        public MedicineCategory  MedicineCategory { get; set; }
        public int MedicineCategoryId { get; set; }
        public MedicineStockHospital MedicineStockHospital{ get; set; }



        public ICollection<Prescription> Prescriptions { get; set; }
        public Medication()
        {
            Prescriptions = new Collection<Prescription>();

        }

        }
}
