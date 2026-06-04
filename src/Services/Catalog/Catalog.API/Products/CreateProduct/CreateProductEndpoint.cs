namespace Catalog.API.Products.CreateProduct
{
	public record CreateProductRequest(
		string Name,
		List<string> Category,
		string Description,
		string ImageFile,
		decimal Price
		);

	public record CreateProductResponse(Guid Id);

	public class CreateProductEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
			{
				// map request (CreateProductRequest) to CreateProductCommand , Adapt is generic
				var command = request.Adapt<CreateProductCommand>();

				// use mediatR to send comand to CreateProductCommand
				var result = await sender.Send(command);

				// map result of command handler to CreateProductResponse
				var response = result.Adapt<CreateProductResponse>();

				return Results.Created($"/products{result.Id}", result);
			})
				.WithName("CreateProduct")
				.Produces<CreateProductResponse>(StatusCodes.Status201Created)
				.ProducesProblem(StatusCodes.Status400BadRequest)
				.WithSummary("Create Poduct")
				.WithDescription("Create Poduct");
		}
	}
}
