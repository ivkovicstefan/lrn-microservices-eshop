namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    internal class GetBasketQueryHandler
        (IBasketRepository basketRepository)
        : IRequestHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetBasket(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
