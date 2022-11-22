using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.Models
{
    public class User_info
    {
        [Key]
        public int uiid { get; set; }
        public string firsname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public long phonenumber { get; set; }
        public long landline { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public string houseno { get; set; }
        public int userinfo_id { get; set; }

    }
}