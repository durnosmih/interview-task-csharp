namespace PointOfSaleScanner.Core.Utility;

// just an utility class to build the pricing sheet
public class PricingSheetBuilder
{
    private readonly Dictionary<string, CartItem> _items = [];

    public ItemBuilder WithItem(string code)
    {
        if (!_items.ContainsKey(code))
            _items[code] = new CartItem { Code = code };

        return new ItemBuilder(_items[code]);
    }

    public IEnumerable<CartItem> Build() => _items.Values;

    public class ItemBuilder
    {
        private readonly CartItem _item;

        public ItemBuilder(CartItem item)
        {
            _item = item;
        }

        public ItemBuilder SetUnitPrice(decimal price)
        {
            _item.UnitPrice = price;
            return this;
        }

        public ItemBuilder SetVolumePrice(decimal volumePrice, int volumeQty)
        {
            _item.VolumePrice = volumePrice;
            _item.VolumeQuantity = volumeQty;
            return this;
        }
    }
}
