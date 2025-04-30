namespace PointOfSaleScanner.Core;

// can be extended with strategy pattern 
// different strategies for different price calculations - multiple volumes, promotions, sales, taxes, bundled offers, etc.
// for example, base price + taxes + shipping + promotions if applicable
public class CartItemPriceCalculator : ICartItemPriceCalculator
{
    public readonly IEnumerable<CartItem> _priceSheet;

    public CartItemPriceCalculator(IEnumerable<CartItem> priceSheet)
    {
        _priceSheet = priceSheet;
    }

    public decimal GetTotal(string code, int quantity)
    {
        var item = _priceSheet.First(item => string.Equals(item.Code, code, StringComparison.OrdinalIgnoreCase));

        int itemsWithVolumePrice = item.VolumeQuantity == 0 ? 0 : quantity / item.VolumeQuantity;
        int itemsWithUnitPrice = item.VolumeQuantity == 0 ? quantity : quantity % item.VolumeQuantity;

        return itemsWithVolumePrice * item.VolumePrice + itemsWithUnitPrice * item.UnitPrice;
    }
}
