using StoreModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataAccess
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext()
            : base("Server=(local);Database=StoreDB;Trusted_Connection=True;")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
