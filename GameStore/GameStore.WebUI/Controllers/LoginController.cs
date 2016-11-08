using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using Ninject;

namespace GameStore.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private IUserRepository repository;

        public LoginController(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = repository.Users.Single(u => u.Login == user.Login && u.Password == user.Password);
            if (usr != null)
            {
                Session["UserId"] = usr.UserId.ToString();
                Session["Login"] = usr.Login.ToString();
                if (Session["UserID"] != null)
                {
                    return RedirectToAction("List", "Product");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login lub hasło nie prawidłowe");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserId,Type,Name,Surname,Login,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserId <= 0)
                {
                    repository.Add(user);
                }
                else
                {
                    repository.Save(user);
                }
            }
            return View();
        }
    }
}