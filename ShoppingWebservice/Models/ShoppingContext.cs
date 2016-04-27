using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingWebservice.Data;

namespace ShoppingWebservice.Models {
    public class ShoppingContext : DbContext {

        public static string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShoppingWebservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ShoppingContext() : base(CONN) {
            Database.SetInitializer<ShoppingContext>(new ShoppingDbInitializer());
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}