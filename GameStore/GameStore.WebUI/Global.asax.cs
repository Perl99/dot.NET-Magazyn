﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "..\\Databases"));
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
        }
    }
}
