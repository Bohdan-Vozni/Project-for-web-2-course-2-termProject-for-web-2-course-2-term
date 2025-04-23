using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Shop.Controllers
{
    public class SmartReturnController : Controller
    {
        private AppDBContent content;
        private IAllCars allCars;
        public IAllPlace allPlace;

        public SmartReturnController(AppDBContent content, IAllCars allCars, IAllPlace allPlace) 
        {
            this.content = content;
            this.allCars = allCars;
            this.allPlace = allPlace;
        }

        public IActionResult ListFunc()
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login", "Account"); // Перенаправлення, якщо користувач не авторизований
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReturnAuto()
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login", "Account"); // Перенаправлення, якщо користувач не авторизований
            }
            var userDeserialize = JsonSerializer.Deserialize<User>(user);

            // Отримуємо ID всіх повернених замовлень
            var returnedOrderIds = content.OrderDetailReturn
                .Select(r => r.orderDetailId)  // Використовуємо правильну властивість для зв'язку
                .ToList();

            // Отримуємо всі взяті автомобілі поточного користувача, які ще не повернуті
            var userActiveOrders = content.OrderDetailUp
                .Where(od => od.userId == userDeserialize.id &&
                            !returnedOrderIds.Contains(od.id))
                .Include(od => od.car)  // Підвантажуємо пов'язані дані про автомобіль
                .Include(od => od.place) // Підвантажуємо дані про місце
                .Include(od => od.order)
                .Include(od => od.user)
                .ToList();


            var modelOrder = new SmartReturnAutoForCustomerViewModel
            {
                userActiveOrders = userActiveOrders,
                allPlace = allPlace.getAllPlace,
            };

            return View(modelOrder);
            
        }

        [HttpPost]
        public IActionResult ReturnAuto(SmartReturnAutoForCustomerViewModel orderDetail, int idOrderTake)
        {
            var userActiveOrders = content.OrderDetailUp
              .Include(o => o.car)
              .Include(od => od.user)
              .Include(od => od.order)
              .Include(o => o.place)
              .FirstOrDefault(o => o.id == idOrderTake);

            var userActiveOrdersList = new List<OrderDetail>();
            if (userActiveOrders != null)
            {
                userActiveOrdersList.Add(userActiveOrders);
            }

            var modelOrder = new SmartReturnAutoForCustomerViewModel
            {
                userActiveOrders = userActiveOrdersList,
                allPlace = allPlace.getAllPlace,
            };

            return View(modelOrder);
        }

        [HttpPost]
        public IActionResult AddOrderDetailReturn(SmartReturnAutoForCustomerViewModel orderDetail, int idOrderTake)
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login", "Account"); // Перенаправлення, якщо користувач не авторизований
            }
            var userDeserialize = JsonSerializer.Deserialize<User>(user);

            var orderDetailFind = content.OrderDetailUp
                .Include(o => o.car)
                .Include(od => od.user)
                .Include(od => od.order)
                .Include(o => o.place)
                .FirstOrDefault(o => o.id == idOrderTake);

            var orderDetailReturn = new OrderDetailReturn
            {
                orderDetailId = idOrderTake,
                placeReturnID = orderDetail.idPlace,
                dataTime_return = DateTime.Now,             
                isReturning = false,
            };
            content.Add(orderDetailReturn);


            // оновити місце положення авто

            var carForUpdate = content.Car.FirstOrDefault( c => c.id == orderDetailFind.car.id);
            carForUpdate.placeID = orderDetail.idPlace;
            content.Car.Update(carForUpdate);

            content.SaveChanges();

            return RedirectToAction("ReturnAuto");
        }

        [HttpGet]
        public IActionResult CheckReturnAuto()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Login", "Account");
            }

            var userDeserialize = JsonSerializer.Deserialize<User>(user);

            // Отримуємо повернені замовлення з підвантаженням всіх необхідних даних
            var returnedOrderIds = content.OrderDetailReturn
                .Where(c => c.isReturning == false)
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
