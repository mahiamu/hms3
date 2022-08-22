using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Gender Gender { get; set; }
        public int GenderId { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
        public int MaritalStatusId { get; set; }

        public Language Language { get; set; }
        public int LanguageId { get; set; }

        public EducationLevel EducationLevel { get; set; }
        public int EducationLevelId { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
        public PatientFile PatientFile { get; set; }

        public bool is_decessed { get; set; }
        // public int PatientFileId { get; set; }

        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }
        public ICollection<Case> Cases { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }

        public Patient()
        {
            ResponsiblePersons = new Collection<ResponsiblePerson>();
            Cases = new Collection<Case>();
            Prescriptions = new Collection<Prescription>();
            Recommendations = new Collection<Recommendation>();
        }
    }
}
