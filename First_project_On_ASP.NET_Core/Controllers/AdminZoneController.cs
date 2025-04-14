using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Shop.Controllers
{
    public class AdminZoneController : Controller
    {
        private readonly ICarsCategory _allCategories;
        private readonly IAllCars _allCars;
        private AppDBContent content;

        public AdminZoneController (AppDBContent content, ICarsCategory allCategory)
        {
            this.content = content;
            _allCategories = allCategory;
        }
        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuto()
        {
            var AdminAddChangeAutoViewModel = new AdminAddChangeAutoViewModel {allCategory =_allCategories };
            return View(AdminAddChangeAutoViewModel);
        }

        [HttpPost]
        public IActionResult AddAuto(AdminAddChangeAutoViewModel obj)
        {
            string imagepath = "/img/default.png";

            if (obj.ImageUpload != null && obj.ImageUpload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.ImageUpload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    obj.ImageUpload.CopyTo(stream);
                }

                imagepath = "/img/" + fileName; // для збереження в бд
            }

            Car car = new Car
            {
                name = obj.Car.name,
                shortDesc = obj.Car.shortDesc,
                longDesc = obj.Car.longDesc,
                img = imagepath,
                price = obj.Car.price,
                isFavourite = (bool)obj.Car.isFavourite,
                available = (bool)obj.Car.available,
                categoryID = obj.Car.categoryID,
            };

            content.Car.Add(car);
            content.SaveChanges();

            return RedirectToAction("AdminHome");
        }

        [HttpGet]
        public IActionResult FindAutoForChange()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindAutoForChange(Car car)
        {
           List<Car> allFindCar = content.Car.Where
                (
                 c =>
                 c.name == car.name ||
                 c.price == car.price ||
                 c.isFavourite == car.isFavourite ||
                 c.available == car.available ||
                 c.category == car.category
                ).ToList();

            return View(allFindCar);  //використати ViewModels
        }


        [HttpGet]
        public IActionResult ChangeInfoAuto()
        {
            return View(new Car());
        }
    }
}
