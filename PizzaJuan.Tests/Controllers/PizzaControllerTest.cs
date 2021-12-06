using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers {
    [TestClass]
    public class PizzaControllerTest {
        [TestMethod]
        public void TestCreatePizzaViewResultNotNull()
        {
            // Arrange
            PizzaController controller = new PizzaController();

            // Act
            ViewResult result = controller.CreatePizza() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("CreatePizza", result.ViewName);
        }

        [TestMethod]
        public void TestChoosePizzaViewResultNotNull()
        {
            // Arrange
            PizzaController controller = new PizzaController();

            // Act
            ViewResult result = controller.ChoosePizza() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ChoosePizza", result.ViewName);
        }



        [TestMethod]
        public void TestPostChoosePizzaWithDeficientValues() {
            // Arrange
            PizzaController controller = new PizzaController();
            ProductModel product = new ProductModel();
            product.Price = 1000;
            product.Description = "Test";

            // Act
            controller.PostChoosePizza(product);

            // Assert
            Assert.AreEqual(0, controller.JsonParser.GetOrderFromJson(controller.JsonParser.ParseFromJSON("Order.json")).Count);
        }

        [TestMethod]
        public void TestPostChoosePizzaWithSufficientValues()
        {
            // Arrange
            PizzaController controller = new PizzaController();
            ProductModel product = new ProductModel();
            product.Price = 1000;
            product.Description = "Suprema,Personal";

            // Act
            controller.PostChoosePizza(product);

            // Assert
            Assert.AreEqual(1, controller.JsonParser.GetOrderFromJson(controller.JsonParser.ParseFromJSON("Order.json")).Count);
            controller.JsonParser.ClearOrder();
        }

        [TestMethod]
        public void TestPizzaIsCompleteWithDeficientValues()
        {
            // Arrange
            PizzaController controller = new PizzaController();
            PrivateObject obj = new PrivateObject(controller);
            ProductModel product = new ProductModel();
            product.Price = 1000;
            product.Description = "Test";

            // Act
            var result = obj.Invoke("PizzaIsComplete", product.Description);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestPizzaIsCompleteWithSufficientValues()
        {
            // Arrange
            PizzaController controller = new PizzaController();
            PrivateObject obj = new PrivateObject(controller);
            ProductModel product = new ProductModel();
            product.Price = 1000;
            product.Description = "Suprema,Personal";

            // Act
            var result = obj.Invoke("PizzaIsComplete", product.Description);

            // Assert
            Assert.AreEqual(true, result);
        }


    }
}
