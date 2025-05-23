using Models;

public static class SynteticData
{
    public static IEnumerable<Pallet> GetPallets()
    {
        var boxes = Enumerable.Range(1, 3)
        .Select(i => new Box(null, new DateOnly(2025, 1, 1).AddMonths(i).AddDays(i % 3 == 0 ? 31 : 0),
        resize3th(i, 200), resize3th(i, 200), resize3th(i, 200), resize3th(i, 10))).ToList();
        var boxes2 = Enumerable.Range(3, 6)
        .Select(i => new Box(null, new DateOnly(2025, 1, 1).AddMonths(i).AddDays(i % 3 == 0 ? 31 : 0),
        resize3th(i, 200), resize3th(i, 200), resize3th(i, 200), resize3th(i, 10))).ToList();

        var boxes3 = Enumerable.Range(6, 9)
      .Select(i => new Box(null, new DateOnly(2025, 1, 1).AddMonths(i).AddDays(i % 3 == 0 ? 31 : 0),
      resize3th(i, 200), resize3th(i, 200), resize3th(i, 200), resize3th(i, 10))).ToList();

        return Enumerable.Range(1, 9).Select(i => new Pallet(i % 2 == 0 ? boxes2 : i % 3 == 0 ? boxes3 : boxes, 10_000, 1000, 10_000));
    }
    private static uint resize3th(int i, int size) => (uint)i % 3 == 0 ? (uint)i * (uint)size : (uint)size;
}