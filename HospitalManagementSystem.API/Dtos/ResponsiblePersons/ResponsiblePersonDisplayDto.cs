using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.ResponsiblePersons
{
    public class ResponsiblePersonDisplayDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public int RelationshipId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int PatientId { get; set; }
    }
}
