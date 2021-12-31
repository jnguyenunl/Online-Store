using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Ecommerce.DAL;

namespace Ecommerce.Controllers {
    public class SearchController : Controller
    {
        EcommerceContext db = new EcommerceContext();

        // GET: Search
        public ActionResult Index(string searchString) {
            var products = from p in db.Product select p;

            if(!String.IsNullOrEmpty(searchString)) {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            return View(products);
        }
    }
}