using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class PizzaController : Controller
    {
        public JsonParser JsonParser { get; set; }

        public PizzaController() {
            JsonParser = new JsonParser();
        }


        public ActionResult CreatePizza()
        {
            ViewBag.Bases = JsonParser.ParseFromJSON("Bases.json");
            ViewBag.Sizes = JsonParser.ParseFromJSON("Sizes.json");
            ViewBag.Ingredients = JsonParser.ParseFromJSON("Ingredients.json");
            return View();
        }
    }
}