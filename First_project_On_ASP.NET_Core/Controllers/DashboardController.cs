using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Shop.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDBContent content;

        public DashboardController(AppDBContent content)
        {
            this.content = content;
        }

        public IActionResult Personal_Account()
        {
            var getUserInfo = HttpContext.Session.GetString("User");
            var jsonDeserializeUser = JsonSerializer.Deserialize<User>(getUserInfo);

            return View(jsonDeserializeUser);
        }

        [HttpGet]
        public IActionResult EditPersonalData()
        {
            var getUserInfo = HttpContext.Session.GetString("User");
            var jsonDeserializeUser = JsonSerializer.Deserialize<User>(getUserInfo);

            return View(jsonDeserializeUser);
        }

        [HttpPost]
        public IActionResult EditPersonalData(User user, int id)
        {
            var findUser = content.User.FirstOrDefault(u => u.id == id);

            findUser.name = user.name;
            findUser.surname = user.surname;
            findUser.middlName = user.middlName;
            findUser.age = user.age;
            findUser.login = user.login;
            findUser.phoneNumber = user.phoneNumber;
            findUser.email = user.email;

            content.User.Update(findUser);
            content.SaveChanges();

            var findUpdateUser = content.User.FirstOrDefault(u => u.id == id);

            HttpContext.Session.Remove("User");

            var serializationUser = JsonSerializer.Serialize(findUpdateUser);
            HttpContext.Session.SetString("User", serializationUser);

            return View("Personal_Account", findUpdateUser);
        }

        [HttpGet]
        public IActionResult HistoryRent()
        {

            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login", "Account");
            }

            var userDeserialize = JsonSerializer.Deserialize<User>(user);

            // Отримуємо повернені замовлення з підвантаженням всіх необхідних даних
            var returnedOrderIds = content.OrderDetailReturn
                .Where(c => c.isReturning == true)
                .Include(c => c.orderDetail)
                    .ThenInclude(od => od.car) // Додаємо підвантаження автомобіля
                .Include(c => c.orderDetail)
                    .ThenInclude(od => od.user) // Додаємо підвантаження користувача
                .Include(c => c.placeReturn)
                .ToList();

            var result = returnedOrderIds.Where(c => c.orderDetail.user.id == userDeserialize.id).ToList();


            // Створюємо модель і гарантуємо, що список не буде null
            var modelReturnAuto = new SmartReturnAutoForCustomerViewModel
            {
                userNotActiveOrders = result ?? new List<OrderDetailReturn>() // Забезпечуємо, що список не null
            };

            return View(modelReturnAuto);
        }
    }
}
