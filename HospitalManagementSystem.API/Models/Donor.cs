using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public int BloodGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }

        public DateTime LastDonated { get; set; }

    }
}
