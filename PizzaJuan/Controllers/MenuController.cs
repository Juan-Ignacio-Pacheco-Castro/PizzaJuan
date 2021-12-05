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
            return View();
        }

        [HttpPost]
        public ActionResult PostOrder(ProductModel product) {
            ActionResult view = RedirectToAction("Order", "Menu");
            try {
                JsonParser.DeleteFromOrder(product);
                return view;
            } catch {
                //view = RedirectToAction("CreatePizza", "Pizza");
                //ViewBag.Message = "Algo salió mal y no fue posible crear el funcionario";
                return view;
            }
        }

        public ActionResult Buy() {
            ViewBag.Order = JsonParser.GetOrderFromJson(JsonParser.ParseFromJSON("Order.json"));
            return View();
        }
    }
}