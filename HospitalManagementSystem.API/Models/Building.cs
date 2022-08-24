using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public ICollection<Ward> Wards { get; set; }
        public Building()
        {
            Wards = new Collection<Ward>();
        }
    }
}
