using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaJuan.Controllers;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers {
    [TestClass]
    public class PizzaControllerTest {
        [TestMethod]
        public void TestPostCreatePizza() {
            // Arrange
            PizzaController controller = new PizzaController();
            ProductModel product = new ProductModel();
            JsonParser parser = new JsonParser();
            product.Price = 2000;
            product.Description = "Combos de los Tios";

            // Act
            //controller.PostCreatePizza(product);
            parser.WriteToJsonFile<ProductModel>("Order.json", product, parser.GetOrderFromJson);

            // Assert
            //Assert.AreEqual(parser.ParseFromJSON("Order.json")["Price"], 2000);
        }
    }
}
