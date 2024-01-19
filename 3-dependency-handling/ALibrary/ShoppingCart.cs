namespace ALibrary;

public class ShoppingCart(IPriceRepository _priceRepository)
{
    private readonly IDictionary<string, int> _productsQuantity =
        new Dictionary<string, int>();

    public void Add(string productId)
    {
        if (_productsQuantity.TryGetValue(productId, out var quantity))
        {
            _productsQuantity[productId] = ++quantity;
            return;
        }
        _productsQuantity.Add(productId, 1);
    }

    public decimal GetTotal()
    {
        return _productsQuantity.Sum(x =>
            _priceRepository.GetPriceByProductId(x.Key) * x.Value);
    }
}

public interface IPriceRepository
{
    public decimal GetPriceByProductId(string productId);
}