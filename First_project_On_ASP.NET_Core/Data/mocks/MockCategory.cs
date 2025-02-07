using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCegories
        {
            get
            {
                //yeild return
                return new List<Category>()
                {
                    new Category {categoryName = "Електро мобіль" , desc = " сідан електоромобіль"},
                    new Category {categoryName = "класичний автомобіль" , desc = "з двигуном внутрішнього згорання"}
                };
            }
        }
    }
}
