using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class ComboController : JsonParserController
    {
        public ActionResult ComboOptions() {
            ViewBag.Combos = JsonParser.ParseFromJSON("Combos.json");
            return View();
        }
    }
}