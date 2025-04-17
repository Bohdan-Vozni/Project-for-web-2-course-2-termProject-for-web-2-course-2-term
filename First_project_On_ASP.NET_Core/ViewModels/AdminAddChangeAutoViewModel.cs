using Microsoft.AspNetCore.Http;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class AdminAddChangeAutoViewModel
    {
         
        public ICarsCategory allCategory { get; set; }

        public IFormFile ImageUpload { get; set; }

        public Car Car { get; set; } = new Car();

        public List<Car> FountCars { get; set; }

        public IAllPlace allPlaces { get; set; }

        public int idPlaces { get; set; }
    }
}
