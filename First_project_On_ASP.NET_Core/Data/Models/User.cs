using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class User
    {
        public int id { get; set; }

        
        public string name { get; set; }

        
        public string surname { get; set; }

       
        public string middlName { get; set; }

       
        public int age { get; set; }

        public string phoneNumber { get; set; }

       
        public string email { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Login must be between 5 and 50 characters.")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string password { get; set; }

        public bool isAdmin { get; set; }

        

        public List<ShopCartItem> ShopCartItems { get; set; }

        public List<Reviews> Reviews { get; set; }
    }
}
