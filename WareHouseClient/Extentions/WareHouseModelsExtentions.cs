using Models;

public static  class WareHouseModelsExtention
{
    public static string AllPropertiesToString(this WareHouseEntity entity,string idName = "Id")
    {
        return $"{idName} = {entity.EntityId}, Weight = {entity.Weight}," +
        $"Width = {entity.Width}, Heigth = {entity.Height},Depth = {entity.Depth}," +
        $"ExpirationDate = {entity.ExpirationDate}";
    }
}