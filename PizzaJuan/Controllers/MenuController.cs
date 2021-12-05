using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaJuan.Models;

namespace PizzaJuan.Controllers
{
    public class MenuController : JsonParserController
    {
        public ActionResult Menu() {
            ViewBag.DebitAmount = JsonParser.GetDebitAmount();
            return View();
        }

        public ActionResult Order() {
            ViewBag.Order = JsonParser.GetOrderFromJson(JsonParser.ParseFromJSON("Order.json"));
            return View();
        }
    }
}