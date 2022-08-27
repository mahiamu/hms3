using System;

namespace HospitalManagementSystem.API.Dtos.PatientSchedules
{
    public class PatientScheduleFormDto
    {
       

        public int PatientId { get; set; }

      
        public int AdmissionTypeId { get; set; }


       
        public int RoomId { get; set; }

       
        public int EmployeeId { get; set; }

        public bool Is_Payed { get; set; }

        public bool Is_Dismissed { get; set; }

        public DateTime TimeStamp { get; set; }

        public DateTime ScheduleDate { get; set; }

        public DateTime ScheduleTime { get; set; }

    }
}
