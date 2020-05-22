using System.Threading.Tasks;
using ApiGraph.Data.Repositories;
using ApiGraph.GraphQL.Types;
using GraphQL.Types;

namespace ApiGraph.GraphQL.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        private readonly IProductRepository _productRepository;
        public ProductQuery(ProductRepository productRepository)
        {
            _productRepository = productRepository;

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context =>  _productRepository.GetAllProducts()
            );
        }
    }
}