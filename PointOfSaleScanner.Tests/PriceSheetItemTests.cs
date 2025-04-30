using PointOfSaleScanner.Core;

namespace PointOfSaleScanner.Tests;

[TestClass]
public sealed class PriceSheetItemTests
{
    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(0, 2, 2)]
    [DataRow(0, 3, 3)]
    [DataRow(2, 2, 0)]
    [DataRow(2, 3, 1)]
    [DataRow(2, 4, 0)]
    [DataRow(3, 6, 0)]
    [DataRow(3, 7, 1)]
    [DataRow(3, 8, 2)]
    [DataRow(3, 9, 0)]
    public void GetUnitPricedQuantity_PassItemVolumeSize_UnitPricedQuantityShouldTakeIntoAccountVolumeSize(
        int volumeSize,
        int overallQuantity, 
        int expectedUnitPricedQuantity)
    {
        string code = "A123";
        decimal unitPrice = 1.99m;
        decimal volumePrice = 4.99m;
        
        PriceSheetItem item = new(code, unitPrice, volumePrice, volumeSize);
        int actualUnitPricedQuantity = item.GetUnitPricedQuantity(overallQuantity);

        Assert.AreEqual(code, item.Code);
        Assert.AreEqual(unitPrice, item.UnitPrice);
        Assert.AreEqual(volumePrice, item.VolumePrice);
        Assert.AreEqual(volumeSize, item.VolumeSize);
        Assert.AreEqual(expectedUnitPricedQuantity, actualUnitPricedQuantity);
    }

    [TestMethod]
    [DataRow(0, 0, 0)]
    [DataRow(0, 2, 0)]
    [DataRow(2, 2, 1)]
    [DataRow(2, 3, 1)]
    [DataRow(2, 4, 2)]
    [DataRow(3, 6, 2)]
    [DataRow(3, 7, 2)]
    [DataRow(3, 8, 2)]
    [DataRow(3, 9, 3)]
    public void GetVolumePricedQuantity_PassItemVolumeSize_UnitPricedQuantityShouldTakeIntoAccountVolumeSize(
        int volumeSize,
        int overallQuantity,
        int expectedVolumePricedQuantity)
    {
        string code = "A123";
        decimal unitPrice = 1.99m;
        decimal volumePrice = 4.99m;

        PriceSheetItem item = new(code, unitPrice, volumePrice, volumeSize);
        int actualVolumePricedQuantity = item.GetVolumePricedQuantity(overallQuantity);

        Assert.AreEqual(code, item.Code);
        Assert.AreEqual(unitPrice, item.UnitPrice);
        Assert.AreEqual(volumePrice, item.VolumePrice);
        Assert.AreEqual(volumeSize, item.VolumeSize);
        Assert.AreEqual(expectedVolumePricedQuantity, actualVolumePricedQuantity);
    }
}
