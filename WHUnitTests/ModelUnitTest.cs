using Exceptions;
using Models;
namespace WHUnitTests;

public class ModelUnitTest
{
    public static List<Box> boxes => new List<Box>(2) { new(new DateOnly(), null, 200, 200, 200, 200), new(new DateOnly(), null, 200, 200, 200, 200) };
    [Fact]
    public void PalletConstructorExTest()
    {
        Assert.Throws<WareHouseException>(() => new Pallet([], 0, 0, 0, 0));
    }
    [Fact]
    public void BoxConstructorExTest()
    {
        Assert.Throws<WareHouseException>(() => new Box(new DateOnly(), null, 0, 0, 0, 0));
    }
    [Fact]
    public void TestPalletExpirationDate()
    {
        Assert.Null(new Pallet([], 1000, 100, 1000, 1000).ExpirationDate);
        Assert.Equal(boxes.Min(b => b.ExpirationDate), new Pallet(boxes, 1000, 100, 1000, 1000).ExpirationDate);
    }
    [Theory]
    [InlineData(1000, 10, 1000, 1000)]
    public void PalletVolumeTest(uint p_width, uint p_heiht, uint p_depth, uint weight)
    {
        Assert.Equal(boxes.Select(b => (uint)Math.Pow(b.Width, 3)).Sum(p => p) + p_width * p_heiht * p_depth, new Pallet(boxes, p_width, p_heiht, p_depth, weight).Volume);
    }
    [Theory]
    [InlineData(99, 100, 300, 1000)]
    public void PalletAddBoxExTest(uint p_width, uint p_heiht, uint p_depth, uint weight)
    {
        Assert.Throws<WareHouseException>(() => new Pallet(boxes, p_width, p_heiht, p_depth, weight).AddBox(boxes[1]));
        Assert.Throws<WareHouseException>(() => new Pallet(boxes, p_width, p_heiht, p_depth, weight));
    }
    [Theory]
    [InlineData(1000, 100, 1000, 30_000)]
    public void PaletWeightTest(uint p_width, uint p_heiht, uint p_depth, uint weight)
    {
        Assert.Equal(boxes.Sum(b => b.Weight) + weight, new Pallet(boxes, p_width, p_heiht, p_depth, weight).Weight);        
    }
}