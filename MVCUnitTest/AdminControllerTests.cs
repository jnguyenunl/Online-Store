using Ecommerce.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace MVCUnitTest
{
    [TestClass]
    public class AdminControllerTests
    {
        public void Create_Should_Not_Return_Null()
        {
            AdminController controller = new AdminController();

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
