using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class PizzaController : JsonParserController
    {
        public ActionResult CreatePizza()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            ViewBag.Bases = JsonParser.ParseFromJSON("Bases.json");
            ViewBag.Sizes = JsonParser.ParseFromJSON("Sizes.json");
            ViewBag.Ingredients = JsonParser.ParseFromJSON("Ingredients.json");
            return View();
        }

        public ActionResult ChoosePizza() {
            ViewBag.PizzaTypes = JsonParser.ParseFromJSON("PizzaTypes.json");
            ViewBag.Sizes = JsonParser.ParseFromJSON("Sizes.json");
            ViewBag.Ingredients = JsonParser.ParseFromJSON("Ingredients.json");
            return View();
        }

        [HttpPost]
        public ActionResult PostChoosePizza(ProductModel product) {
            ActionResult view = RedirectToAction("Menu", "Menu");
            bool hasTypeAndSize = PizzaIsComplete(product.Description);
            if (hasTypeAndSize) {
                JsonParser.WriteToJsonFile<ProductModel>("Order.json", product, JsonParser.GetOrderFromJson);
                return view;
            } else {
                TempData["Message"] = "Es requerido seleccionar tipo y tamaño de la pizza";
                view = RedirectToAction("ChoosePizza", "Pizza");
                return view;
            }
        }

        private bool PizzaIsComplete(string description) {
            dynamic pizzaTypes = JsonParser.ParseFromJSON("PizzaTypes.json");
            dynamic pizzaSizes = JsonParser.ParseFromJSON("Sizes.json");
            if (description != null) { 
                foreach (var type in pizzaTypes) {
                    if (description.Contains(type.Name)) {
                        foreach (var size in pizzaSizes) {
                            if (description.Contains(size.Name)) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}