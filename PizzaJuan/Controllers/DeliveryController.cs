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
    }
}