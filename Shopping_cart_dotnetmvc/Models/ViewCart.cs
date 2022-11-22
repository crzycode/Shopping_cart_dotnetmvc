using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class ViewCart
    {
        public int Viewcart_product_id { get; set; }
        public string Viewcart_product_name { get; set; }
        public string Viewcart_product_image { get; set; }
        public int Viewcart_product_quantity { get; set; }
        public int Viewcart_product_price { get; set; }
        public string Viewcart_product_totalprice { get; set; }
    }

}