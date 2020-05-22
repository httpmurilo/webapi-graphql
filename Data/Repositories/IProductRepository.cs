using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGraph.DomainObjects;
using ApiGraph.Entities;

namespace ApiGraph.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void SaveProduct(Product product);
        void DeleteProduct(Product product);

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(Guid id);
    }
}