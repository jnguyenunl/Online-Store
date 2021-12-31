using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAL;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        public ActionResult Index()
        {
            return View(db.Product.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Men()
        {
            var products = from p in db.Product select p;
            products = products.Where(s => s.Name.Contains("Men") && !s.Name.Contains("Women"));

            return View(products);
        }

        public ActionResult Women()
        {
            var products = from p in db.Product select p;
            products = products.Where(s => s.Name.Contains("Women"));

            return View(products);
        }

        public ActionResult Other()
        {
            return View();
        }

        public ActionResult Purchase()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
    }
}