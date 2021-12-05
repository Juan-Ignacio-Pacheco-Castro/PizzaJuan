using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers
{
    [TestClass]
    public class DeliveryControllerTest
    {
        [TestMethod]
        public void TestExpressViewResultNotNull()
        {
            // Arrange
            DeliveryController controller = new DeliveryController();

            // Act
            ViewResult result = controller.Express() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Express", result.ViewName);
        }

        [TestMethod]
        public void TestTakeoutViewResultNotNull()
        {
            // Arrange
            DeliveryController controller = new DeliveryController();

            // Act
            ViewResult result = controller.Takeout() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Takeout", result.ViewName);
        }

        [TestMethod]
        public void TestPostDelivery()
        {
            // Arrange
            DeliveryController controller = new DeliveryController();
            DeliveryModel delivery = new DeliveryModel();
            delivery.Type = "Express";

            // Act
            controller.PostDelivery(delivery);

            // Assert
            Assert.AreEqual("Express", controller.JsonParser.GetDeliveryFromJson(controller.JsonParser.ParseFromJSON("Delivery.json"))[0].Type);
            controller.JsonParser.ClearOrder();
        }
    }
}
