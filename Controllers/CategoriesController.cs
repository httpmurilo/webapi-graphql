using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGraph.Data.Repositories;
using ApiGraph.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGraph.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            _categoryRepository.SaveCategory(category);
            await _categoryRepository.UnitOfWork.Commit();

            return Ok(category);
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> ListCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            
            return categories;
        }
    }
}