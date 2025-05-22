using Exceptions;
using Interfaces;

namespace Models;

public abstract class WareHouseEntity : IWareHouseEntity<uint>
{
    public WareHouseEntity(uint width, uint heigth, uint depth)
    {
        if (validateProps(width, heigth, depth))
        {
            Width = width;
            Heigth = heigth;
            Depth = depth;
            EntityId = Guid.NewGuid();
        }
        else
            throw new WareHouseException($"Values for {nameof(Width)},{nameof(Heigth)} and {nameof(depth)} must be over than '0'.");
    }
    public Guid EntityId { get; private set; }
    public uint Weigth { get; private set; }
    public uint Width { get; private set; }
    public uint Heigth { get; private set; }
    public uint Depth { get; private set; }
    public virtual uint Volume { get; }
    private bool validateProps(uint width, uint heigth, uint depth) => width != 0 & heigth != 0 & depth != 0;
}