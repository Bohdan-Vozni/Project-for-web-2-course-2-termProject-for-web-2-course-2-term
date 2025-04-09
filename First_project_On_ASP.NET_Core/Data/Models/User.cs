using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Data.Models
{
    public class User
    {
        public int id {  get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string middlName { get; set; }

        public int age { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public string login {  get; set; }

        public string password { get; set; }

        public bool isAdmin { get; set; }
    }
}
