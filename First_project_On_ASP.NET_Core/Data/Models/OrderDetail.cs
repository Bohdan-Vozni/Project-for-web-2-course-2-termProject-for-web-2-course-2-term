using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        public int orderID { get; set; }
        public int CarID { get; set; }

        public int userId { get; set; }

        public virtual User user { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
       
        public virtual OrderDetailReturn OrderDetailReturn { get; set; }
    }
}
