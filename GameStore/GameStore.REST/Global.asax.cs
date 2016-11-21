using System;
using System.Web;

namespace GameStore.REST
{
    public class Global : HttpApplication
    {

        protected void Application_Start()
        {
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "..\\Databases"));
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
        }
    }
}
