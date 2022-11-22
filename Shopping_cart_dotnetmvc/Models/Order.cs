using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class Order
    {
        [Key]
        public int Order_id { get; set; }
        public long Order_cart_id { get; set; }
        public string Order_no { get; set; }
        public int Order_total_price { get; set; }
        public int Order_user_id { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Order_created_at { get; set; } 
    }
}