﻿using System.Web;
using System.Web.Mvc;

namespace Shopping_cart_dotnetmvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
