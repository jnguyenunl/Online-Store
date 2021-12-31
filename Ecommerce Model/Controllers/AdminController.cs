using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;
using System.Data;
using System.IO;
namespace Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Product.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var list = db.Manufacturers.ToList();
            foreach (var pro in list)
            {
                items.Add(new SelectListItem { Text = pro.Name, Value = pro.ManufacturerID.ToString() });
            }
            ViewData["ManufactureID"] = items;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            try
            {
                // TODO: Add insert logic here
                db.Product.Add(prod);
                db.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Product.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                // TODO: Add update logic here
                Product pro = db.Product.Where(i => i.ProductID == prod.ProductID).FirstOrDefault();

                if (TryUpdateModel(pro))
                {
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Product.Where(s => s.ProductID == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product prod)
        {
            try
            {
                // TODO: Add delete logic here
                prod = db.Product.Where(s => s.ProductID == id).FirstOrDefault();
                db.Product.Remove(prod);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
