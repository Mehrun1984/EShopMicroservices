namespace Catalog.API.Products.CreateProduct
{
	public record CreateProductCommand(
		string Name,
		List<string> Category,
		string Description,
		string ImageFile,
		decimal Price) : ICommand<CreateProductResult>;

		public record CreateProductResult(Guid Id);
	public class CreateProductCommandHandler(IDocumentSession session)
		: ICommandHandler<CreateProductCommand, CreateProductResult>
	{
		public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
		{
			// Create Porduct entity
			var product = new Product
			{
				Name = command.Name,
				Category = command.Category,
				Description = command.Description,
				price = command.Price
			};

			//Save to DataBase
			session.Store(product);
			await session.SaveChangesAsync(cancellationToken);

			// Return CreateProductResult
			return new CreateProductResult(product.Id);
		}
	}
}
