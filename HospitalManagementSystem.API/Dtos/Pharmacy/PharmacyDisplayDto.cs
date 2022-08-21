using HospitalManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Pharmacy
{
    public class PharmacyDisplayDto
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
