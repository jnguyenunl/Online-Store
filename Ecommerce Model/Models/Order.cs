using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Order
    {
        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }
        [Required]
        public double PriceTotal { get; set; }
        public double Tax { get; set; }
        public double ShippingCost { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Payment Info")]
        public string PaymentInfo { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}