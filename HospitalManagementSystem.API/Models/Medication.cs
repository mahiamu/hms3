using HospitalManagementSystem.API.Models.Base;

namespace HospitalManagementSystem.API.Models
{
    public class Medication :BaseModel
    {
       
        public MedicineCategory  MedicineCategory { get; set; }
        public int MedicineCategoryId { get; set; }

      



    }
}
