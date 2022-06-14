using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public MedicalDepartment MedicalDepartment { get; set; }
        public int MedicalDepartmentId { get; set; }

        

        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }

        public Doctor()
        {
            Schedules = new Collection<Schedule>();
            Prescriptions = new Collection<Prescription>();
            Holidays = new Collection<Holiday>();
            Recommendations = new Collection<Recommendation>();
        }

    }
}
