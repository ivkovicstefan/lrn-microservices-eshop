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

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            documentSession.Store(basket);
            await documentSession.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}
