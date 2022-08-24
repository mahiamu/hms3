using HospitalManagementSystem.API.IRepositories;
using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<AdmissionType> _admissionTypes;
        private IGenericRepository<City> _cities;
        private IGenericRepository<Language> _languages;
        private IGenericRepository<Occupation> _occupations;
        private IGenericRepository <EducationLevel> _educationLevels;
        private IGenericRepository<MaritalStatus> _maritalStatuses;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Relationship> _relationships;
        private IGenericRepository<PaymentOption> _paymentOptions;
        private IGenericRepository<MedicalDepartment> _medicalDepartments;
        private IGenericRepository<Gender> _genders;
        private IGenericRepository<Patient> _patients;
        private IGenericRepository<ResponsiblePerson> _responsiblePersons;
        private IGenericRepository<EmployeeRole> _employeeRoles;
        private IGenericRepository<Employee> _employees;
        private IGenericRepository<AppointmentDuration> _appointmentDurations;
        private IGenericRepository<Receptionist> _receptionists;
        private IGenericRepository<Case> _cases;
        private IGenericRepository<Accountant> _accountants;
        private IGenericRepository<BloodGroup> _bloodgroups;
        private IGenericRepository<Donor> _donors;
        private IGenericRepository<Pharmacist> _pharmacists;
        private IGenericRepository<Doctor> _doctors;
        private IGenericRepository<MedicineCategory> _medicinecategories;
        private IGenericRepository<Medicine> _medicines;
        private IGenericRepository<Laboratoriest> _laboratoriests;
        private IGenericRepository<Weekday> _weekdays;

        private IGenericRepository<Pathology> _pathologies;
        private IGenericRepository<WardType> _wardtypes;
        private IGenericRepository<PatientFile> _patientFiles;
        private IGenericRepository<Nurse> _nurses;
        private IGenericRepository<Schedule> _schedules;
        private IGenericRepository<LaboratoryTestType> _laboratorytesttypes;
        private IGenericRepository<Vaccine> _vaccines;
        private IGenericRepository<Specialization> _specializations;
        private IGenericRepository<Holiday> _holidays;
       
        private IGenericRepository<Recommendation> _recommendations;
        
        private IGenericRepository<LaboratoryTestCategory> _laboratoryTestCategories;
       
        private IGenericRepository<Prescription> _prescriptions;

        private IGenericRepository<Medication> _medications;
        private IGenericRepository<Building> _buildings;
        private IGenericRepository<Room> _rooms;
        private IGenericRepository<PatientSchedule> _patientschedules;
        private IGenericRepository<BillSchedule> _billschedules;



        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        // Define GenericRepository instances here
        public IGenericRepository<AdmissionType> AdmissionTypes => _admissionTypes ??= new GenericRepository<AdmissionType>(_context);
        public IGenericRepository<City> Cities => _cities ??= new GenericRepository<City>(_context);
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Language> Languages => _languages ??= new GenericRepository<Language>(_context);
        public IGenericRepository<Occupation> Occupations => _occupations ??= new GenericRepository<Occupation>(_context);
        public IGenericRepository<EducationLevel> EducationLevels => _educationLevels ??= new GenericRepository<EducationLevel>(_context);
        public IGenericRepository<MaritalStatus> MaritalStatuses => _maritalStatuses ??= new GenericRepository<MaritalStatus>(_context);
        public IGenericRepository<PaymentOption> PaymentOptions => _paymentOptions ??= new GenericRepository<PaymentOption>(_context);
        public IGenericRepository<Relationship> Relationships => _relationships ??= new GenericRepository<Relationship>(_context);
        public IGenericRepository<MedicalDepartment> MedicalDepartments => _medicalDepartments ??= new GenericRepository<MedicalDepartment>(_context);
        public IGenericRepository<Gender> Genders => _genders ??= new GenericRepository<Gender>(_context);
        public IGenericRepository<Patient> Patients => _patients ??= new GenericRepository<Patient>(_context);
        public IGenericRepository<ResponsiblePerson> ResponsiblePersons => _responsiblePersons ??= new GenericRepository<ResponsiblePerson>(_context);
        public IGenericRepository<EmployeeRole> EmployeeRoles => _employeeRoles ??= new GenericRepository<EmployeeRole>(_context);
        public IGenericRepository<Employee> Employees => _employees ??= new GenericRepository<Employee>(_context);
        public IGenericRepository<AppointmentDuration> AppointmentDurations => _appointmentDurations ??= new GenericRepository<AppointmentDuration>(_context);
        public IGenericRepository<Receptionist> Receptionists => _receptionists ??= new GenericRepository<Receptionist>(_context);
        public IGenericRepository<Case> Cases => _cases ??= new GenericRepository<Case>(_context);
        public IGenericRepository<Accountant> Accountants => _accountants ??= new GenericRepository<Accountant>(_context);
        public IGenericRepository<BloodGroup> BloodGroups => _bloodgroups ??= new GenericRepository<BloodGroup>(_context);
        public IGenericRepository<Donor> Donors => _donors ??= new GenericRepository<Donor>(_context);
        public IGenericRepository<Pharmacist> Pharmacists => _pharmacists ??= new GenericRepository<Pharmacist>(_context);
        public IGenericRepository<Doctor> Doctors => _doctors ??= new GenericRepository<Doctor>(_context);
        public IGenericRepository<Laboratoriest> Laboratoriests => _laboratoriests ??= new GenericRepository<Laboratoriest>(_context);
        public IGenericRepository<MedicineCategory> MedicineCategories => _medicinecategories ??= new GenericRepository< MedicineCategory>(_context);
        public IGenericRepository<Medicine> Medicines => _medicines ??= new GenericRepository<Medicine>(_context);
        public IGenericRepository<PatientFile> PatientFiles => _patientFiles ??= new GenericRepository<PatientFile>(_context);
        public IGenericRepository<Weekday> Weekdays => _weekdays ??= new GenericRepository<Weekday>(_context);
        public IGenericRepository<Pathology> Pathologies => _pathologies ??= new GenericRepository<Pathology>(_context);
        public IGenericRepository<WardType> WardTypes => _wardtypes ??= new GenericRepository<WardType>(_context);
        public IGenericRepository<Nurse> Nurses => _nurses ??= new GenericRepository<Nurse>(_context);
        public IGenericRepository<Schedule> Schedules => _schedules ??= new GenericRepository<Schedule>(_context);
        public IGenericRepository<LaboratoryTestType> LaboratoryTestTypes => _laboratorytesttypes ??= new GenericRepository<LaboratoryTestType>(_context);
        public IGenericRepository<Specialization> Specializations => _specializations ??= new GenericRepository<Specialization>(_context);
        public IGenericRepository<Vaccine> Vaccines => _vaccines ??= new GenericRepository<Vaccine>(_context);
        public IGenericRepository<Holiday> Holidays => _holidays ??= new GenericRepository<Holiday>(_context);
      

       
        public IGenericRepository<Recommendation> Recommendations => _recommendations ??= new GenericRepository<Recommendation>(_context);
        public IGenericRepository<LaboratoryTestCategory> LaboratoryTestCategories => _laboratoryTestCategories ??= new GenericRepository<LaboratoryTestCategory>(_context);
        
        public IGenericRepository<Prescription> Prescriptions => _prescriptions ??= new GenericRepository<Prescription>(_context);

        public IGenericRepository<Medication> Medications => _medications ??= new GenericRepository<Medication>(_context);
        public IGenericRepository<Building> Buildings => _buildings ??= new GenericRepository<Building>(_context);
        public IGenericRepository<Room> Rooms => _rooms ??= new GenericRepository<Room>(_context);
        public IGenericRepository<PatientSchedule> PatientSchedules => _patientschedules ??= new GenericRepository<PatientSchedule>(_context);
        public IGenericRepository<BillSchedule> BillSchedules => _billschedules ??= new GenericRepository<BillSchedule>(_context);

    }
}
