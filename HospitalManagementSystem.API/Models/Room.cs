using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }

        public ICollection<PatientSchedule> PatientSchedules { get; set; }

        public Room()
        {
            PatientSchedules = new Collection<PatientSchedule>();
        }
        
    }
}
