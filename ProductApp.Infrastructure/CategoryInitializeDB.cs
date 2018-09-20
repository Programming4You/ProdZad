using System;
using System.Data.Entity;
using ProductApp.Core;

namespace ProductApp.Infrastructure
{
    public class CategoryInitializeDB : DropCreateDatabaseAlways<ProductContext> 
    {
        protected override void Seed(ProductContext context) 
        {
            context.Category.Add(new Category
            {
                Id = 1,
                Name = "Food"
            });

            context.Category.Add(new Category
            {
                Id = 2,
                Name = "Beverages"
            });

            context.Category.Add(new Category
            {
                Id = 3,
                Name = "Other"
            });

            context.Product.Add(new Product
            {
                Id = 1,
                Name = "Banana",
                Price = 70,
                CategoryId = 1,
                IsActive = true,
                Created = DateTime.Now
            });

            context.Product.Add(new Product
            {
                Id = 2,
                Name = "Olive oil",
                Price = 97,
                CategoryId = 3,
                IsActive = false,
                Modified = DateTime.Now
            });

            context.Product.Add(new Product
            {
                Id = 3,
                Name = "Orange juice",
                Price = 45,
                CategoryId = 2,
                IsActive = true,
                Created = DateTime.Now
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
