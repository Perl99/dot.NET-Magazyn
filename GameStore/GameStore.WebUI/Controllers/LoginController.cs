using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if ("admin".Equals(name) && "admin".Equals(password))
            {
                Session["user"] = new User()
                {
                    Login = name,
                    Name = "XXX",
                    Surname = "WOW",
                    Password = password
                };
                return RedirectToAction("List", "Product");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("List", "Product");
        }
    }
}