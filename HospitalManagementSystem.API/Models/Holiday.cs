﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}
