namespace PointOfSaleScanner.Core
{
    public interface IPriceSheetRepository
    {
        void Add(CartItem cartItem);
        CartItem Find(string code);
    }
}