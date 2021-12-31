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
    public class CartProductsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // POST: CartProducts/Create
        public void Create(int id)
        {
            //Get user cart id
            int userID = db.Users.Where(i => i.Email == User.Identity.Name).Select(i => i.UserID).FirstOrDefault();
            int cartID = db.Carts.Where(i => i.UserID == userID).Select(i => i.CartID).FirstOrDefault();
            if (cartID != 0)
            {
                var product_cart = db.CartProducts.Where(i => i.CartID == cartID & i.ProductID == id).ToArray();
                CartProduct cartProduct = new CartProduct();
                //if product added, quantity add
                if (product_cart.Length != 0)
                {
                    cartProduct = product_cart[0];
                    cartProduct.Quantity += 1;
                }
                else
                {

                    cartProduct.CartID = db.Carts.Where(i => i.UserID == userID).Select(i => i.CartID).FirstOrDefault();
                    cartProduct.Quantity = 1;
                    cartProduct.ProductID = id;
                    db.CartProducts.Add(cartProduct);
                }
                db.SaveChanges();
            }
            else
            {
                return;
            }

        }

        // GET: CartProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "Name", cartProduct.ProductID);
            return View(cartProduct);
        }

        // POST: CartProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartProductID,Quantity")] CartProduct cartProduct)
        {
            if (ModelState.IsValid)
            {
                db.CartProducts.Find(cartProduct.CartProductID).Quantity = cartProduct.Quantity;
                db.SaveChanges();
                return RedirectToAction("Index", "Carts");
            }
            return RedirectToAction("Index", "Carts");
        }

        // GET: CartProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartProduct cartProduct = db.CartProducts.Find(id);
            if (cartProduct == null)
            {
                return HttpNotFound();
            }
            return View(cartProduct);
        }

        // POST: CartProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartProduct cartProduct = db.CartProducts.Find(id);
            db.CartProducts.Remove(cartProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Carts");
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
