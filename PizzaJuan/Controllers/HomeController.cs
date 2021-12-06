using System.Web.Mvc;

namespace PizzaJuan.Controllers {
    public class HomeController : JsonParserController {
        public ActionResult Index() {
            JsonParser.ClearOrder();
            return View();
        }
    }
}