using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Laboratorists
{
    public class LaboratoriestFormDto
    {
       
        [Required]
          [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [Required]
        public int GenderId { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }
       
        public int MedicalDepartmentId { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
