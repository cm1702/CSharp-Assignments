﻿using System.Web;
using System.Web.Mvc;

namespace Assessment1_ques2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
