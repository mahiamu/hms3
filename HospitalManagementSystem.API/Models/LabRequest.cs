using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class LabRequest
    {
        public int Id { get; set; }
        public Admission Admission { get; set; }
        public int AdmissionId { get; set; }
        public DateTime OrderedDate { get; set; }
        public  LaboratoryTestType LaboratoryTestType { get; set; }
        public int LaboratoryTestTypeId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public string Result { get; set; }
        public string Remark { get; set; }
        public string Priority { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsPaid { get; set; }=false;
        public ICollection<Admission> Admissions { get; set; }
       
        public ICollection<Employee> Employees { get; set; }
        public LabRequest()
        {
            Admissions = new Collection<Admission>();
            Employees = new Collection<Employee>();
         }
      }
}
