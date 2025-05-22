using Exceptions;

namespace Models;

public class Pallet : WareHouseEntity
{
    public Pallet(List<Box> boxes, uint width, uint heigth, uint depth) : base(width, heigth, depth)
    {
        Boxes = [];
        addBoxes(boxes);
    }
    public new uint Weigth => (uint)Boxes.Sum(b => b.Weigth) + 30;
    public List<Box> Boxes { get; private set; }
    public override uint Volume => (uint)Boxes.Sum(b => b.Volume) + Width * Depth * Heigth;
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