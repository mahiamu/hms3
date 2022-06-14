using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class MedicalDepartment : BaseModel

    {    
       
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Pharmacist> Pharmacists { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Laboratoriest> Laboratoriests { get; set; }
        public ICollection<Nurse> Nurses { get; set; }

        public MedicalDepartment()
        {
            Employees = new Collection<Employee>();
            Pharmacists = new Collection<Pharmacist>();
            Doctors = new Collection<Doctor>();
            Laboratoriests = new Collection<Laboratoriest>();
            Nurses = new Collection<Nurse>();
        }
    }
}
