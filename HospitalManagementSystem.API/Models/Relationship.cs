using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Relationship: BaseModel

    {
        public ICollection<ResponsiblePerson> ResponsiblePersons { get; set; }

        public Relationship()
        {
            ResponsiblePersons = new Collection<ResponsiblePerson>();
        }
    }
}
