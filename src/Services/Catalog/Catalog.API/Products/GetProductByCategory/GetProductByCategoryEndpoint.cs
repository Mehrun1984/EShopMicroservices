using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory
{
	public record GetPrdouctByCategoryResponse(IEnumerable<Product> Products);
	public class GetProductByCategoryEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/products/category/{category}", async (string Category, ISender sender) =>
			{
				var result = await sender.Send(new GetProductByCategoryQuery(Category));
				var response = result.Adapt<GetPrdouctByCategoryResponse>();
				return Results.Ok(response);
			})
				.WithName("GetProductByCategory")
				.Produces<GetPrdouctByCategoryResponse>(StatusCodes.Status201Created)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.WithSummary("Get Poduct By Category")
				.WithDescription("Get Poduct By Category");
		}
	}
}
