using System.Collections.Generic;

namespace HospitalManagementSystem.API.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MedicineTypeID { get; set; }
        public int ExpireDate { get; set; }
        public int Quantity { get; set; }
        public string Vendor { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public virtual Employee EmployeeID { set; get; }
    }
}
