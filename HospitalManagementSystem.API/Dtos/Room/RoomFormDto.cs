using HospitalManagementSystem.API.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.API.Dtos.Room
{
    public class RoomFormDto
    {
        [Required]

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public int BuildingId { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        public int Code { get; set; }
        [ MaxLength(255)]
        public string Description { get; set; }
    }
}
