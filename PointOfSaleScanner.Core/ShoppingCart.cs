
namespace PointOfSaleScanner.Core;

public class ShoppingCart : IShoppingCart
{
    private readonly ICartItemPriceCalculator _cartItemPriceCalculator;

    private readonly Dictionary<string, int> _scannedItems = [];

    public ShoppingCart(ICartItemPriceCalculator cartItemPriceCalculator)
    {
        _cartItemPriceCalculator = cartItemPriceCalculator;
    }

    public void Scan(string code)
    {
        if (_scannedItems.ContainsKey(code))
        {
            _scannedItems[code]++;
        }
        else
        {
            _scannedItems[code] = 1;
        }
    }

    public decimal GetTotal() => _scannedItems.Sum(item => _cartItemPriceCalculator.GetTotal(item.Key, item.Value));

    public void Reset()
    {
        _scannedItems.Clear();
    }
}
