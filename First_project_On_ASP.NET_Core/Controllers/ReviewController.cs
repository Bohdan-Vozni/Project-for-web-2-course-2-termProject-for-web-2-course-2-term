using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult ReviewForSite()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReviewForSite(int s) // добавив int s щоб не було полки
        {
            return View();
        }
    }
}
