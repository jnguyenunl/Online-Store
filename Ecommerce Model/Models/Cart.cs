using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Cart
    {

        public int CartID { get; set; }
        public int UserID { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }

    }
}