using Shopping_cart_dotnetmvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shopping_cart_dotnetmvc.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext():base("OktaConnectionString")
        {

        }
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<User_info> user_Infos { get; set; }
    }
}