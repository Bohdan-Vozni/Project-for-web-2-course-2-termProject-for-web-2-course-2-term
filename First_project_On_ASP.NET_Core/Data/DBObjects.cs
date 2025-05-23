using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Shop.Data.Models;
using Shop.Migrations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public  class DBObjects 
    {
        public static User userToWrite { get; set; }

        public static void UserWriteToDBRecordOFSignUp(AppDBContent content)
        {
            if (userToWrite != null)
            {
                content.User.Add(userToWrite);
                content.SaveChanges();
                userToWrite = null;
            }
        }

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

            if( !content.Places.Any())
            {
                content.Places.AddRange(Place.Select(c => c.Value));
                content.SaveChanges();
            }

            var first = content.Places.First();
            //var last = content.Places.Last();

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
                    available = true,
                    category = Categories["Електромобіль"],
                    placeID = first.Id,

                },

                new Car
                {
                    name = "Tesla",
                    shortDesc = "",
                    img = "/img/teslavodel3.jpg",
                    price = 4500,
                    isFavourite = true,
                    available = true,
                    category = Categories["Електромобіль"],
                    placeID = first.Id
                },

                new Car
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    available = true,
                    category = Categories["класичний автомобіль"],
                    placeID = first.Id + 1
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

        public static Dictionary<string, Place> place;

        public static Dictionary<string , Place> Place
        {
            get
            {
                if (place == null)
                {
                    var list = new Place[]
                    {
                        new Place { placeName = "ВДНГ", address = "вул. Академіка Глушкова 1", desc = "Станція метро Виставковий центр" },
                        new Place { placeName = "Іподром", address = "проспект Академіка Глушкова", desc = "Станція метро Іподром" },
                        new Place { placeName = "Теремки", address = "проспект Академіка Глушкова", desc = "Станція метро Теремки" },
                        new Place { placeName = "Либідська", address = "вул. Антоновича", desc = "Станція метро Либідська" },
                        new Place { placeName = "Палац Україна", address = "вул. Велика Васильківська 103", desc = "Станція метро Палац Україна" },
                        new Place { placeName = "Олімпійська", address = "вул. Велика Васильківська", desc = "Станція метро Олімпійська" },
                        new Place { placeName = "Університет", address = "вул. Володимирська", desc = "Станція метро Університет" }
                    };



                    place = new Dictionary<string, Place>();

                    foreach (var el in list)
                    {
                        place.Add(el.placeName, el);
                    }

                }
                return place;
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
