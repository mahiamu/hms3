using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class BloodGroup : BaseModel
    {
        public ICollection<Donor> Donors { get; set; }

        public BloodGroup()
        {
            Donors = new Collection<Donor>();
        }
    }
}
