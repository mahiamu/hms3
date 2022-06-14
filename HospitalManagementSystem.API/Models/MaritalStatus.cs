﻿using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class MaritalStatus: BaseModel
    {
        public ICollection<Patient> Patients { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public MaritalStatus()
        {
            Patients = new Collection<Patient>();
            Employees = new Collection<Employee>();
        }
    }
}
