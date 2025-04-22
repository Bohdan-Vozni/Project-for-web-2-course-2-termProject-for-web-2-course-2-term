using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Linq;
using System.Text.Json;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {

      
        
        private readonly AppDBContent appDBContent;
        private static int IdCarForWrite;

        public OrderController(  AppDBContent appDBContent)
        {
            
            
            this.appDBContent = appDBContent;
        }

        [HttpGet]
        public IActionResult Checkout(int idCar)
        {
            IdCarForWrite = idCar;
           

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            

           

            if(ModelState.IsValid)
            {
                createOrder(order);
                return RedirectToAction("Complete");
            }


            return View(order);
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var UserSerialilize = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("User"));

            var car = appDBContent.Car.FirstOrDefault(c => c.id == IdCarForWrite);

            var orderDerail = new OrderDetail()
            {
                orderID = order.id,
                CarID = IdCarForWrite,
                userId = UserSerialilize.id,
                placeId = car.placeID,

            };

            appDBContent.OrderDetailUp.Add(orderDerail);


            appDBContent.SaveChanges();

        }

        public IActionResult Complete()
        {
            ViewBag.Messege = "Заказ успішно оброблений";
            return View();
        }
    }
}
