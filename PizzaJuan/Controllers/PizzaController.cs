using System.Web;
using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class PizzaController : JsonParserController
    {
        
        public ActionResult CreatePizza()
        {
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["UserName"] = "Annathurai";
            userInfo["UserColor"] = "Black";
            Response.Cookies.Add(userInfo);
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
    }
}