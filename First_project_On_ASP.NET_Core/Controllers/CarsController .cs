using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using Shop.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;

        private readonly ICarsCategory _allCategories;

        public CarsController (IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List (string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if(string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.Where(i => i.available == true).OrderBy(i => i.id);  //  && i.available == true додав щоб відображалися тільки наявні авто
            }
            else
            {
                if(string.Equals("electro",category,System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.category.categoryName.Equals("Електромобіль") && i.available == true).OrderBy(i => i.id);
                    currCategory = "Електомобілі";
                }
                else if (string.Equals("fuel", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.category.categoryName.Equals("класичний автомобіль") && i.available == true).OrderBy(i => i.id);
                    currCategory = "Класичні автомобілі";
                }

                //  && i.available == true додав щоб відображалися тільки наявні авто
            }

            var carObj = new CarsListViewModels
            {
                allCars = cars,
                currCategory = currCategory,
            };



            ViewBag.Title = "Сторінка з автомобілями";

 

            return View(carObj);
        }

    }
}
