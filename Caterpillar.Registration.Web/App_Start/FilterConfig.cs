﻿using System.Web;
using System.Web.Mvc;

namespace Caterpillar.Registration.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
