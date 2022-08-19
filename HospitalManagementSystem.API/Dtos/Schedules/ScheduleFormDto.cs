using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Schedules
{
    public class ScheduleFormDto
    {
        [Required]
        public DateTime StartingTime { get; set; }
        [Required]
        public DateTime FinishingTime { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int WeekdayId { get; set; }
        [Required]
        public int AppointmentDurationId { get; set; }
    }
}
