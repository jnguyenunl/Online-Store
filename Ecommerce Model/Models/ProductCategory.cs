using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}