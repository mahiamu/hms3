using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HospitalManagementSystem.API.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Building Building { get; set; }
        public int BuildingNumberId { get; set; }
        public string FloorNumber { get; set; }
        public int WardTypeId { get; set; }
        public bool Isprivate { get; set; }
        public string Code { get; set; }
        public ICollection<Admission> Admissions { get; set; }

        public Ward () {

       Admissions  = new Collection<Admission>();
            }


    }
}
