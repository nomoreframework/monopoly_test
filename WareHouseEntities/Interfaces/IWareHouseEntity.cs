namespace Interfaces;

public interface IWareHouseEntity<T> where T : struct
{
    public Guid EntityId { get; }
    public T Weight { get; }
    public T Width { get; }
    public T Height { get; }
    public T Depth { get; }
    public T Volume { get; }
}