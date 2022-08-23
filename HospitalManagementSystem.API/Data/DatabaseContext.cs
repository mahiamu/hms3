using HospitalManagementSystem.API.Configuration;
using HospitalManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {}

        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppointmentDuration> AppointmentDurations { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PatientFile> PatientFiles { get; set; }
        public DbSet<Laboratoriest> Laboratoriests { get; set; }
        public DbSet<Weekday> Weekdays { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Pathology> Pathologies { get; set; }
        public DbSet<WardType> WardTypes { get; set; }
        public DbSet<LaboratoryTestCategory> LaboratoryTestCategories { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<LaboratoryTestType> LaboratoryTestTypes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        public DbSet<BedType> BedTypes { get; set; }

        public DbSet<Medication> Medications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AdmissionTypeConfigurations());
            builder.ApplyConfiguration(new GenderConfigurations());
            builder.ApplyConfiguration(new CityConfigurations());
            builder.ApplyConfiguration(new CountryConfigurations());
            builder.ApplyConfiguration(new LanguageConfigurations());
            builder.ApplyConfiguration(new MaritalStatusConfigurations());
            builder.ApplyConfiguration(new OccupationConfigurations());
            builder.ApplyConfiguration(new EducationLevelConfigurations());
            builder.ApplyConfiguration(new RelationshipConfigurations());
            builder.ApplyConfiguration(new PaymentOptionConfigurations());
            builder.ApplyConfiguration(new MedicalDepartmentConfigurations());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new ResponsiblePersonConfigurations());
            builder.ApplyConfiguration(new EmployeeRoleConfigurations());
            builder.ApplyConfiguration(new EmployeeConfigurations());
            builder.ApplyConfiguration(new AppointmentDurationConfigurations());
            builder.ApplyConfiguration(new ReceptionistConfigurations());
            builder.ApplyConfiguration(new CaseConfigurations());
            builder.ApplyConfiguration(new AccountantConfigurations());
            builder.ApplyConfiguration(new BloodGroupConfigurations());
            builder.ApplyConfiguration(new DonorConfigurations());
            builder.ApplyConfiguration(new PharmacistConfigurations());
            builder.ApplyConfiguration(new DoctorConfigurations());
            builder.ApplyConfiguration(new PatientFileConfigurations());
            builder.ApplyConfiguration(new LaboratoriestConfigurations());
            builder.ApplyConfiguration(new MedicineCategoryConfigurations());
            builder.ApplyConfiguration(new MedicineConfigurations());
            builder.ApplyConfiguration(new WeekdayConfigurations());
            builder.ApplyConfiguration(new ScheduleConfigurations());
            builder.ApplyConfiguration(new PrescriptionConfigurations());
            builder.ApplyConfiguration(new NurseConfigurations());
            builder.ApplyConfiguration(new HolidayConfigurations());
            builder.ApplyConfiguration(new SpecializationConfigurations());
            builder.ApplyConfiguration(new HolidayConfigurations());
            builder.ApplyConfiguration(new PathologyConfigurations());
            builder.ApplyConfiguration(new VaccineConfigurations());
           
            builder.ApplyConfiguration(new LaboratoryTestCategoryConfigurations());
            builder.ApplyConfiguration(new RecommendationConfigurations());
            builder.ApplyConfiguration(new LaboratoryTestTypeConfigurations());
      
            builder.ApplyConfiguration(new WardTypeConfigurations());

            builder.ApplyConfiguration(new BedTypeConfigurations());
            builder.ApplyConfiguration(new MedicationConfigurations());

        }
    }
}
