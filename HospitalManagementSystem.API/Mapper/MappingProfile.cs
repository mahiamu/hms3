using AutoMapper;
using HospitalManagementSystem.API.Dtos.AdmissionTypes;
using HospitalManagementSystem.API.Dtos.PaymentOptions;
using HospitalManagementSystem.API.Dtos.Relationships;
using HospitalManagementSystem.API.Dtos.Cities;
using HospitalManagementSystem.API.Dtos.Countries;
using HospitalManagementSystem.API.Dtos.languages;
using HospitalManagementSystem.API.Dtos.Occupations;
using HospitalManagementSystem.API.Dtos.EducationLevels;
using HospitalManagementSystem.API.Dtos.MaritalStatuses;
using HospitalManagementSystem.API.Dtos.Genders;
using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementSystem.API.Dtos.Patients;
using HospitalManagementSystem.API.Dtos.MedicalDepartments;
using HospitalManagementSystem.API.Dtos.ResponsiblePersons;
using HospitalManagementSystem.API.Dtos.EmployeeRoles;
using HospitalManagementSystem.API.Dtos.Employees;
using HospitalManagementSystem.API.Dtos.AppointmentDurations;
using HospitalManagementSystem.API.Dtos.Cases;
using HospitalManagementSystem.API.Dtos.Accountants;
using HospitalManagementSystem.API.Dtos.BloodGroups;
using HospitalManagementSystem.API.Dtos.Donors;
using HospitalManagementSystem.API.Dtos.Pharmacists;
using HospitalManagementSystem.API.Dtos.Doctors;
using HospitalManagementSystem.API.Dtos.MedicineCategories;
using HospitalManagementSystem.API.Dtos.PatientFiles;
using HospitalManagementSystem.API.Dtos.Receptionists;
using HospitalManagementSystem.API.Dtos.Specializations;
using HospitalManagementSystem.API.Dtos.Weekdays;
using HospitalManagementSystem.API.Dtos.Pathologies;
using HospitalManagementSystem.API.Dtos.WardTypes;
using HospitalManagementSystem.API.Dtos.Nurses;
using HospitalManagementSystem.API.Dtos.Schedules;
using HospitalManagementSystem.API.Dtos.LaboratoryTestTypes;
using HospitalManagementSystem.API.Dtos.Vaccines;
using HospitalManagementSystem.API.Dtos.Holidays;
using HospitalManagementSystem.API.Dtos.Laboratorists;
using HospitalManagementSystem.API.Dtos.Recommendations;
using HospitalManagementSystem.API.Dtos.LaboratoryTestCategories;
using HospitalManagementSystem.API.Dtos.Prescriptions;
using HospitalManagementSystem.API.Dtos.Medications;
using HospitalManagementSystem.API.Dtos.Room;
using HospitalManagementSystem.API.Dtos.Buildings;
using HospitalManagementSystem.API.Dtos.PatientSchedules;
using HospitalManagementSystem.API.Dtos.Admissions;
using HospitalManagementSystem.API.Dtos.MedicineStockHospitals;

namespace HospitalManagementSystem.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdmissionType, AdmissionTypeDisplayDto>().ReverseMap();
            CreateMap<AdmissionType, AdmissionTypeFormDto>().ReverseMap();

            CreateMap<PaymentOption, PaymentOptionDisplayDto>().ReverseMap();
            CreateMap<PaymentOption, PaymentOptionFormDto>().ReverseMap();

            CreateMap<Relationship, RelationshipDisplayDto>().ReverseMap();
            CreateMap<Relationship, RelationshipFormDto>().ReverseMap();

            CreateMap<City, CityDisplayDto>().ReverseMap();
            CreateMap<City, CityFormDto>().ReverseMap();

            CreateMap<Country, CountryDisplayDto>().ReverseMap();
            CreateMap<Country, CountryFormDto>().ReverseMap();

            CreateMap<Language, LanguageDisplayDto>().ReverseMap();
            CreateMap<Language, LanguageFormDto>().ReverseMap();

            CreateMap<Occupation, OccupationDisplayDto>().ReverseMap();
            CreateMap<Occupation, OccupationFormDto>().ReverseMap();

            CreateMap<EducationLevel, EducationLevelDisplayDto>().ReverseMap();
            CreateMap<EducationLevel, EducationLevelFormDto>().ReverseMap();

            CreateMap<MaritalStatus, MaritalStatusDisplayDto>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusFormDto>().ReverseMap();

            CreateMap<Patient, PatientDisplayDto>().ReverseMap();
            CreateMap<Patient, PatientFormDto>().ReverseMap();

            CreateMap<MedicalDepartment, MedicalDepartmentDisplayDto>().ReverseMap();
            CreateMap<MedicalDepartment, MedicalDepartmentFormDto>().ReverseMap();

            CreateMap<Gender, GenderDisplayDto>().ReverseMap();
            CreateMap<Gender, GenderFormDto>().ReverseMap();

            CreateMap<ResponsiblePerson, ResponsiblePersonDisplayDto>().ReverseMap();
            CreateMap<ResponsiblePerson, ResponsiblePersonFormDto>().ReverseMap();

            CreateMap<EmployeeRole, EmployeeRoleDisplayDto>().ReverseMap();
            CreateMap<EmployeeRole, EmployeeRoleFormDto>().ReverseMap();

            CreateMap<Employee, EmployeeDisplayDto>().ReverseMap();
            CreateMap<Employee, EmployeeFormDto>().ReverseMap();

            CreateMap<AppointmentDuration, AppointmentDurationDisplayDto>().ReverseMap();
            CreateMap<AppointmentDuration, AppointmentDurationFormDto>().ReverseMap();

            CreateMap<Case, CaseDisplayDto>().ReverseMap();
            CreateMap<Case, CaseFormDto>().ReverseMap();

            CreateMap<Accountant, AccountantDisplayDto>().ReverseMap();
            CreateMap<Accountant, AccountantFormDto>().ReverseMap();

            CreateMap<BloodGroup, BloodGroupDisplayDto>().ReverseMap();
            CreateMap<BloodGroup, BloodGroupFormDto>().ReverseMap();

            CreateMap<Donor, DonorDisplayDto>().ReverseMap();
            CreateMap<Donor,DonorFormDto>().ReverseMap();

            CreateMap<Doctor, DoctorDisplayDto>().ReverseMap();
            CreateMap<Doctor, DoctorFormDto>().ReverseMap();          

            CreateMap<MedicineCategory, MedicineCategoryDisplayDto>().ReverseMap();
            CreateMap<MedicineCategory, MedicineCategoryFormDto>().ReverseMap();

            CreateMap<MedicineStockHospital, MedicineStockHospitalDisplayDto>().ReverseMap();
            CreateMap<MedicineStockHospital, MedicineStockHospitalFormDto>().ReverseMap();

            CreateMap<PatientFile, PatientFilesDisplayDto>().ReverseMap();
            CreateMap<PatientFile, PatientFilesFormDto>().ReverseMap();

            CreateMap<Laboratoriest, PatientFilesDisplayDto>().ReverseMap();
            CreateMap<Laboratoriest, PatientFilesFormDto>().ReverseMap();

            CreateMap<Pharmacist, PharmacistDisplayDto>().ReverseMap();
            CreateMap<Pharmacist, PharmacistFormDto>().ReverseMap();

            CreateMap<Receptionist, ReceptionistDisplayDto>().ReverseMap();
            CreateMap<Receptionist, ReceptionistFormDto>().ReverseMap();

            CreateMap<Specialization, SpecializationDisplayDto>().ReverseMap();
            CreateMap<Specialization, SpecializationFormDto>().ReverseMap();

            CreateMap<Weekday, WeekdayDisplayDto>().ReverseMap();
            CreateMap<Weekday, WeekdayFormDto>().ReverseMap();

            CreateMap<Pathology, PathologyDisplayDto>().ReverseMap();
            CreateMap<Pathology, PathologyFormDto>().ReverseMap();

            CreateMap<WardType, WardTypeDisplayDto>().ReverseMap();
            CreateMap<WardType, WardTypeFormDto>().ReverseMap();

            CreateMap<Nurse, NurseDisplayDto>().ReverseMap();
            CreateMap<Nurse, NurseFormDto>().ReverseMap();

            CreateMap<Schedule, ScheduleDisplayDto>().ReverseMap();
            CreateMap<Schedule, ScheduleFormDto>().ReverseMap();

            CreateMap<LaboratoryTestType, LaboratoryTestTypeDisplayDto>().ReverseMap();
            CreateMap<LaboratoryTestType, LaboratoryTestTypeFormDto>().ReverseMap();

            CreateMap<Vaccine, VaccineDisplayDto>().ReverseMap();
            CreateMap<Vaccine, VaccineFormDto>().ReverseMap();

            CreateMap<Holiday, HolidayDisplayDto>().ReverseMap();
            CreateMap<Holiday, HolidayFormDto>().ReverseMap();

            CreateMap<Laboratoriest, LaboratoristDisplayDto>().ReverseMap();
            CreateMap<Laboratoriest, LaboratoriestFormDto>().ReverseMap();




            CreateMap<Recommendation, RecommendationDisplayDto>().ReverseMap();
            CreateMap<Recommendation, RecommendationFormDto>().ReverseMap();

            CreateMap<LaboratoryTestCategory, LaboratoryTestCategoryDisplayDto>().ReverseMap();
            CreateMap<LaboratoryTestCategory, LaboratoryTestCategoryFormDto>().ReverseMap();


            CreateMap<Prescription, PrescriptionDisplayDto>().ReverseMap();
            CreateMap<Prescription, PrescriptionFormDto>().ReverseMap();

            CreateMap<Medication, MedicationDisplayDto>().ReverseMap();
            CreateMap<Medication,MedicationFormDto>().ReverseMap();

            CreateMap<Room, RoomDisplayDto>().ReverseMap();
            CreateMap<Room, RoomFormDto>().ReverseMap();

            CreateMap<Building, BuildingDisplayDto>().ReverseMap();
            CreateMap<Room, BuildingFormDto>().ReverseMap();
            CreateMap<PatientSchedule, PatientScheduleDisplayDto>().ReverseMap();
            CreateMap<PatientSchedule, PatientScheduleFormDto>().ReverseMap();

            CreateMap<Building, BuildingFormDto>().ReverseMap();


            CreateMap<Admission, AdmissionDisplayDto>().ReverseMap();
            CreateMap<Building, AdmissionFormDto>().ReverseMap();

        }
    }
}
