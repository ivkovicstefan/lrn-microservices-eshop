namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession documentSession)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create domain entity from command object
            Product product = new()
            {
                Name = command.Name,
                Categories = command.Categories,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // Save domain entity to database
            documentSession.Store(product);
            await documentSession.SaveChangesAsync(cancellationToken);
            // Return the result
            return new CreateProductResult(product.Id);
        }
    }
}
