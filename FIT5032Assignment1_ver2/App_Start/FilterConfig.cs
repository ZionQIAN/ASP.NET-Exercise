﻿using System.Web;
using System.Web.Mvc;

namespace FIT5032Assignment1_ver2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
