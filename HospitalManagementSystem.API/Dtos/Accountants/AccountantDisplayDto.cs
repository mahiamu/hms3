﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Accountants
{
    public class AccountantDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public string EmailAddress { get; set; }

        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public int GenderId { get; set; }

    }
}
