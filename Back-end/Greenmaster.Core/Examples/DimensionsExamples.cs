using Greenmaster.Core.Models.Measurements;

namespace Greenmaster.Core.Examples;

public static class DimensionsExamples
{
    public static readonly Dimensions DimensionsUp = new()
    {
        Id = 1,
        Height = 2.5,
        Width = 0.75
    };
    public static readonly Dimensions DimensionsFlat = new()
    {
        Id = 2,
        Length = 10,
        Width = 4.5
    };
    
    
    public static List<Dimensions> GetAll()
    {
        return new()
        {
            DimensionsUp, DimensionsFlat
        };
    }
}