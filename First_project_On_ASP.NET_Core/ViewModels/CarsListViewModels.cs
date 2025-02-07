using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> allCars {  get; set; } 

        public string currCategory { get; set; }
    }
}
