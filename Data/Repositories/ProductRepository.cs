using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGraph.DomainObjects;
using ApiGraph.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGraph.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;
        
        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
        }
        
        public void DeleteProduct(Product product)
        {
           _context.Products.Remove(product);
        }

       
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.AsNoTracking().Include(p=> p.Category).ToListAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        
         public void Dispose()
        {
            _context?.Dispose();
        }
    }
}