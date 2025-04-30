namespace PointOfSaleScanner.Core;

// utility class to manage the point of sale terminal
public class PointOfSaleTerminal
{
    private readonly IShoppingCart _shoppingCart;
    private readonly IPriceSheetRepository _priceSheetRepository;

    public PointOfSaleTerminal(IShoppingCart shoppingCart, IPriceSheetRepository priceSheetRepository)
    {
        _shoppingCart = shoppingCart;
        _priceSheetRepository = priceSheetRepository;
    }

    public void Reset()
    {
        _shoppingCart.Reset();
    }

    public void SetPricing(string code, decimal unitPrice, decimal volumePrice = 0, int volumeSize = 0)
    {
        CartItem cartItem = new(code, unitPrice, volumePrice, volumeSize);

        _priceSheetRepository.Add(cartItem);
    }

    public void Scan(string code)
    {
        _shoppingCart.Scan(code);
    }

    public decimal CalculateTotal()
    {
        return _shoppingCart.GetTotal();
    }
}
