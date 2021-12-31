using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class CartsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Carts
        public ActionResult Index()
        {

            int userID = db.Users.Where(i => i.Email == User.Identity.Name).Select(i => i.UserID).FirstOrDefault();
            var carts = db.Carts.Include(c => c.CartProducts).Where(c => c.UserID == userID);
            return View(carts.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
