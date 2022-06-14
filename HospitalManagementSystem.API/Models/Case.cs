using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Case
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string CaseDetail { get; set; }



    }
}
