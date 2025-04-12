using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

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
            var getUserInfo = HttpContext.Session.GetString("User");
            var jsonDeserializeUser = JsonSerializer.Deserialize<User>(getUserInfo);            

            return View(jsonDeserializeUser);
        }

    }
}
