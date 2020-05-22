using ApiGraph.Entities;
using GraphQL.Types;

namespace ApiGraph.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product> 
    {
        public ProductType()
        {
            Field(p => p.Name);
            Field(p => p.Price);
        }
    }
}