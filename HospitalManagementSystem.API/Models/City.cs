using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class City : BaseModel
    {
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }

        public City()
        {
            Patients = new Collection<Patient>();
            ResponsiblePersons = new Collection<ResponsiblePerson>();
            Employees = new Collection<Employee>();
        }
    }
}
