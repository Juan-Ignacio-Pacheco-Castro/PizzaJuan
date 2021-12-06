using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;

namespace PizzaJuan.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void TestIndexViewResultNotNull() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
