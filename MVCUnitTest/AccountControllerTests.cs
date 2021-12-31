using Ecommerce.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace MVCUnitTest
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void Index_Should_Not_Return_Null()
        {
            AccountController controller = new AccountController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SignUp_Should_Not_Return_Null()
        {
            AccountController controller = new AccountController();

            ViewResult result = controller.SignUp() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login_Should_Not_Return_Null()
        {
            AccountController controller = new AccountController();

            ViewResult result = controller.Login() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
