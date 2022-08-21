using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.API.Dtos.Pharmacy
{
    public class UsersFormDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string ExpireDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string Quantity { get; set; }

        [Required]
        [MaxLength(255)]
        public string Vendor { get; set; }

        [Required]
        [MaxLength(50)]
        public int PurchasePrice { get; set; }

        [Required]
        public int SalePrice { get; set; }
    }
}
