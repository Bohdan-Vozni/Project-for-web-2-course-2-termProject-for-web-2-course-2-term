using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Car> Car { get; set; }
        
        public DbSet<Category> Category { get; set; }

        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order{ get; set; }
        public DbSet<OrderDetail> OrderDetailUp { get; set; }

        public DbSet<User> User { get; set; }
        
    }
}
