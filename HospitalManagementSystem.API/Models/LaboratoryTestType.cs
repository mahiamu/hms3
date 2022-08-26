using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class LaboratoryTestType : BaseModel
    {
        public int Price { get; set; }

        public LaboratoryTestCategory LaboratoryTestCategory { get; set; }
        public int LaboratoryTestCategoryId { get; set; }
        public ICollection<LabRequest> LabRequests { get; set; }
        public LaboratoryTestType()
        {
            LabRequests = new Collection<LabRequest>();
        }
        }
}
