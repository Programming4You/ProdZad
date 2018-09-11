using System.Data.Entity;
using ProductApp.Core;


namespace ProductApp.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=ProductConnectionString")
        {
            Database.SetInitializer(new CategoryInitializeDB());
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
