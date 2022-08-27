using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class PatientSchedule
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }

        public int PatientId { get; set; }

        public AdmissionType AdmissionType { get; set; }
        public int AdmissionTypeId { get; set; }


        public Room Room { get; set; }
        public int RoomId { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public bool Is_Payed { get; set; }

        public bool Is_Dismissed { get; set; }

        public DateTime TimeStamp { get; set; }

        public DateTime ScheduleDate { get; set; }

        public DateTime ScheduleTime { get; set; }
        public bool Is_Confirmed { get; set; }

        public BillSchedule BillSchedule { get; set; }


       
       


    }
}
