using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using System.Diagnostics;
using System.Linq;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContent content;
        public AccountController (AppDBContent content)
        {
            this.content = content;
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = content.User.FirstOrDefault(u => u.login == model.login && u.password == model.password);

                if (user != null)
                {
                    HttpContext.Session.SetString("User", user.name);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Error with login or password");

            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

    }
}
