using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class PatientFile
    {
        public int Id { get; set; }
        public Patient Patient{ get; set; }
        public int PatientId { get; set; }
        public string FileURL { get; set; }
    }
}
