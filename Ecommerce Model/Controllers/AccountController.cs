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
    public class AccountController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User signupDetails) {
            if (ModelState.IsValid) {
                using (var databaseContext = new DAL.EcommerceContext()) {
                    Address address = new Address {
                        Street = signupDetails.Address.Street,
                        City = signupDetails.Address.City,
                        State = signupDetails.Address.State,
                        Country = signupDetails.Address.Country,
                        PostalCode = signupDetails.Address.PostalCode
                    };

                    databaseContext.Addresses.Add(address);
                    databaseContext.SaveChanges();

                    var addressqry = (from a in databaseContext.Addresses where a.Street == signupDetails.Address.Street 
                                      select a.AddressID).ToArray();

                    User user = new User {
                        Username = signupDetails.Username,
                        Email = signupDetails.Email,
                        Password = signupDetails.Password,
                        ConfirmPassword = signupDetails.ConfirmPassword,
                        AddressID = addressqry.ElementAt(0)
                    };

                    databaseContext.Users.Add(user);
                    databaseContext.SaveChanges();

                    var arr = databaseContext.Users.Select(i => i.UserID).ToArray();

                    Cart cart = new Cart
                    {
                        UserID = arr[arr.Length - 1]
                    };

                    databaseContext.Carts.Add(cart);
                    databaseContext.SaveChanges();
                }

                ModelState.Clear();
                ViewBag.Message = "User Saved";
                return View("SignUp");
            } else {
                return View("SignUp", signupDetails);
            }
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model) {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(model);

                if (isValidUser != null)
                {
                    var check = db.Users.FirstOrDefault(s => s.Email == model.Email);
                    if (check.Email=="admin@gmail.com")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("Failure", "Incorrect Username and/or Password");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        public User IsValidUser(Login model) {
            using (var dataContext = new DAL.EcommerceContext()) {
                User user = dataContext.Users.Where(query => query.Email.Equals(model.Email) && query.Password.Equals(model.Password)).SingleOrDefault();
                if (user == null) {
                    return null;
                } else {
                    return user;
                }
            }
        }
    }
}