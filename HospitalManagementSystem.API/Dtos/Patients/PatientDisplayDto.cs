using HospitalManagementSystem.API.Dtos.Countries;
using System;

namespace HospitalManagementSystem.API.Dtos.Patients
{
    public class PatientDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int LanguageId { get; set; }
        public int EducationLevelId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
    }
}
