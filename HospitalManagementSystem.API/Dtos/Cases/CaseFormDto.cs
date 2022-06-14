using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Cases
{
    public class CaseFormDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public string CaseDetail { get; set; }
    }
}
