using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class prod
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public int product_quantity { get; set; }
        public int pricexquantity { get; set; }
    }
    public class ConfirmOrder
    {
        public IEnumerable<prod> Product { get; set; }
        public int Totalamount { get; set; }

    }
}