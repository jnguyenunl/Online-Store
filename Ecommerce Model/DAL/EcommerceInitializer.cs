using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Models;

namespace Ecommerce.DAL
{
    public class EcommerceInitializer : System.Data.Entity.DropCreateDatabaseAlways<EcommerceContext>
    {
        protected override void Seed(EcommerceContext context)
        {
            var addresses = new List<Address>
            {
                 new Address{Street="9269 Ketch Harbour Drive",City="Ottumwa",State="IA",PostalCode="52501",Country="US"},
                 new Address{Street="81 Broad Road",City="Newnan",State="GA",PostalCode="30263",Country="US"},
                 new Address{Street="605 Holly St.",City="Niceville",State="FL",PostalCode="32578",Country="US"},
                 new Address{Street="861 Woodland Street",City="Grand Rapids",State="MI",PostalCode="49503",Country="US"},
                 new Address{Street="48 Apple Boulevard",City="Tulsa",State="OK",PostalCode="74008",Country="US"},
                 new Address{Street="1111 T Street",City="Omaha",State="NE",PostalCode="68127",Country="US"},
                 new Address{Street="Street",City="City",State="State",PostalCode="0000",Country="Country"}
            };
            addresses.ForEach(s => context.Addresses.Add(s));
            context.SaveChanges();

            var manufacturers = new List<Manufacturer>
            {
                 new Manufacturer{Name="Nike",Email="nike@nike.com", AddressID=1},
                 new Manufacturer{Name="Adidas",Email="adidas@adidas.com", AddressID=3},
                 new Manufacturer{Name="Under Armour",Email="ua@ua.com", AddressID=4}
            };
            manufacturers.ForEach(s => context.Manufacturers.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                 new User{Username="stevewilldoit",Password="Full_Send_2021!",ConfirmPassword="Full_Send_2021!",Email="steve@nelk.com",AddressID=2},
                 new User{Username="joelikesclothes",Password="Joe_$hmoe11",ConfirmPassword="Joe_$hmoe11",Email="joelikesclothes@gmail.com",AddressID=5},
                 new User{Username="robert48",Password="R0bert4&8",ConfirmPassword="R0bert4&8",Email="robert48@hotmail.com",AddressID=6},
                 new User{Username="admin",Password="Password1!",ConfirmPassword="Password1!",Email="admin@gmail.com",AddressID=7}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                 new Product{Name="Mens White Nike Crew Socks",Description="A pair of white socks",Price=20,Rating="5/5",Size="1x1",Weight=1,SKU="000SKU123",ManufactureID=1},
                 new Product{Name="Womens White Nike Crew Socks",Description="A pair of white socks",Price=15,Rating="4/5",Size="1x1",Weight=1,SKU="000SKU124",ManufactureID=1},
                 new Product{Name="Mens Blue Adidas Shorts",Description="A pair of blue running shorts",Price=40,Rating="4/5",Size="5x5",Weight=5,SKU="000SKU145",ManufactureID=2},
                 new Product{Name="Womens Purple Adidas Shorts",Description="A pair of purple running shorts",Price=35,Rating="5/5",Size="5x5",Weight=5,SKU="000SKU146",ManufactureID=2},
                 new Product{Name="Mens Under Armour Hoodie",Description="A hoodie for outdoor running",Price=60,Rating="4/5",Size="8x8",Weight=10,SKU="000SKU163",ManufactureID=3},
                 new Product{Name="Womens Under Armour Hoodie",Description="A hoodie for outdoor running",Price=60,Rating="4/5",Size="8x8",Weight=10,SKU="000SKU164",ManufactureID=3},
                 new Product{Name="Mens Nike Beanie",Description="A beanie for the cold",Price=8,Rating="4/5",Size="2x2",Weight=1,SKU="000SKU183",ManufactureID=1},
                 new Product{Name="Womens Nike Beanie",Description="A beanie for the cold",Price=8,Rating="5/5",Size="2x2",Weight=1,SKU="000SKU184",ManufactureID=1},
                 new Product{Name="Mens Adidas Black Joggers",Description="Pants for outdoor running",Price=40,Rating="5/5",Size="5x8",Weight=7,SKU="000SKU202",ManufactureID=2},
                 new Product{Name="Womens Adidas Blue Pants",Description="Pants for outdoor running",Price=40,Rating="5/5",Size="5x8",Weight=7,SKU="000SKU203",ManufactureID=2},
                 new Product{Name="Mens Under Armour Wristband",Description="A wristband for sweat",Price=10,Rating="5/5",Size="1x2",Weight=1,SKU="000SKU222",ManufactureID=3},
                 new Product{Name="Womens Under Armour Headband",Description="A headband for sweat",Price=15,Rating="4/5",Size="2x3",Weight=2,SKU="000SKU223",ManufactureID=3}
            };
            products.ForEach(s => context.Product.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                 new Category{Name="Men"},
                 new Category{Name="Women"},
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var productCategories = new List<ProductCategory>
            {
                 new ProductCategory{ProductID=1,CategoryID=1},
                 new ProductCategory{ProductID=2,CategoryID=2},
                 new ProductCategory{ProductID=3,CategoryID=1},
                 new ProductCategory{ProductID=4,CategoryID=2},
                 new ProductCategory{ProductID=5,CategoryID=1},
                 new ProductCategory{ProductID=6,CategoryID=2},
                 new ProductCategory{ProductID=7,CategoryID=1},
                 new ProductCategory{ProductID=8,CategoryID=2},
                 new ProductCategory{ProductID=9,CategoryID=1},
                 new ProductCategory{ProductID=10,CategoryID=2},
                 new ProductCategory{ProductID=11,CategoryID=1},
                 new ProductCategory{ProductID=12,CategoryID=2}
            };
            productCategories.ForEach(s => context.ProductCategories.Add(s));
            context.SaveChanges();

            var carts = new List<Cart>
            {
                 new Cart{CartID=1,UserID=1},
                 new Cart{CartID=2,UserID=2},
                 new Cart{CartID=3,UserID=3},
            };
            carts.ForEach(s => context.Carts.Add(s));
            context.SaveChanges();

            var cartProducts = new List<CartProduct>
            {
                 new CartProduct{CartID=1,ProductID=1,Quantity=1},
                 new CartProduct{CartID=1,ProductID=8,Quantity=2}
            };
            cartProducts.ForEach(s => context.CartProducts.Add(s));
            context.SaveChanges();
        }
    }
}