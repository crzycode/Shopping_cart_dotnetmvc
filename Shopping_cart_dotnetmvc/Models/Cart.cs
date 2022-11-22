using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }
        public long Cart_user_id { get; set; }
        public int Cart_product_id { get; set; }
        public int Cart_quantity { get; set; }
    }
}