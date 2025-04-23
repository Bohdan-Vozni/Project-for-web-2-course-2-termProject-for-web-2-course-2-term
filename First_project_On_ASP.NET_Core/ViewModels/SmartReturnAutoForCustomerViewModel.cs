using Shop.Data.interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class SmartReturnAutoForCustomerViewModel
    {
        public List<OrderDetail> userActiveOrders { get; set; } 
        public List<OrderDetailReturn> userNotActiveOrders { get; set; } 

        public IEnumerable<Place> allPlace { get; set; }

        public int idPlace { get; set; }
    }
}
