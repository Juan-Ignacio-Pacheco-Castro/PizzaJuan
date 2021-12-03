using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class MenuController : Controller
    {
        public JsonParser JsonParser { get; set; }

        public MenuController() {
            JsonParser = new JsonParser();
        }

        public ActionResult Menu() {
            return View();
        }
    }
}