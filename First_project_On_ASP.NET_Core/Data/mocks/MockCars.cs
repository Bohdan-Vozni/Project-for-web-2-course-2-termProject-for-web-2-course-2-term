﻿using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _CategoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                yield return new Car 
                {
                    name = "Tesla",
                    shortDesc = "", 
                    img = "/img/teslavodel3.jpg",
                    price = 4500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.First() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.Last() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.Last() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.Last() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.Last() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "/img/audirs7.jpg",
                    price = 2500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.Last() 
                };
            }
           
        }

        public IEnumerable<Car> getFavCars { get ; set ; }

        public Car GetObjeckCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
