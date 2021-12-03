using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class ComboController : Controller
    {
        public JsonParser JsonParser { get; set; }

        public ComboController() {
            JsonParser = new JsonParser();
        }

        public ActionResult ComboOptions() {
            ViewBag.Combos = JsonParser.ParseFromJSON("Combos.json");
            return View();
        }
    }
}