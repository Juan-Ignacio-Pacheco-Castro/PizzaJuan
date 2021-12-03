using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class DrinkController : Controller
    {
        public JsonParser JsonParser { get; set; }

        public DrinkController() {
            JsonParser = new JsonParser();
        }

        public ActionResult ChooseBeverage() {
            ViewBag.Beverages = JsonParser.ParseFromJSON("Beverages.json");
            return View();
        }
    }
}