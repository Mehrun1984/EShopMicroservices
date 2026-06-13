namespace Catalog.API.Exceptions
{
    public class ProductNotFoundExcception : Exception
    {
        public ProductNotFoundExcception() : base("Product not found.") { }
    }
}
