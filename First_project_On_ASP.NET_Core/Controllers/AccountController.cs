using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;


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
                    var jsonSerialiseUser = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("User", jsonSerialiseUser);
                   
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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUP(User user)
        {
            var availableUser = content.User.FirstOrDefault(u => u.login == user.login);
            if (availableUser != null)
            {
                ModelState.AddModelError("login", "Даний користувач існує з таким логіном");
            }

            if (ModelState.IsValid && availableUser == null )
            {
                if (string.IsNullOrEmpty(user.login))
                {
                    ModelState.AddModelError("login", "Логін не може бути порожнім");
                    return View(user);
                }

                content.User.Add(user);
                content.SaveChanges();

                //DBObjects.userToWrite = user;
               // DBObjects.UserWriteToDBRecordOFSignUp(content);
                return RedirectToAction("Login", "Account");
            }
           
            return View(user);

        }
    }
}
