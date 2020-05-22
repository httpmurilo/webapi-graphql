using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGraph.DomainObjects;
using ApiGraph.Entities;

namespace ApiGraph.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void SaveCategory(Category category);
        void DeleteCategory(Category category);

        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategory(Guid id);
        Task<IEnumerable<Product>> GetAllProductsByCategory(Category category);
    }
}