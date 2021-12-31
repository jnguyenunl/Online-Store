using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Period")]
        public DateTime StartPeriod { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Period")]
        public DateTime EndPeriod { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
        public virtual ICollection<SaleCategory> SaleCategories { get; set; }
    }
}