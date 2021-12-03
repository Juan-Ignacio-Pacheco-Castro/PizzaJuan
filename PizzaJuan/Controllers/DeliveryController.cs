using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class DeliveryController : JsonParserController
    {
        public ActionResult ComboOptions() {
            ViewBag.Combos = JsonParser.ParseFromJSON("Combos.json");
            return View();
        }
    }
}