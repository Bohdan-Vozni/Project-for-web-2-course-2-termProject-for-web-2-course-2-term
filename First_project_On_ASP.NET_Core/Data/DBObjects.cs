using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Shop.Data.Models;
using Shop.Migrations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if(content.User.Any())
            {
               // content.User.
            }

            if (!content.User.Any())
            {
                content.User.AddRange(Users.Select(c => c.Value));
            }

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                new Car
                {
                    name = "Tesla",
                    shortDesc = "",
                    img = "/img/teslavodel3.jpg",
                    price = 4500,
                    isFavourite = true,
                    category = Categories["Електромобіль"]
                },

                new Car
                {
                    name = "Tesla",
                    shortDesc = "",
                    img = "/img/teslavodel3.jpg",
                    price = 4500,
                    isFavourite = true,
                    category = Categories["Електромобіль"]
                },

                new Car
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = Categories["класичний автомобіль"]
                }
                    );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Електромобіль" , desc = " сідан електоромобіль"},
                        new Category {categoryName = "класичний автомобіль" , desc = "з двигуном внутрішнього згорання"}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (var el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }

        public static Dictionary<string, User> user;

        public static Dictionary<string, User> Users
        {
            get
            {
                if ( user == null)
                {
                    var list = new User[]
                    {
                        new User { name = "Bohdan", surname = "Vozni", middlName = "Oleksandrovuch", age = 18, phoneNumber = "0960849073", email = "daster708@ukr.net", login = "Bohdan", password = "Bohdan", isAdmin = false},
                        new User { name = "Bohdan", surname = "Vozni", middlName = "Oleksandrovuch", age = 18, phoneNumber = "0960849073", email = "daster708@ukr.net", login = "sa", password = "sa", isAdmin = true}
                    };

                    user = new Dictionary<string, User>();

                    foreach (var el in list)
                    {
                        user.Add(el.login, el);
                    }
                }
                return user;
            }
            
        }
    }
}
