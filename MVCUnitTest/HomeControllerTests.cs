using Ecommerce.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace MVCUnitTest
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void About_Should_Not_Return_Null()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.About() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Sign_Should_Not_Return_Null()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.SignUp() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_Should_Not_Return_Null()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Login() as ViewResult;

            Assert.IsNotNull(result);
        }

        public void Search_Should_Not_Return_Null()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Search() as ViewResult;

            Assert.IsNotNull(result);
        }

        public void Cart_Should_Not_Return_Null()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Cart() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
