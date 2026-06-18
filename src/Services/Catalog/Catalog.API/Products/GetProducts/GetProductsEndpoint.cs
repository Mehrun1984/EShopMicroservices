using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetPRoducts
{
    public record GetProductRequest();
    public record GetProductsResponse(Product products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) => {
                // use mediatR to send query to GetProductsquery
                var result = await sender.Send(new GetProductQuery());
                
                // map result of query handler to GetProductsResponse
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
                .WithName("GetProduct")
                .Produces<GetProductsResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Poduct")
                .WithDescription("Get Poduct");
        }
    }
}
