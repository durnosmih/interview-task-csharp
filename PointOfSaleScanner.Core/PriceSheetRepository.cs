namespace PointOfSaleScanner.Core;

public class PriceSheetRepository : IPriceSheetRepository
{
    private readonly IList<PriceSheetItem> _priceSheet = [];

    public void Add(PriceSheetItem cartItem)
    {
        _priceSheet.Add(cartItem);
    }

    public PriceSheetItem Find(string code)
    {
        return _priceSheet.First(item => string.Equals(item.Code, code, StringComparison.OrdinalIgnoreCase));
    }
}
