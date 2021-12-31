using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class SaleCategory
    {
        public int SaleCategoryID { get; set; }
        public int SaleId { get; set; }
        public int CategoryID { get; set; }
        public double DollarAmt { get; set; }
        public double PercentAmt { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Category Category { get; set; }
    }
}