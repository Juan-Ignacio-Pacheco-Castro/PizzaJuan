using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}