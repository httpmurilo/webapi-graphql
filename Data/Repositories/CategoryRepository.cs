using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGraph.DomainObjects;
using ApiGraph.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGraph.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void SaveCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategory(Category category)
        {
            return await _context.Products.AsNoTracking().Where(p => p.CategoryId == category.Id).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}