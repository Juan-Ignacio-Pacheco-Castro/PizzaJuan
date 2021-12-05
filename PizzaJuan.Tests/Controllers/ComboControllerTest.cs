using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;

namespace PizzaJuan.Tests.Controllers
{
    [TestClass]
    public class ComboControllerTest
    {
        [TestMethod]
        public void TestComboOptionsViewResultNotNull()
        {
            // Arrange
            ComboController controller = new ComboController();

            // Act
            ViewResult result = controller.ComboOptions() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ComboOptions", result.ViewName);
        }
    }
}
