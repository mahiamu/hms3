using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string EmailAddress { get; set; }

        public Gender Gender { get; set; }
        public int GenderId { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
        public int MaritalStatusId { get; set; }

        public Language Language { get; set; }
        public int LanguageId { get; set; }

        public EducationLevel EducationLevel { get; set; }
        public int EducationLevelId { get; set; }

        public EmployeeRole EmployeeRole { get; set; }
        public int EmployeeRoleId { get; set; }

        public MedicalDepartment MedicalDepartment { get; set; }
        public int MedicalDepartmentId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Holiday> Holidays { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
        public ICollection<PatientSchedule> PatientSchedules { get; set; }
        public ICollection<BillSchedule> BillSchedules { get; set; }
        public ICollection<MedicineStockHospital> MedicineStockHospitals { get; set; }
        public ICollection<PharmacyMedStock> PharmacyMedStocks { get; set; }
        public ICollection<LabRequest> LabRequests { get; set; }
        public ICollection<Admission> Admissions { get; set; }


        public Employee()
        {
            Admissions= new Collection<Admission>();
            LabRequests = new Collection<LabRequest>();
            PharmacyMedStocks = new Collection<PharmacyMedStock>();

            MedicineStockHospitals = new Collection<MedicineStockHospital>();
            Schedules = new Collection<Schedule>();
            Prescriptions = new Collection<Prescription>();
            Holidays = new Collection<Holiday>();
            Recommendations = new Collection<Recommendation>();
            PatientSchedules = new Collection<PatientSchedule>();
            BillSchedules = new Collection<BillSchedule>(); 
        }

    }
}
