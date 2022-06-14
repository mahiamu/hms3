using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Laboratorists
{
    public class LaboratoristDisplayDto: LaboratoriestFormDto
    {
        
        public int Id { get; set; }
        
       
    }
}
