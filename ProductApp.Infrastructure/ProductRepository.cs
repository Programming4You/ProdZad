using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProductApp.Core;


namespace ProductApp.Infrastructure
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _context = new ProductContext();

        public void Add(Product p)
        {
            _context.Product.Add(p);
            _context.SaveChanges();
        }

        public void Edit(Product p)
        {
            _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            var result = (from p in _context.Product.Include(c => c.Category) where p.Id == id select p).FirstOrDefault();
            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Product.Include(c => c.Category);
        }

        public void Remove(int id)
        {
            Product p = _context.Product.Find(id);
            _context.Product.Remove(p);
            _context.SaveChanges();
        }
    }
}
