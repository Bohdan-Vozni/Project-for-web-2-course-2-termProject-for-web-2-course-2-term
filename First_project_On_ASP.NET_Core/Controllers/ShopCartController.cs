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
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController (IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;  // тут автоматично викликається GetCart()
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login","Account");
            }

            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items.Where(c => c.car.available == true).ToList();

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart,
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart (int id )
        {

            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                var userDeserialization = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("User"));
                _shopCart.AddToCart(item,userDeserialization.id);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult deleteTOCart(int id) 
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.DeleteToCard(item);
            }
            return RedirectToAction("Index");
        }
    }
}
