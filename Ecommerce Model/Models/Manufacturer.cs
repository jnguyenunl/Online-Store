using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}