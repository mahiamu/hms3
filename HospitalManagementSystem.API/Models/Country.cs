using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Country : BaseModel
    {
        public ICollection<Patient> Patients { get; set; }
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
        public ICollection<Employee> Employees { get; set; }
       

        public Country()
        {
            Employees = new Collection<Employee>();
            Patients = new Collection<Patient>();  
            ResponsiblePersons = new Collection<ResponsiblePerson>();
          
        }
    }
}
