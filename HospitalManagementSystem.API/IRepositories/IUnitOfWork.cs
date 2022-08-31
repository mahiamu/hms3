using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(); 

        IGenericRepository<AdmissionType> AdmissionTypes { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Language> Languages { get; }
        IGenericRepository<Occupation> Occupations { get; }
        IGenericRepository<EducationLevel> EducationLevels { get; }
        IGenericRepository<MaritalStatus> MaritalStatuses { get; }
        IGenericRepository<MedicalDepartment> MedicalDepartments { get; }
        IGenericRepository<Relationship> Relationships { get; }
        IGenericRepository<PaymentOption> PaymentOptions { get; }
        IGenericRepository<Gender> Genders { get; }
        IGenericRepository<Patient> Patients { get; }
        IGenericRepository<ResponsiblePerson> ResponsiblePersons { get; }
        IGenericRepository<EmployeeRole> EmployeeRoles { get; }
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<AppointmentDuration> AppointmentDurations { get; }
        IGenericRepository<Case> Cases { get; }
        IGenericRepository<Accountant> Accountants { get; }
        IGenericRepository<BloodGroup> BloodGroups { get; }
        IGenericRepository<Donor> Donors { get; }
        IGenericRepository<Pharmacist> Pharmacists { get; }
        IGenericRepository<Doctor> Doctors { get; }
        IGenericRepository<MedicineCategory> MedicineCategories { get; }
        IGenericRepository<MedicineStockHospital> MedicineStockHospitals { get; }
        IGenericRepository<Laboratoriest> Laboratoriests { get; }
        IGenericRepository<Receptionist> Receptionists { get; }
        IGenericRepository<Weekday> Weekdays { get; }
        IGenericRepository<Pathology> Pathologies { get; }
        IGenericRepository<WardType> WardTypes { get; }
        IGenericRepository<Nurse> Nurses { get; }
        IGenericRepository<Schedule> Schedules { get; }
        IGenericRepository<LaboratoryTestType> LaboratoryTestTypes { get; }
        IGenericRepository<Specialization> Specializations { get; }
        IGenericRepository<Vaccine> Vaccines { get; }
        IGenericRepository<Holiday> Holidays { get; }
        IGenericRepository<PatientFile> PatientFiles { get; }

        IGenericRepository<Recommendation> Recommendations { get; }
        IGenericRepository<LaboratoryTestCategory> LaboratoryTestCategories { get; }
        IGenericRepository<Prescription> Prescriptions { get; }
        IGenericRepository<Building> Buildings { get; }
        IGenericRepository<Room> Rooms { get; }
        IGenericRepository<Ward> Wards { get; }

        IGenericRepository<Admission> Admissions { get; }
        IGenericRepository<LabRequest> LabRequests { get; }



        IGenericRepository<Medication> Medications { get; }
        IGenericRepository<PatientSchedule> PatientSchedules { get; }
        IGenericRepository<BillSchedule> BillSchedules { get; }
        IGenericRepository<MedSupplier> MedSuppliers { get; }
        IGenericRepository<PharmacyMedStock> PharmacyMedStocks { get; }

    }
}
