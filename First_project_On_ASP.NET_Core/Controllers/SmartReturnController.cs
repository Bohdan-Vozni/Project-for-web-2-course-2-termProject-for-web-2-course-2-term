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
                personWhoReturn = userDeserialize.name + " " + userDeserialize.surname + " " + userDeserialize.middlName,
                price = orderDetailFind.car.price,
                isReturning = false,
            };

            // оновити місце положення авто

            content.Add(orderDetailReturn);
            content.SaveChanges();

            return RedirectToAction("ReturnAuto");
        }
    }
}
