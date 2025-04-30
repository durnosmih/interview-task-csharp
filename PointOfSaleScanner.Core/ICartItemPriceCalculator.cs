namespace PointOfSaleScanner.Core;

public interface ICartItemPriceCalculator
{
    decimal GetTotal(string code, int quantity);
}
