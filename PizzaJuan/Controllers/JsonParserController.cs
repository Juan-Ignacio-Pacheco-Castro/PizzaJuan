using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class JsonParserController : Controller
    {
        public JsonParser JsonParser { get; set; }

        public JsonParserController() {
            JsonParser = new JsonParser();
        }

        [HttpPost]
        public ActionResult PostAddToOrder(ProductModel product) {
            ActionResult view = RedirectToAction("Menu", "Menu");
            JsonParser.WriteToJsonFile<ProductModel>("Order.json", product, JsonParser.GetOrderFromJson);
            return view;
        }
    }
}