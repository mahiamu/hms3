using HospitalManagementSystem.API.Models;

namespace HospitalManagementSystem.API.Dtos.Room
{
    public class RoomDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
