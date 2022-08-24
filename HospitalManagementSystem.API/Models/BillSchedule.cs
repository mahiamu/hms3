using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class BillSchedule
    {
        public int Id { get; set; }
        public PatientSchedule PatientSchedule { get; set; }

        public int PatientScheduleId{ get; set; }

        public float Amount { get; set; }

        public DateTime Date  { get; set; }

        public int EmployeeId { get; set; }

        public ICollection<PatientSchedule> PatientSchedules { get; set; }
        public ICollection<Employee> Employees { get; set; }
       

        public BillSchedule()
        {
            PatientSchedules = new Collection<PatientSchedule>();
            ;
            Employees = new Collection<Employee>();
        }


    }
}
