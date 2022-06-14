using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.PatientFiles
{
    public class PatientFilesFormDto
    {
      



        [Required]
        public int PatientId { get; set; }

        [Required]
        public string FileURL { get; set; }
    }
}
