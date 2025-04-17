using Azure.Core.Pipeline;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> allCars {  get; set; } 

        public IEnumerable<Place> allPlaces { get; set; }

        public string currCategory { get; set; }

        public int idPlaces { get; set; }
    }
}
