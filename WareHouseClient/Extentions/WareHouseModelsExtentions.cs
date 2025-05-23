using System.Reflection;
using Models;

public static class WareHouseModelsExtention
{
    public enum Weight : uint
    {
        Grams = 1,
        Kilograms = 1000,
        Ton = 1000_000
    }
    public enum Volume : uint
    {
        Millimeters = 1,
        Centimetrs = 10,
        Meters = 1000
    }
    public static string AllPropertiesToString(this WareHouseEntity entity, string idName = "Id", Volume volume = Volume.Millimeters, Weight weight = Weight.Grams)
    {
        uint weightFormater = (uint)weight;
        uint volumeFormater = (uint)volume;
        string volumeMeasurment = "mm";
        string weightMeasurment = "g";
        var type = typeof(uint);
        switch (volume)
        {
            case Volume.Centimetrs:
                volumeFormater = (uint)volume;
                volumeMeasurment = "cm";
                break;
            case Volume.Meters:
                volumeFormater = (uint)volume;
                volumeMeasurment = "m";
                break;
        }

        switch (weight)
        {
            case Weight.Kilograms:
                weightFormater = (uint)weight;
                weightMeasurment = "kg";
                break;
            case Weight.Ton:
                weightFormater = (uint)weight;
                weightMeasurment = "t";
                break;
        }
        return $"{idName} = {entity.EntityId}, Weight = {(float)entity.Weight / weightFormater}{weightMeasurment}, " +
        $"Width = {(float)entity.Width / volumeFormater}{volumeMeasurment}, Heigth = {(float)entity.Height / volumeFormater}{volumeMeasurment}, " +
        $"Depth = {(float)entity.Depth / volumeFormater}{volumeMeasurment}, " +
        $"Volume = {(float)entity.Volume / Math.Pow(volumeFormater,3)}{volumeMeasurment}^3, ExpirationDate = {entity.ExpirationDate}";
    }
}