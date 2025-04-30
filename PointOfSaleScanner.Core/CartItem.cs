namespace PointOfSaleScanner.Core;

public record CartItem
{
    public string Code { get; }
    public decimal UnitPrice { get; }
    public decimal VolumePrice { get; }
    public int VolumeSize { get; }

    public CartItem(string code, decimal unitPrice, decimal volumePrice = 0, int volumeSize = 0)
    {
        Code = code;
        UnitPrice = unitPrice;
        VolumePrice = volumePrice;
        VolumeSize = volumeSize;
    }

    public bool VolumePricingApplied => VolumeSize > 0;

    public int GetUnitPricedQuantity(int overallQuantity)
    {
        if (VolumePricingApplied)
            return overallQuantity % VolumeSize;
        
        return overallQuantity;
    }

    public int GetVolumePricedQuantity(int overallQuantity)
    {
        if (VolumePricingApplied)
            return overallQuantity / VolumeSize;
        
        return 0;
    }
}
