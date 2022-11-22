using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Product_price { get; set; }
        public string Product_image { get; set; }
        public string Product_category { get; set; }

    }
}