using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HospitalManagementSystem.API.Dtos.Accountants
{
    public class AccountantFormDto
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
        [MaxLength(255)]

        public string Address { get; set; }

        [Required]
        [MaxLength(30)]

        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(30)]

        public string Phone { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int GenderId { get; set; }

    }
}
