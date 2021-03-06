using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace PizzaJuan.Models {
    public class JsonParser {
        private string[] ExtractRawContent(string fileName) {
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data_Files/" + fileName), Encoding.UTF8);
        }

        public string ParseRawJson(string[] content) {
            string contentExtracted = "";
            foreach (string line in content) {
                contentExtracted += line + "\n";
            }
            return contentExtracted;
        }

        public dynamic ParseFromJSON(string fileName) {
            dynamic parsedContent = "";
            try {
                string[] rawData = ExtractRawContent(fileName);
                string contentReadyToParse = ParseRawJson(rawData);
                parsedContent = JsonConvert.DeserializeObject(contentReadyToParse);
            } catch (Exception e) {
                string error = "Error while parsing JSON raw data \n" + e.ToString();
                Debug.WriteLine(error);
            }
            return parsedContent;
        }

        public bool WriteToJsonFile<Model>(string fileName, Model model, Func<dynamic, List<Model>> GetModelsFromJson) {
            bool success = false;
            string jsonString = JoinNewData<Model>(fileName, model, GetModelsFromJson);
            try {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data_Files/" + fileName), jsonString);
                success = true;
            } catch {
                Debug.WriteLine("Error occurred");
            }
            return success;
        }

        public string JoinNewData<Model>(string fileName, Model model, Func<dynamic, List<Model>> GetModelsFromJson) {
            string resultingJson = "";
            try {
                string[] rawJson = ExtractRawContent(fileName);
                string json = ParseRawJson(rawJson);
                dynamic jsonCollection = JsonConvert.DeserializeObject(json);
                List<Model> previousModels = GetModelsFromJson(jsonCollection);

                previousModels.Add(model);
                resultingJson = JsonConvert.SerializeObject(previousModels);
            } catch {
                resultingJson = "Error ocurred";
            }
            return resultingJson;
        }

        public List<ProductModel> GetOrderFromJson(dynamic jsonCollection) {
            List<ProductModel> order = new List<ProductModel>();
            foreach (var element in jsonCollection) {
                order.Add(new ProductModel {
                    Description = element.Description,
                    Price = element.Price
                });
            }
            return order;
        }

        public List<DeliveryModel> GetDeliveryFromJson(dynamic jsonCollection) {
            List<DeliveryModel> delivery = new List<DeliveryModel>();
            foreach (var element in jsonCollection) {
                delivery.Add(new DeliveryModel {
                    Type = element.Type
                });
            }
            return delivery;
        }

        public int GetDebitAmount() {
            List<ProductModel> order = new List<ProductModel>();
            string[] rawJson = ExtractRawContent("Order.json");
            string json = ParseRawJson(rawJson);
            dynamic jsonCollection = JsonConvert.DeserializeObject(json);
            order = GetOrderFromJson(jsonCollection);
            int debitAmount = 0;
            foreach (var element in order) {
                debitAmount += element.Price;
            }
            return debitAmount;
        }

        public void DeleteFromOrder(ProductModel model) {
            List<ProductModel> order = new List<ProductModel>();
            string[] rawJson = ExtractRawContent("Order.json");
            string json = ParseRawJson(rawJson);
            dynamic jsonCollection = JsonConvert.DeserializeObject(json);
            order = GetOrderFromJson(jsonCollection);
            var itemToRemove = order.Single(r => r.Description == model.Description);
            order.Remove(itemToRemove);
            var resultJson = JsonConvert.SerializeObject(order);
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data_Files/Order.json"), resultJson);
        }

        public void ClearOrder() {
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data_Files/Order.json"), "[]");
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data_Files/Delivery.json"), "[]");
        }
    }
}