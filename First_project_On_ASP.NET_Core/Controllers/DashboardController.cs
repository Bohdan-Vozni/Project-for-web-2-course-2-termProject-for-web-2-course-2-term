using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using System.Diagnostics;
using System.Linq;

namespace Shop.Controllers
{
    public class DashboardController  : Controller
    {
        private readonly AppDBContent content;

        public DashboardController(AppDBContent content) 
        {
            this.content = content;
        }

        public IActionResult Personal_Account()
        {
            var user = content.User.FirstOrDefault(u => u.login == "sa");

            return View(user);
        }
    }
}
