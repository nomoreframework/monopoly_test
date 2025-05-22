namespace Models;

public class Box : WareHouseEntity
{
    public Box(DateOnly? expirationDate, DateOnly? manufactureDate, uint width, uint heigth, uint depth) : base(width, heigth, depth)
    {
        this.manufactureDate = manufactureDate;
        this.expirationDate = manufactureDate != null ? manufactureDate!.Value.AddDays(100) : expirationDate;
    }
    public DateOnly? ExpirationDate => expirationDate;
    private DateOnly? expirationDate;
    public DateOnly? ManufactureDate => manufactureDate;
    private DateOnly? manufactureDate;
    public override uint Volume => Width * Heigth * Depth;

}