using System;
using System.Web;

namespace GameStore.REST
{
    public class GlobalREST : HttpApplication
    {

        protected void Application_Start()
        {
            string dbPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\Databases"));
            Console.Write(dbPath);
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);
        }
    }
}
