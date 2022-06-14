using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Gender : BaseModel
    {
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Accountant> Accountants { get; set; }
        public ICollection<Pharmacist> Pharmacists { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Donor> Donors { get; set; }
        public ICollection<Receptionist> Receptionists { get; set; }
        public ICollection<Nurse> Nurses { get; set; }

        public Gender()
        {
            Patients = new Collection<Patient>();
            Employees = new Collection<Employee>();
            Accountants = new Collection<Accountant>();
            Donors = new Collection<Donor>();
            Pharmacists = new Collection<Pharmacist>();
            Doctors = new Collection<Doctor>();
           Receptionists= new Collection<Receptionist>();
            Nurses = new Collection<Nurse>();
        }
    }
}
