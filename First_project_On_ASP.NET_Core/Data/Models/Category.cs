using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string categoryName { get; set; }

        public string desc { get; set; }

        public List<Car> cars { get; set; }
    }
}
