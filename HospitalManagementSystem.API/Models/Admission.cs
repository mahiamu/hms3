using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public int AdmissionTypeId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public Ward Ward { get; set; }
        public int WardId { get; set; }
        public DateTime AdmissionTime { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public bool IsDischarge { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Ward> Wards { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public Admission()
        {
            Prescriptions = new Collection<Prescription>();
            Patients = new Collection<Patient>();
            Employees = new Collection<Employee>();
            Rooms = new Collection<Room>();
            Wards = new Collection<Ward>();
                 }
        }
}
