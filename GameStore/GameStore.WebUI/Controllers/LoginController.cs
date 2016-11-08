using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

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
            if (ModelState.IsValid)
            {
                var usr = repository.FindByLoginAndPassword(user.Login, user.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.Id.ToString();
                    Session["Login"] = usr.Login.ToString();
                    if (Session["UserID"] != null)
                    {
                        return RedirectToAction("List", "Product");
                    }
                }
                else
                    ModelState.AddModelError("", "Nieprawidłowe dane");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("List", "Product");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Type,Name,Surname,Login,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id <= 0)
                {
                    repository.Add(user);
                    return RedirectToAction("Login", "Login");
                }
            }
            return View();
        }
    }
}