using Exceptions;

namespace Models;

public class Box : WareHouseEntity
{
    public Box(DateOnly? expirationDate, DateOnly? manufactureDate, uint width, uint heigth, uint depth, uint weight) : base(width, heigth, depth, weight)
    {
        this.manufactureDate = manufactureDate;
        this.expirationDate = manufactureDate != null ? manufactureDate!.Value.AddDays(100) : expirationDate
        ?? throw new WareHouseException("One of the fields must be filed with a value");
    }
    public override DateOnly? ExpirationDate => expirationDate;
    private DateOnly? expirationDate;
    public DateOnly? ManufactureDate => manufactureDate;
    private DateOnly? manufactureDate;
    public override uint Volume => Width * Height * Depth;

}