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

        public ActionResult CreatePizza()
        {
            ViewBag.Bases = 


            return View();
        }
    }
}