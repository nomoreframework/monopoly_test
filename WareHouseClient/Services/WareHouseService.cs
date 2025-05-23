using Models;

public class WareHouseService()
{
    public IEnumerable<Pallet> GetPalletsGroupSort(IEnumerable<Pallet> pallets) => pallets.
    GroupBy(g => g.ExpirationDate)
    .OrderBy(g => g.Key)
    .SelectMany(p => p)
    .OrderBy(p => p.Weight);

    public IEnumerable<Pallet> GetTop3PalletsWithMaxExpirationdate(IEnumerable<Pallet> pallets) => pallets.
    OrderByDescending(p => p.ExpirationDate).ThenByDescending(p => p.Volume).Take(3);
}
