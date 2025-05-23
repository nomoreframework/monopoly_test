using Models;

public class WareHouseService()
{
    public IEnumerable<Pallet> GetPalletsGroupSort(IEnumerable<Pallet> pallets) => pallets.
    GroupBy(g => g.ExpirationDate)
    .OrderBy(g => g.Key)
    .SelectMany(p => p)
    .OrderBy(p => p.Weight);

    public IEnumerable<Pallet> GetTop3PalletsWithMaxExpirationdate(IEnumerable<Pallet> pallets) => pallets.
    OrderBy(p => p.ExpirationDate).Take(3);
}
