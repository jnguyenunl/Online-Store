using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
    }
}