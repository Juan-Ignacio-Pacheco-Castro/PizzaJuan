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
            ViewBag.DebitAmount = JsonParser.GetDebitAmount();
            ViewBag.Delivery = JsonParser.GetDeliveryFromJson(JsonParser.ParseFromJSON("Delivery.json"));
            return View();
        }

        [HttpPost]
        public ActionResult PostOrder(ProductModel product) {
            ActionResult view = RedirectToAction("Order", "Menu");
            JsonParser.DeleteFromOrder(product);
            return view;
        }

        public ActionResult Receipt() {
            ViewBag.Order = JsonParser.GetOrderFromJson(JsonParser.ParseFromJSON("Order.json"));
            ViewBag.Delivery = JsonParser.GetDeliveryFromJson(JsonParser.ParseFromJSON("Delivery.json"));
            return View();
        }
    }
}