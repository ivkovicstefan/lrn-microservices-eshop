namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession documentSession)
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await documentSession.LoadAsync<ShoppingCart>(userName, cancellationToken);

            if (basket is null)
            {
                throw new BasketNotFoundException(userName);
            }

            return basket;
        }
    }
}
