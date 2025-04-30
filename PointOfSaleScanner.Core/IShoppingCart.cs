namespace PointOfSaleScanner.Core;

public interface IShoppingCart
{
    void Scan(string code);
    decimal GetTotal();
    void Reset();
}