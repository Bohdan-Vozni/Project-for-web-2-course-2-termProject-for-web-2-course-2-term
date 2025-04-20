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
        [StringLength(30)]
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50)]
        public string surname { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50)]
        public string adress { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Required(ErrorMessage = "Phone is required.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
