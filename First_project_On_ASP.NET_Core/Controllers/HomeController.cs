using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            { 
                favCars = _carRep.getFavCars.Where(i => i.available == true),  //  && i.available == true додав щоб відображалися тільки наявні авто
            };

            return View(homeCars);
        }
    }
}
