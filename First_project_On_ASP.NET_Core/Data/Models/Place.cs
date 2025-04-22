using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string placeName { get; set; }

        public string address { get; set; }

        public string desc { get; set; }

        public List<Car> Cars { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

        public List<OrderDetailReturn> orderDetailReturns { get; set; }
    }
}
