using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Examples;

public class DimensionsExamples
{
    public static readonly Dimensions DimensionsUp = new Dimensions
    {
        Id = 1,
        Height = 2.5,
        Width = 0.75
    };
    public static readonly Dimensions DimensionsFlat = new Dimensions
    {
        Id = 1,
        Length = 10,
        Width = 4.5
    };
    
    
    public static List<Dimensions> GetAll()
    {
        return new List<Dimensions>()
        {
            DimensionsUp, DimensionsFlat
        };
    }
}