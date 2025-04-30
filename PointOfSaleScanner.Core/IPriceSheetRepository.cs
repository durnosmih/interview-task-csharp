namespace PointOfSaleScanner.Core
{
    public interface IPriceSheetRepository
    {
        void Add(PriceSheetItem cartItem);
        PriceSheetItem Find(string code);
    }
}