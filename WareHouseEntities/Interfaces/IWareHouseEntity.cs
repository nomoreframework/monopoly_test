namespace Interfaces;

public interface IWareHouseEntity<T> where T : struct
{
    public Guid EntityId { get; }
    public T Weigth { get; }
    public T Width { get; }
    public T Heigth { get; }
    public T Depth { get; }
    public T Volume { get; }
}