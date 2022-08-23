namespace HospitalManagementSystem.API.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public int FloorNumber { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
