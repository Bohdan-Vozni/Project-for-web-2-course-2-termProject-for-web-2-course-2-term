using Shop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class UserViewModel : User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(10, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(100, ErrorMessage = "Surname can't be longer than 100 characters.")]
        public string surname { get; set; }

        [StringLength(100, ErrorMessage = "Middle name can't be longer than 100 characters.")]
        [Required(ErrorMessage = "Middlname is required.")]
        public string middlName { get; set; }

        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
        public int age { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [Required(ErrorMessage = "Phone is required.")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Login is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Login must be between 5 and 50 characters.")]
        public string login { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string password { get; set; }

        public bool isAdmin { get; set; }
    }
}
