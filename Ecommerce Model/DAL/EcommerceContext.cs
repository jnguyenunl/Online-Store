using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("EcommerceContext")
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleCategory> SaleCategories { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}