using System;
using System.Collections.Generic;
using ProductApp.Core;


namespace ProductApp.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _context = new ProductContext();

        public void Add(Category c)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category c)
        {
            throw new NotImplementedException();
        }

        public Category FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Category;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
