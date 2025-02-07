using Shop.Data.interfaces;
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
                    img = "https://www.google.com/imgres?q=tesla&imgurl=https%3A%2F%2Felectro-motors.top%2Fimage%2Fcache%2Fcatalog%2Felectrocars%2FTeslaY%2Fteslay2-1200x800.png&imgrefurl=https%3A%2F%2Felectro-motors.top%2Fua%2Favtosalon%2Felektrokary-iz-kitaya%2Ftesla-model-y-performance.html&docid=WHqfEKfw5-KGeM&tbnid=8pP55uifLETOrM&vet=12ahUKEwiOrrmTla2LAxVcJhAIHYHZABMQM3oECBgQAA..i&w=1200&h=800&hcb=2&ved=2ahUKEwiOrrmTla2LAxVcJhAIHYHZABMQM3oECBgQAA",
                    price = 4500,
                    isFavourite = true,
                    category = _CategoryCars.AllCegories.First() 
                };

                yield return new Car 
                {
                    name = "Audi",
                    shortDesc = "",
                    img = "https://www.google.com/imgres?q=audi&imgurl=https%3A%2F%2Favesauto.ua%2Fuploads%2Fcar%2Fimage%2F890%2Ffile67162b8c7c7f4.png&imgrefurl=https%3A%2F%2Favesauto.ua%2Fua%2Ftinting%2Faudi%2Fq8-e-tron%2F2023&docid=3sNn2VdO3wcwUM&tbnid=TSzhqffAJs58iM&vet=12ahUKEwjx5_uala2LAxVUBhAIHfIMEVwQM3oECGUQAA..i&w=1400&h=601&hcb=2&ved=2ahUKEwjx5_uala2LAxVUBhAIHfIMEVwQM3oECGUQAA",
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
