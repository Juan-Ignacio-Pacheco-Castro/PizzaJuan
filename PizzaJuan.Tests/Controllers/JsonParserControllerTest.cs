using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers
{
    [TestClass]
    public class JsonParserControllerTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Act
            JsonParserController controller = new JsonParserController();

            // Assert
            Assert.IsNotNull(controller);
            Assert.IsNotNull(controller.JsonParser);
        }

        [TestMethod]
        public void TestPostAddToOrder()
        {
            // Arrange
            JsonParserController controller = new JsonParserController();
            ProductModel product = new ProductModel();
            product.Price = 1000;
            product.Description = "Test 1";

            // Act
            controller.PostAddToOrder(product);

            // Assert
            Assert.AreEqual(1000, controller.JsonParser.GetOrderFromJson(controller.JsonParser.ParseFromJSON("Order.json"))[0].Price);
            Assert.AreEqual("Test 1", controller.JsonParser.GetOrderFromJson(controller.JsonParser.ParseFromJSON("Order.json"))[0].Description);
            controller.JsonParser.ClearOrder();
        }
    }
}
