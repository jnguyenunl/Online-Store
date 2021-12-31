using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        EcommerceContext db = new EcommerceContext();

        // GET: Search
        public ActionResult Index(int id)
        {

            var product = db.Product.Where(i => i.ProductID == id).FirstOrDefault();
            ViewData["Manufacturer"] = product.Manufacturer.Name;

            return View(product);
        }
    }
}