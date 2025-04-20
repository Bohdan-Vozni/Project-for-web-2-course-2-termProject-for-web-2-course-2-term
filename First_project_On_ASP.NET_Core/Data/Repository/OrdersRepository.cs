using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository (AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.listShopItems;


            foreach (var el in items)
            {
                //bool carExists = appDBContent.Car.Any(c => c.id == el.id);
                //if (!carExists)
                //{
                //    throw new Exception($"Помилка: CarID {el.id} не існує в таблиці Car!");
                //}

                var orderDerail = new OrderDetail()
                {
                    CarID = el.CarID,
                    orderID = order.id,
                    // додати користувача
                };

                appDBContent.OrderDetailUp.Add(orderDerail);
            }

            appDBContent.SaveChanges();
         
        }
    }
}
