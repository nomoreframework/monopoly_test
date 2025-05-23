using Models;

public static class SynteticData
{
    public static IEnumerable<Pallet> GetPallets()
    {
        var boxes = Enumerable.Range(1, 3)
        .SelectMany(i => Enumerable.Range(3,6).Select(i => new Box(null, new DateOnly(2025, 1, 1).AddDays(i % 3 == 0 ? 31 : 0),
        resize3th(i, 200), resize3th(i, 200), resize3th(i, 200), resize3th(i, 10)))).ToList();
        return Enumerable.Range(1, 5).Select(i => new Pallet(boxes, 10_000, 1000, 10_000, 10_00));
    }
    private static uint resize3th(int i, int size) => (uint)i % 3 == 0 ? (uint)i * (uint)size : (uint)size;
}