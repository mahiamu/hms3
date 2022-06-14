using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Pathologies
{
    public class PathologyFormDto
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
