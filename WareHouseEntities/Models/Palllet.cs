using Exceptions;

namespace Models;

public class Pallet : WareHouseEntity
{
    public Pallet(List<Box> boxes, uint width, uint height, uint depth,uint weight) : base(width, height, depth,weight)
    {
        Boxes = [];
        addBoxes(boxes);
    }
    public override uint Weight => (uint)Boxes.Sum(b => b.Weight) + 30;
    public List<Box> Boxes { get; private set; }
    public override uint Volume => (uint)Boxes.Sum(b => b.Volume) + Width * Depth * Height;
    public override DateOnly? ExpirationDate => Boxes.Min(b => b?.ExpirationDate);
    public List<Box> AddBox(Box box)
    {
        if (box.Depth > this.Depth || box.Width > this.Width)
            throw new WareHouseException($"Size of box '{nameof(Width)},{nameof(Depth)}' must be less than size of pallet.");
        Boxes.Add(box);
        return Boxes;
    }
    private void addBoxes(List<Box> boxes)
    {
        foreach (var b in boxes)
            AddBox(b);
    }
}