using BuildingBlocks;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product product);
    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            // as public record GetProductByIdResult(Product product); contain just a record of product, it is not required to use ToList()
            if (product is null)
            {
                throw new ProductNotFoundExcception();
            }
            return new GetProductByIdResult(product);
        }
    }
}
