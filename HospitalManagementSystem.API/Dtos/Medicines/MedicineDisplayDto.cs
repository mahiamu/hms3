using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Medicines
{
    public class MedicineDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int Quantity { get; set; }
        public string GenericName { get; set; }
        public string Effects { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int MedicineCategoryId { get; set; }
        public int CountryId { get; set; }

    }
}
