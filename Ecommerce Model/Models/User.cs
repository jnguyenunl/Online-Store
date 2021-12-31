using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&_-])[A-Za-z\d@$!%*?&_-]{8,20}$", 
                           ErrorMessage = "Minimum of 8 characters and maximum of 20 characters, at least one lowercase letter, " +
                           "one uppercase letter, one number, and one special character (@$!%*?&_-)")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,50}$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        public virtual Order Order { get; set; }
    }
}