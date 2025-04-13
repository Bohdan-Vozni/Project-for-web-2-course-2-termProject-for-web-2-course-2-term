using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class AdminZoneController : Controller
    {
        private readonly ICarsCategory _allCategories;

        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuto()
        {
            //ViewBag.Categories = _allCategories.AllCegories;
            return View(new Car());
        }
    }
}
