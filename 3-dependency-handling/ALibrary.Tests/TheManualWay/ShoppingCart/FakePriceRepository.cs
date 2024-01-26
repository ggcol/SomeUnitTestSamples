namespace ALibrary.Tests.TheManualWay.ShoppingCart;

public class FakePriceRepository(
    // ReSharper disable once ParameterTypeCanBeEnumerable.Local
    IReadOnlyList<FakePriceRepository.FakePriceRepositorySetup> _setups)
    : IPriceRepository
{
    public decimal GetPriceByProductId(string productId)
    {
        return _setups
            .FirstOrDefault(x =>
                x.ProductId.Equals(productId,
                    StringComparison.OrdinalIgnoreCase))!
            .Price;
    }

    public record FakePriceRepositorySetup(string ProductId, decimal Price);
}