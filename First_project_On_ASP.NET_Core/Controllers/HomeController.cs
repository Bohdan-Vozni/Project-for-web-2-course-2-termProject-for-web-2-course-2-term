using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System.Linq;
using System.Text.Json;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public readonly IAllPlace _allPlaces;
 

        public HomeController(IAllCars carRep, IAllPlace allPlaces)
        {
            _carRep = carRep;
            _allPlaces = allPlaces;
        }

        [HttpGet]
        public ViewResult Index()
        {

            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars.Where(i => i.available == true),  //  && i.available == true додав щоб відображалися тільки наявні авто

                allPlaces = _allPlaces.getAllPlace
            };


            return View(homeCars);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {

            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars.Where(i => i.available == true && i.placeID == model.idPlaces ),  //  && i.available == true додав щоб відображалися тільки наявні авто

                allPlaces = _allPlaces.getAllPlace
            };


            return View(homeCars);
        }
    }
}
