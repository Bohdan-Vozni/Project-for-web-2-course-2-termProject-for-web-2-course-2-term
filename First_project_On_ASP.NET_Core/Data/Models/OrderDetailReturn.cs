using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class OrderDetailReturn
    {
        public int Id { get; set; }
        
        public int orderDetailId { get; set; }

        public OrderDetail orderDetail { get; set; }

        public int placeReturnID {  get; set; }

        public Place placeReturn { get; set; }

        public DateTime dataTime_return { get; set; }

        public string personWhoReturn { get; set; }

        public int price { get; set; }

        public bool isReturning { get; set; }

        public string img {  get; set; }
    }
}
