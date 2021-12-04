using System;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace PizzaJuan.Models {
    public class ProductModel {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }
    }
}