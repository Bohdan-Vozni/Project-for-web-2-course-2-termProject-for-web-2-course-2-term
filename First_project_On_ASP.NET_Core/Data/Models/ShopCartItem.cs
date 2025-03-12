using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        [Key]
        public int id {  get; set; }

        public int CarID { get; set; } // added

        public Car car { get; set; }

        public int price { get; set; }
        public string ShopCartId { get; set; }

    }
}
