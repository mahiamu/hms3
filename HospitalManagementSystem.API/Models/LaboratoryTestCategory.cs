using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class LaboratoryTestCategory : BaseModel
    {
        public ICollection<LaboratoryTestType> LaboratoryTestTypes { get; set; }

        public LaboratoryTestCategory()
        {
            LaboratoryTestTypes = new Collection<LaboratoryTestType>();
        }
    }
}
