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
using System.Runtime.CompilerServices;
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
           

            if (context.ShopCartItem.FirstOrDefault( s => s.UserId == userDeserialization.id) == null)// context.ShopCartItem.ShopCartId()
            {
                string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();                 

                session.SetString("CartId", shopCartId);               

                return new ShopCart(context) { ShopCartId = shopCartId };
            }
            else
            {
                var shopCartItem = context.ShopCartItem.FirstOrDefault(u => u.UserId == userDeserialization.id);

                string shopCartId = shopCartItem.ShopCartId;


                return new ShopCart(context) { ShopCartId = shopCartId };
            }
            
        }

        public void AddToCart (Car car, int UserID)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem 
            { 
                ShopCartId = ShopCartId,
                CarID = car.id,   // 🔹 Тепер явно зберігаємо ID машини
                UserId = UserID,
                car = car,
                price = car.price,
            });

            appDBContent.SaveChanges();
        }

        public void DeleteToCard (Car car)
        {
            var item = appDBContent.ShopCartItem
               .FirstOrDefault(i => i.ShopCartId == ShopCartId && i.CarID == car.id);

            if (item != null)
            {
                appDBContent.ShopCartItem.Remove(item);
                appDBContent.SaveChanges();
            }

            appDBContent.SaveChanges();

           
        }


        public List<ShopCartItem> getShopItems ()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
