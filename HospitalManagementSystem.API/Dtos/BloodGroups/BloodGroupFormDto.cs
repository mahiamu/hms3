using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.BloodGroups
{
    public class BloodGroupFormDto
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
