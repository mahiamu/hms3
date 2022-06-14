using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int Quantity { get; set; }
        public string GenericName { get; set; }
        public string Effects { get; set; }
        public DateTime ExpirationDate { get; set; }

        public MedicineCategory MedicineCategory { get; set; }
        public int MedicineCategoryId { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public Medicine()
        {
            Prescriptions = new Collection<Prescription>();
        }

    }
}
