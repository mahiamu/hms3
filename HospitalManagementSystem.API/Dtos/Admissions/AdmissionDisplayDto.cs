using HospitalManagementSystem.API.Models;
using System;

namespace HospitalManagementSystem.API.Dtos.Admissions
{
    public class AdmissionDisplayDto
    {
        public int Id { get; set; }
        public int AdmissionTypeId { get; set; }
       
        public int PatientId { get; set; }
       
        public int EmployeeId { get; set; }
       
        public int RoomId { get; set; }
       
        public int WardId { get; set; }
        public DateTime AdmissionTime { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public bool IsDischarge { get; set; }
    }
}
