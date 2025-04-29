using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;

namespace Shop.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDBContent content;
        public ReviewController(AppDBContent content)
        {
            this.content = content;
        }

        [HttpGet]
        public IActionResult ReviewForSite()
        {
            List<Reviews> listReviews = content.Reviews.Where(c => c.name == c.name).OrderByDescending(c => c.timeSend).ToList();

            var model = new ReviewForSiteViewModel()
            {
                listReviews = listReviews
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult ReviewForSite(ReviewForSiteViewModel model) 
        {
            var user = HttpContext.Session.GetString("User");

            if (user == null)
            {
                ModelState.AddModelError("Review.name", "Ви не авторизовані потрібно авторизуватися");

                return View();
            }

            var userDeSerialise = JsonSerializer.Deserialize<User>(user);

            var ReviewsForAdd = new Reviews()
            {
                userId = userDeSerialise.id,
                name = model.Review.name,
                response = model.Review.response,
                timeSend = DateTime.Now,    
            };

            content.Reviews.Add(ReviewsForAdd);
            content.SaveChanges();

            List<Reviews> listReviews = content.Reviews
                .OrderByDescending(c => c.timeSend) 
                .ToList();

            var modelForRetutn = new ReviewForSiteViewModel()
            {
                listReviews = listReviews
            };

            return View(modelForRetutn);
        }

        [HttpGet]
        public IActionResult ChangeReview()
        {
            var user = HttpContext.Session.GetString("User");
   
            var userDeSerialise = JsonSerializer.Deserialize<User>(user);



            List<Reviews> listReviews = content.Reviews
                .OrderByDescending(c => c.timeSend)
                .Where(c => c.userId == userDeSerialise.id)
                .ToList();

            var modelForRetutn = new ReviewForSiteViewModel()
            {
                listReviews = listReviews
            };

            return View(modelForRetutn);
        }

        [HttpPost]
        public IActionResult ChangeReview(ReviewForSiteViewModel model, int idReview)
        {
            var user = HttpContext.Session.GetString("User");
   
            var userDeSerialise = JsonSerializer.Deserialize<User>(user);

            var reviewsForUpdate = content.Reviews.FirstOrDefault(c => c.Id == idReview && c.userId == userDeSerialise.id);

            reviewsForUpdate.response = model.Review.response;

            content.Reviews.Update(reviewsForUpdate);
            content.SaveChanges();


            List<Reviews> listReviews = content.Reviews
                .OrderByDescending(c => c.timeSend)
                .Where(c => c.userId == userDeSerialise.id)
                .ToList();

            var modelForRetutn = new ReviewForSiteViewModel()
            {
                listReviews = listReviews,
                

            };

            return RedirectToAction("ChangeReview");
        }
    }
}
