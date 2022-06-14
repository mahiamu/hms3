using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Employees
{
    public class EmployeeFormDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public int MaritalStatusId { get; set; }

        [Required]
        public int LanguageId { get; set; }

        [Required]
        public int EducationLevelId { get; set; }

        [Required]
        public int EmployeeRoleId { get; set; }

        [Required]
        public int MedicalDepartmentId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
