using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.API.Dtos.Medications
{
    public class MedicationFormDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

       
        [StringLength(225)]

        public string Description { get; set; }


        [Required]
        
        public int MedicineCategoryId { get; set; }

        
    }

}
