using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Recommendations
{
    public class RecommendationFormDto
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}
