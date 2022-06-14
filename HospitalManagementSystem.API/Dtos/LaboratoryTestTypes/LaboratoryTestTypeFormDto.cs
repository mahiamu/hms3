using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.LaboratoryTestTypes
{
    public class LaboratoryTestTypeFormDto
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public int LaboratoryTestCategoryId { get; set; }
    }
}
