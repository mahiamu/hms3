using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.API.Dtos.Buildings
{
    public class BuildingFormDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int Code { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
