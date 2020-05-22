using ApiGraph.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace ApiGraph.GraphQL.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductQuery>();
        }
    }
}