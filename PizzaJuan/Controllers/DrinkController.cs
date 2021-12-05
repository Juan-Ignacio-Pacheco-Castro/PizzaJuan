using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class DrinkController : JsonParserController
    {
        public ActionResult ChooseBeverage() {
            ViewBag.Beverages = JsonParser.ParseFromJSON("Beverages.json");
            return View("ChooseBeverage");
        }
    }
}