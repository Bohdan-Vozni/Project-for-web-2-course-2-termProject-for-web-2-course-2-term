using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Shop.Data.Repository
{
    public class OrdersRepository 
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository (AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        
    }
}
