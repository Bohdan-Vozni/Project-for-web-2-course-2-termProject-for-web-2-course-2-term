using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string placeName { get; set; }

        public string address { get; set; }

        public string desc { get; set; }

        List<Car> Cars { get; set; }



        List<OrderDetailReturn> orderDetailReturns { get; set; }
    }
}
