using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;

namespace PizzaJuan.Tests.Controllers
{
    [TestClass]
    public class DrinkControllerTest
    {
        [TestMethod]
        public void TestChooseBeverageViewResultNotNull()
        {
            // Arrange
            DrinkController controller = new DrinkController();

            // Act
            ViewResult result = controller.ChooseBeverage() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ChooseBeverage", result.ViewName);
        }
    }
}
