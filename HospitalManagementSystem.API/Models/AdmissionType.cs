using HospitalManagementSystem.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class AdmissionType : BaseModel
    {

        public ICollection<PatientSchedule> PatientSchedules { get; set; }

        public AdmissionType()
        {

            PatientSchedules = new Collection<PatientSchedule>();
        }


    }
}
