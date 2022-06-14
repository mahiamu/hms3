using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Employees
{
    public class EmployeeDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public int GenderId { get; set; }
        public int MaritalStatusId { get; set; }
        public int LanguageId { get; set; }
        public int EducationLevelId { get; set; }
        public int EmployeeRoleId { get; set; }
        public int MedicalDepartmentId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
    }
}
