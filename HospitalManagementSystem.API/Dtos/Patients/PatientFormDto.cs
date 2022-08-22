using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.API.Dtos.Patients
{
    public class PatientFormDto
    {
       
        [MaxLength(50)]
        public string FirstName { get; set; }

    
        [MaxLength(50)]
        public string MiddleName { get; set; }

      
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
     
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }

        
        [MaxLength(50)]
        public string Email { get; set; }

        
        public int EducationLevelId { get; set; }

     
        public string Address { get; set; }

       
        public int CountryId { get; set; }

       
        public int CityId { get; set; }

        
        public int GenderId { get; set; }

       
        public int MaritalStatusId { get; set; }

       
        public int LanguageId { get; set; }

        public bool is_decessed { get; set; }
    }
}
