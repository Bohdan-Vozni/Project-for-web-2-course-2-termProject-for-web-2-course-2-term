using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Identity.Client;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace Shop.Controllers
{
    public class AdminZoneController : Controller
    {
        private readonly ICarsCategory _allCategories;
        private readonly IAllCars _allCars;
        private AppDBContent content;
        private readonly IAllPlace _allPlace;

        public AdminZoneController (AppDBContent content, ICarsCategory allCategory, IAllCars allCars, IAllPlace allPlace)
        {
            this.content = content;
            _allCategories = allCategory;
            _allCars = allCars;
            _allPlace = allPlace;
        }
        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuto()
        {
            var AdminAddChangeAutoViewModel = new AdminAddChangeAutoViewModel 
            {
                allCategory =_allCategories,
                allPlaces = _allPlace,
            };
            return View(AdminAddChangeAutoViewModel);
        }

        [HttpPost]
        public IActionResult AddAuto(AdminAddChangeAutoViewModel obj)
        {
            string imagepath = "/img/default.png";

            if (obj.ImageUpload != null && obj.ImageUpload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.ImageUpload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    obj.ImageUpload.CopyTo(stream);
                }

                imagepath = "/img/" + fileName; // для збереження в бд
            }

            Car car = new Car
            {
                name = obj.Car.name,
                shortDesc = obj.Car.shortDesc,
                longDesc = obj.Car.longDesc,
                img = imagepath,
                price = obj.Car.price,
                isFavourite = (bool)obj.Car.isFavourite,
                available = (bool)obj.Car.available,
                categoryID = obj.Car.categoryID,
                placeID = obj.idPlaces,
            };

            content.Car.Add(car);
            content.SaveChanges();

            return RedirectToAction("AdminHome");
        }

        [HttpGet]
        public IActionResult FindAutoForChange()
        {
            var AdminAddChangeAutoViewModel = new AdminAddChangeAutoViewModel { allCategory = _allCategories };
            return View(AdminAddChangeAutoViewModel);
        }

        [HttpPost]
        public IActionResult FindAutoForChange(AdminAddChangeAutoViewModel model)
        {
            if (model.Car == null)
            {
                model.Car = new Car();
            }

            var query = content.Car.AsQueryable();

            if (!string.IsNullOrEmpty( model.Car.name))
            {
                query = query.Where(c => c.name == model.Car.name);
            }

            if (model.Car.price != 0)
            {
                query = query.Where(c => c.price == model.Car.price);
            }

            query = query.Where(c => c.available == model.Car.available);

            query = query.Where(c => c.isFavourite == model.Car.isFavourite);

            if (model.Car.categoryID != 0)
            {
                query = query.Where(c => c.categoryID == model.Car.categoryID);
            }

            var allFindCar = query.ToList();

            if(allFindCar.Count == 0)
            {
                ModelState.AddModelError("Car.name", "Неіснує такого авто спробуйте ввести нові значення");
            }


            var modelReturn = new AdminAddChangeAutoViewModel
            { 
               allCategory = _allCategories,
               FountCars = allFindCar,

            };


            return View(modelReturn);  //використати ViewModels
        }


        [HttpGet]
        public IActionResult ChangeInfoAuto(int id)
        {
            var car = content.Car.FirstOrDefault(c => c.id == id);

            var model = new AdminAddChangeAutoViewModel
            {
                allCategory = _allCategories,
                Car = car,

            };
            
            if(car == null)
            {
                return RedirectToAction("FindAutoForChange");
            }


            return View(model);
        }


        [HttpPost]
        public IActionResult ChangeInfoAuto(AdminAddChangeAutoViewModel obj, int id)
        {
            var carForUpdate = content.Car.FirstOrDefault(c => c.id == id);

            if (carForUpdate == null)
            {
                return NotFound();
            }

            string imagepath = carForUpdate.img; 

            if (obj.ImageUpload != null && obj.ImageUpload.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.ImageUpload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    obj.ImageUpload.CopyTo(stream);
                }

                imagepath = "/img/" + fileName; // для збереження в бд
            }

            // Оновлюємо властивості автомобіля
            carForUpdate.name = obj.Car.name;
            carForUpdate.shortDesc = obj.Car.shortDesc;
            carForUpdate.longDesc = obj.Car.longDesc;
            carForUpdate.img = imagepath;
            carForUpdate.price = obj.Car.price;
            carForUpdate.isFavourite = (bool)obj.Car.isFavourite;
            carForUpdate.available = (bool)obj.Car.available;           

            if (obj.Car.categoryID == 0) 
            {
                carForUpdate.categoryID = carForUpdate.categoryID;
            }
            else 
            {
                carForUpdate.categoryID = obj.Car.categoryID;
            }


            content.Car.Update(carForUpdate);
            content.SaveChanges();

            return RedirectToAction("AdminHome");
        }


        [HttpGet]
        public IActionResult FindAutoForDelete()
        {
            var AdminAddChangeAutoViewModel = new AdminAddChangeAutoViewModel { allCategory = _allCategories };
            return View(AdminAddChangeAutoViewModel);
        }

        [HttpPost]
        public IActionResult FindAutoForDelete(AdminAddChangeAutoViewModel model)
        {
            if (model.Car == null)
            {
                model.Car = new Car();
            }

            var query = content.Car.AsQueryable();

            if (!string.IsNullOrEmpty(model.Car.name))
            {
                query = query.Where(c => c.name == model.Car.name);
            }

            if (model.Car.price != 0)
            {
                query = query.Where(c => c.price == model.Car.price);
            }

            query = query.Where(c => c.available == model.Car.available);

            query = query.Where(c => c.isFavourite == model.Car.isFavourite);

            if (model.Car.categoryID != 0)
            {
                query = query.Where(c => c.categoryID == model.Car.categoryID);
            }

            var allFindCar = query.ToList();

            if (allFindCar.Count == 0)
            {
                ModelState.AddModelError("Car.name", "Неіснує такого авто спробуйте ввести нові значення");
            }


            var modelReturn = new AdminAddChangeAutoViewModel
            {
                allCategory = _allCategories,
                FountCars = allFindCar,

            };


            return View(modelReturn);
        }

        [HttpPost]
        public IActionResult DeleteAuto(AdminAddChangeAutoViewModel model, int id)
        {
            if (model.Car == null)
            {
                model.Car = new Car();
            }
            
            var carForRemove = content.Car.FirstOrDefault(c => c.id == id);

            var webRootPath = Directory.GetCurrentDirectory();
            var pathForDelete = Path.Combine(webRootPath, "wwwroot", carForRemove.img.TrimStart('/'));
           


            if (carForRemove == null)
            {
                ModelState.AddModelError("", "неможливо видалити"); // нігде не обробляється
            }
            else 
            {
                content.Car.Remove(carForRemove);
                content.SaveChanges();

                if (System.IO.File.Exists(pathForDelete) && !carForRemove.img.Contains("default.png"))
                {
                    System.IO.File.Delete(pathForDelete);
                }
            }

            model.allCategory = _allCategories;

            
            return View("FindAutoForDelete", model);
        }
    }
}
