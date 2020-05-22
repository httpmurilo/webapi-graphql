using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGraph.Data.Repositories;
using ApiGraph.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiGraph.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]    
        public async Task<ActionResult> CreateProduct(Product product)
        {
             _productRepository.SaveProduct(product);

            await _productRepository.UnitOfWork.Commit();

            return  Ok(product);

        }

        [HttpGet]
        public async Task<IEnumerable<Product>> ListProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products;
        }
    }
}