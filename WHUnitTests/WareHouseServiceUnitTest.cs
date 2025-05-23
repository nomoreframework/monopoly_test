using System.Linq.Expressions;
using Models;

namespace WHUnitTests;

public class WareHouseServiceUnitTest
{
    private readonly WareHouseService _service = new();
    private readonly List<Box> boxes = [new(new DateOnly(2025, 6, 1), null, 100, 100, 100, 10)];
    private readonly List<Box> boxes2 = [new(new DateOnly(2025, 7, 1), null, 200, 200, 200, 20)];
    private readonly List<Box> boxes3 = [new(new DateOnly(2025, 8, 1), null, 300, 300, 300, 30)];

    List<Pallet> pallets = new();
    [Fact]
    public void GetPalletsGroupSort_ShouldSortByExpirationThenWeight()
    {

        pallets = [ new (boxes,1000,1000,1000),
            new (boxes2,1000,1000,1000),
            new (boxes3,1000,100,1000)];
        var result = _service.GetPalletsGroupSort(pallets).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(new DateOnly(2025, 6, 1), result[0].ExpirationDate);
        Assert.Equal(new DateOnly(2025, 7, 1), result[1].ExpirationDate);
    }

    [Fact]
    public void GetTop3PalletsWithMaxExpirationdate_ShouldReturnTop3Latest()
    {
        pallets = [ new (boxes,1000,1000,1000),
            new (boxes2,1000,1000,1000),
            new (boxes3,1000,100,1000)];

        var result = _service.GetTop3PalletsWithMaxExpirationdate(pallets).ToList();

        Assert.Equal(3, result.Count);
        Assert.True(result[0].ExpirationDate > result[1].ExpirationDate);
        Assert.True(result[1].ExpirationDate > result[2].ExpirationDate);
    }
}

