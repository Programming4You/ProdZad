using System.Data.Entity;
using ProductApp.Core;

namespace ProductApp.Infrastructure
{
    public class CategoryInitializeDB : DropCreateDatabaseIfModelChanges<ProductContext>    //ovde moze DropCreateDatabaseAlways, ali ce obrisati i sve proizvode u bazi i indekse
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

            //context.Product.Add(new Product
            //{
            //    Id = 1,
            //    Name = "Orange",
            //    Price = 50,
            //    CategoryId = 1,
            //    IsActive = true,
            //    Created = DateTime.Now
            //});

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
