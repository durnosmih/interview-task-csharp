namespace PointOfSaleScanner.Core;

public class CartItem
{
    public string Code { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal VolumePrice { get; set; }
    public int VolumeQuantity { get; set; }
}
