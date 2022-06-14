using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Schedules
{
    public class ScheduleDisplayDto
    {
        public int Id { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime FinishingTime { get; set; }

        public int DoctorId { get; set; }
        public int WeekdayId { get; set; }
        public int AppointmentDurationId { get; set; }
    }
}
