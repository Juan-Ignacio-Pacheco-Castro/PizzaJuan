using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class DeliveryController : JsonParserController
    {
        public ActionResult Express() {
            return View();
        }

        public ActionResult Takeout() {
            ViewBag.Restaurants = JsonParser.ParseFromJSON("Restaurants.json");
            return View();
        }

        [HttpPost]
        public ActionResult PostDelivery(DeliveryModel delivery) {
            ActionResult view = RedirectToAction("Menu", "Menu");
            JsonParser.WriteToJsonFile<DeliveryModel>("Delivery.json", delivery, JsonParser.GetDeliveryFromJson);
            return view;
        }
    }
}