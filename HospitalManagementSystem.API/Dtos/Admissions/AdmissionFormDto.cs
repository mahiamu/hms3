using HospitalManagementSystem.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.API.Dtos.Admissions
{
    public class AdmissionFormDto
    {
        public int Id { get; set; }
        [Required]
        public int AdmissionTypeId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int WardId { get; set; }
        public DateTime AdmissionTime { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public bool IsDischarge { get; set; }
    }
}
