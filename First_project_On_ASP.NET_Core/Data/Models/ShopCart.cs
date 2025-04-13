using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Shop.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public  List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();


            if (session.GetString("User") == null)
            {
                return new ShopCart(context);
            }

            var userDeserialization = JsonSerializer.Deserialize<User>(session.GetString("User"));

            if (userDeserialization.ShopCartId == null)
            {
                string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
                userDeserialization.ShopCartId = shopCartId;

                session.SetString("CartId", shopCartId);

                context.User.Update(userDeserialization);
                context.SaveChanges();

                return new ShopCart(context) { ShopCartId = shopCartId };
            }
            else
            {                            
                return new ShopCart(context) { ShopCartId = userDeserialization.ShopCartId };
            }
        }

        public void AddToCart (Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem 
            { 
                ShopCartId = ShopCartId,
                CarID = car.id,   // 🔹 Тепер явно зберігаємо ID машини
                car = car,
                price = car.price,
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems ()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
