using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime FinishingTime { get; set; }

        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Weekday Weekday { get; set; }
        public int WeekdayId { get; set; }
        public AppointmentDuration AppointmentDuration { get; set; }
        public int AppointmentDurationId { get; set; }
    }
}
