using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PizzaJuan.Models;

namespace PizzaJuan.Tests.Controllers {
    [TestClass]
    public class JsonParserTest {
        [TestMethod]
        public void TestMethodGetOrderFromJsonInJsonParser() {
            // Arrange
            JsonParser parser = new JsonParser();

            // Act
            string json = "[{\"Description\": \"Pizza Jamon Grande con extra de tomate\",\"Price\": 2000}]";
            dynamic jsonCollection = JsonConvert.DeserializeObject(json);
            List<ProductModel> productModels = parser.GetOrderFromJson(jsonCollection);

            // Assert
            Assert.IsNotNull(productModels);
            Assert.AreEqual(productModels.Count, 1);
            Assert.AreEqual(productModels.First().Price, 2000);
        }

        [TestMethod]
        public void TestMethodJoinNewDataInJsonParser() {
            // Arrange
            JsonParser parser = new JsonParser();
            ProductModel product = new ProductModel();
            product.Price = 3000;
            product.Description = "Hello world";

            // Act
            string jsonString = parser.JoinNewData<ProductModel>("Order.json", product, parser.GetOrderFromJson);

            // Assert
            string result = "[{\"Price\":2000,\"Description\":\"Pizza Jamon Grande con extra de tomate\"},{\"Price\":3000,\"Description\":\"Hello world\"}]";
            Assert.IsNotNull(jsonString);
            Assert.AreEqual(result, jsonString);
        }

        [TestMethod]
        public void TestMethodExtractRawContentInJsonParser() {
            // Arrange
            JsonParser parser = new JsonParser();
            PrivateObject obj = new PrivateObject(parser);

            // Act
            var retVal = obj.Invoke("ExtractRawContent", "Order.json");

            // Assert
            Assert.IsNotNull(retVal);
        }
    }
}
