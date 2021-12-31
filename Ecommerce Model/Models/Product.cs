using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public double Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Rating { get; set; }
        [Required]
        [StringLength(50)]
        public string Size { get; set; }
        public double Weight { get; set; }
        [Required]
        [StringLength(50)]
        public string SKU { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufactureID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}