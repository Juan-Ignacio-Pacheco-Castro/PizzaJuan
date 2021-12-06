using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers
{
    [TestClass]
    public class MenuControllerTest
    {
        [TestMethod]
        public void TestMenuViewResultNotNull()
        {
            // Arrange
            MenuController controller = new MenuController();

            // Act
            ViewResult result = controller.Menu() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Menu", result.ViewName);
        }

        [TestMethod]
        public void TestOrderViewResultNotNull()
        {
            // Arrange
            MenuController controller = new MenuController();

            // Act
            ViewResult result = controller.Order() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Order", result.ViewName);
        }

        [TestMethod]
        public void TestReceiptViewResultNotNull()
        {
            // Arrange
            MenuController controller = new MenuController();

            // Act
            ViewResult result = controller.Receipt() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Receipt", result.ViewName);
        }

        [TestMethod]
        public void TestPostOrder()
        {
            // Arrange
            MenuController controller = new MenuController();
            JsonParserController addition = new JsonParserController();
            ProductModel product = new ProductModel();
            product.Description = "Test Post Order";
            product.Price = 1000;
            addition.PostAddToOrder(product);


            // Act
            controller.PostDeleteFromOrder(product);

            // Assert
            Assert.AreEqual(0, controller.JsonParser.GetOrderFromJson(controller.JsonParser.ParseFromJSON("Order.json")).Count);
        }
    }
}
