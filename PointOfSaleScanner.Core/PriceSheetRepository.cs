namespace PointOfSaleScanner.Core;

public class PriceSheetRepository : IPriceSheetRepository
{
    private IList<CartItem> _priceSheet = [];

    public void Add(CartItem cartItem)
    {
        _priceSheet.Add(cartItem);
    }

    public CartItem Find(string code)
    {
        return _priceSheet.First(item => string.Equals(item.Code, code, StringComparison.OrdinalIgnoreCase));
    }
}
