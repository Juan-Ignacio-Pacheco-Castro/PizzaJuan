using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaJuan.Controllers {
    public class HomeController : JsonParserController {
        public ActionResult Index() {
            JsonParser.ClearOrder();
            return View();
        }
    }
}