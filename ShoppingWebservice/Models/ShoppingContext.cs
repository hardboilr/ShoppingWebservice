using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingWebservice.Models {
    public class ShoppingContext : DbContext {

        public static string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShoppingWebservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ShoppingContext() : base(CONN) {
            Database.SetInitializer<ShoppingContext>(new DropCreateDatabaseAlways<ShoppingContext>());

            Database.ExecuteSqlCommand()
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}