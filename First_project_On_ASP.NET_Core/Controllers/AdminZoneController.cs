using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Shop.Controllers
{
    public class AdminZoneController : Controller
    {
        private readonly ICarsCategory _allCategories;
        private readonly IAllCars _allCars;
        private AppDBContent content;

        public AdminZoneController (AppDBContent content)
        {
            this.content = content;
        }
        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuto()
        {
            //ViewBag.Categories = _allCategories.AllCegories;
            return View();
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
