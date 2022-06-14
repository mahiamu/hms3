using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Receptionists
{
    public class ReceptionistFormDto
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
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

      

        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }


        public string ImageUrl{ get; set; }






    }
}
