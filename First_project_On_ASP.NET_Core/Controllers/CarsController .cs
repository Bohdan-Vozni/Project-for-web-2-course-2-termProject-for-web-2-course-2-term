using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;
using Shop.ViewModels;

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

        public ViewResult List ()
        {
            ViewBag.Title = "Сторінка з автомобілями";

            CarsListViewModels obj = new CarsListViewModels ();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Автомобілі";

            return View(obj);
        }

    }
}
