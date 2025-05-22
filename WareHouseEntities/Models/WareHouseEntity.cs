using Exceptions;
using Interfaces;

namespace Models;

public abstract class WareHouseEntity : IWareHouseEntity<uint>
{
    public WareHouseEntity(uint width, uint heigth, uint depth,uint weight)
    {
        if (validateProps(width, heigth, depth, weight))
        {
            Width = width;
            Height = heigth;
            Depth = depth;
            EntityId = Guid.NewGuid();
            Weight = weight;
        }
        else
            throw new WareHouseException($"Values for {nameof(Width)},{nameof(Height)} and {nameof(depth)} must be over than '0'.");
    }
    public Guid EntityId { get; private set; }
    public virtual uint Weight { get; set; }
    public uint Width { get; private set; }
    public uint Height { get; private set; }
    public uint Depth { get; private set; }
    public virtual uint Volume { get; }
    public virtual DateOnly? ExpirationDate { get; set; }

    private bool validateProps(uint width, uint heigth, uint depth,uint weight) => width != 0 & heigth != 0 & depth != 0 & weight != 0;
}