﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.MedicineCategories
{
    public class MedicineCategoryFormDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
