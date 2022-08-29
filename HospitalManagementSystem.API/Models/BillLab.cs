using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class BillLab
    {
        public int Id { get; set; }
        public LabRequest LabRequest { get; set; }
        public int LabRequestId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public BillLab()
        {
            Employees = new Collection<Employee>();
        }

        }
}
