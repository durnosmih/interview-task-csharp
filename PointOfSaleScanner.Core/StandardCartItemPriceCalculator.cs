namespace PointOfSaleScanner.Core;

// can be extended with strategy pattern 
// different strategies for different price calculations - multiple volumes, promotions, sales, taxes, bundled offers, etc.
// for example, base price + taxes + shipping + promotions if applicable
public class StandardCartItemPriceCalculator : ICartItemPriceCalculator
{
    public readonly IPriceSheetRepository _priceSheetRepository;

    public StandardCartItemPriceCalculator(IPriceSheetRepository priceSheetRepository)
    {
        _priceSheetRepository = priceSheetRepository;
    }

    public decimal GetTotal(string code, int quantity)
    {
        var item = _priceSheetRepository.Find(code);

        return item.UnitPrice * item.GetUnitPricedQuantity(quantity) +
               item.VolumePrice * item.GetVolumePricedQuantity(quantity);
    }
}
