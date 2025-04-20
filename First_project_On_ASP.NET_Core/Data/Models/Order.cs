using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введіть імя")]
        [StringLength(5)]
        [Required(ErrorMessage = "Довжина імя не менше 20 символів")]
        public string name { get; set; }
        public string surname { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
