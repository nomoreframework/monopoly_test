using Models;

var print = (object o) => Console.WriteLine(o);

var service = new WareHouseService();
var pallets = SynteticData.GetPallets();
var groupingPallets = service.GetPalletsGroupSort(pallets);
var top3Pallets = service.GetTop3PalletsWithMaxExpirationdate(pallets);

while (true)
{
    print($" All pallets -'a', Top 3 sorted pallets - '3', Grouping pallets - 'g', another key exit.{"\n"}");
    var keyChar = Console.ReadKey().KeyChar;
    switch (keyChar)
    {
        case 'a':
            printCollection(pallets);
            break;
        case '3':
            printCollection(top3Pallets);
            break;
        case 'g':
            printCollection(groupingPallets);
            break;
        default:
            return;
    }
}
void printCollection(IEnumerable<Pallet> pallets)
{
    int i = 1;
    int j = 1;
    print("All pallets:" + "\n");
    foreach (var p in pallets)
    {
        print($"{i++} {p.AllPropertiesToString("PalletId", volume: WareHouseModelsExtention.Volume.Meters, weight: WareHouseModelsExtention.Weight.Kilograms)}");
        foreach (var b in p.Boxes)
        {
            print($"--{j++} {b.AllPropertiesToString("BoxId", WareHouseModelsExtention.Volume.Meters, WareHouseModelsExtention.Weight.Kilograms)}");
        }
        j = 1;
    }
}