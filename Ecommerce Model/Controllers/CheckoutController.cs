using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Data.Entity;

namespace Ecommerce.Controllers
{
    public class CheckoutController : Controller
    {
        private EcommerceContext db = new EcommerceContext();


        // GET: Checkout
        public ActionResult Index()
        {
            int userID = db.Users.Where(i => i.Email == User.Identity.Name).Select(i => i.UserID).FirstOrDefault();
            return View(db.Orders.Where(i => i.UserID == userID).ToList());
        }


        public ActionResult Pay()
        {
            int userID = db.Users.Where(i => i.Email == User.Identity.Name).Select(i => i.UserID).FirstOrDefault();
            var carts = db.Carts.Include(c => c.CartProducts).Where(c => c.UserID == userID);

            ViewData["Carts"] = carts.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Pay(Order orderDetails)
        {
            int userID = db.Users.Where(i => i.Email == User.Identity.Name).Select(i => i.UserID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                using (var databaseContext = new DAL.EcommerceContext())
                {
                    Order order = new Order
                    {
                        PriceTotal = orderDetails.PriceTotal,
                        Tax = orderDetails.Tax,
                        ShippingCost = orderDetails.ShippingCost,
                        PaymentType = orderDetails.PaymentType,
                        PaymentInfo = orderDetails.PaymentInfo,
                        UserID = userID
                    };

                    databaseContext.Orders.Add(order);

                    //get all cart product in the cart
                    int cartId = databaseContext.Carts.Where(i => i.UserID == userID).Select(i => i.CartID).FirstOrDefault();
                    List<CartProduct> cp = databaseContext.CartProducts.Where(i => i.CartID == cartId).ToList();

                    //remove these product from cart.
                    databaseContext.CartProducts.RemoveRange(cp);

                    databaseContext.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = "Payment Confirmed";
                return View("Index", db.Orders.Where(i => i.UserID == userID).ToList());
            }
            else
            {
                return View("Index", orderDetails);
            }
        }
    }
}