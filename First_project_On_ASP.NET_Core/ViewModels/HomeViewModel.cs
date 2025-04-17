using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections;
using System.Collections.Generic;


namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }

        public IEnumerable<Place> allPlaces { get; set; }

        public int idPlaces { get; set; }

    }
}
