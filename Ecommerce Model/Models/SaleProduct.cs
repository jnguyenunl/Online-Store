using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class SaleProduct
    {
        public int SaleProductID { get; set; }
        public int SaleId { get; set; }
        public int ProductID { get; set; }
        public double DollarAmt { get; set; }
        public double PercentAmt { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}