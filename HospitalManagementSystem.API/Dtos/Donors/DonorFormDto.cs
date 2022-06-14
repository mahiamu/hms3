using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Donors
{
    public class DonorFormDto
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

        [Required]
        public int GenderId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }


        [Required]
        public int BloodGroupId { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

      
        [MaxLength(50)]
        public string EmailAddress { get; set; }


        [Required]
        public int Age { get; set; }



        [Required]
  
        public DateTime LastDonated { get; set; }


    }
}
