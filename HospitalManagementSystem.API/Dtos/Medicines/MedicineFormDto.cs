using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Medicines
{
    public class MedicineFormDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public int Quantity { get; set; }
        [MaxLength(50)]
        public string GenericName { get; set; }
        [Required]
        public string Effects { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int MedicineCategoryId { get; set; }
        [Required]
        public int CountryId { get; set; }


    }
}
